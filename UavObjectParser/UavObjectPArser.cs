using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;

namespace UavObjectParser
{
    public class UavObjParser
    {
        private ICollection<UavObjectInfo> objInfo;
        private string[] fieldTypeStrXML = {"int8","int16","int32","uint8","uint16","uint32","float","enum"};
        private int[] fieldTypeNumBytes = {1,2,4,1,2,4,4,1};

        private String[] updateModeStrXML = { "manual", "onchange", "periodic", "throttled" };
        private AccessMode[] accessMode = { AccessMode.ACCESS_READWRITE, AccessMode.ACCESS_READONLY };
        private String[] accessModeStrXML = {"readwrite","readonly"};

        private List<String> all_units = new List<string>();

        public UavObjParser(string xmlFile)
        {
            objInfo = new List<UavObjectInfo>();
            ParseXml(xmlFile);
        }

        public int getNumObjects()
        {
            return objInfo.Count();
        }

        public IEnumerable<UavObjectInfo> getObjectInfo()
        {
            return objInfo;
        }

        public UavObjectInfo getObjectByIndex(int index)
        {
            return objInfo.ElementAt(index);
        }

        public string getObjectName(int objIndex)
        {
            return objInfo.ElementAt(objIndex).name;
        }

        public UInt32 getObjectID(int objIndex)
        {
            return objInfo.ElementAt(objIndex).id;
        }

        public int getNumBytes(int objIndex)
        {
            UavObjectInfo obj = getObjectByIndex(objIndex);
            return obj.fields.Sum(j => j.size); 
        }

        public string ParseXml(string filename)
        {
            XDocument xdoc = XDocument.Load(filename);
            foreach(XElement obj in xdoc.Descendants("object"))
            {
                UavObjectInfo item = new UavObjectInfo();
                string result = parseObj(obj,item);
                if (result != "")
                    return result;
                objInfo.Add(item);
            }
            return "";
        }

        private String parseObj(XElement obj, UavObjectInfo rv)
        {
            processObjectMetadataResult res;
            string retval;

            retval = processObjectAttributes(rv, obj);
            if (retval != "")
                return retval;
            
            bool fieldFound = false;
            bool accessFound = false;
            bool telGCSFound = false;
            bool telFlightFound = false;
            bool logFound = false;
            bool descriptionFound = false;

            foreach (var item in obj.Elements())
            {
                switch (item.Name.LocalName)
                {
                    case "field":
                        retval = processObjectField(rv, item);
                        if (retval != "")
                            return retval;
                        fieldFound = true;
                        break;
                    case "access":
                        retval = processObjectAccess(rv, item);
                        if (retval != "")
                            return retval;
                        accessFound = true;
                        break;
                    case "telemetrygcs":
                        res = processObjectMetadata(rv, item, true);
                        if (res.result != null)
                            return res.result;
                        rv.gcsTelemetryUpdateMode = res.updateMode;
                        rv.gcsTelemetryUpdatePeriod = res.UpdatePeriod;
                        rv.gcsTelemetryAcked = res.acked;
                        telGCSFound = true;
                        break;
                    case "telemetryflight":
                        res = processObjectMetadata(rv, item, true);
                        if (res.result != null)
                            return res.result;
                        rv.flightTelemetryUpdateMode = res.updateMode;
                        rv.flightTelemetryUpdatePeriod = res.UpdatePeriod;
                        rv.flightTelemetryAcked = res.acked;
                        telFlightFound = true;
                        break;
                    case "logging":
                        res = processObjectMetadata(rv, item, false);
                        if (res.result != null)
                            return res.result;
                        rv.loggingUpdateMode = res.updateMode;
                        rv.loggingUpdatePeriod = res.UpdatePeriod;
                        logFound = true;
                        break;
                    case "description":
                        string desc = rv.description;
                        retval = processObjectDescription(item, ref desc);
                        rv.description = desc;
                        if (retval != "")
                            return retval;
                        descriptionFound = true;
                        break;
                    default:
                        return "Unknown object element";
                }
            }

            var ordered = rv.fields.OrderByDescending(j => j.numBytes).ToList();
            rv.fields = ordered;

            // Make sure that required elements were found
            if (!fieldFound)
                return "Object::field element is missing";

            if (!accessFound)
                return "Object::access element is missing";

            if (!telGCSFound)
                return "Object::telemetrygcs element is missing";

            if (!telFlightFound)
                return "Object::telemetryflight element is missing";

            if (!logFound)
                return "Object::logging element is missing";

            // TODO: Make into error once all objects updated
            if (!descriptionFound)
                return "Object::description element is missing";

            updateID(rv);
            return "";
        }

        private void updateID(UavObjectInfo info)
        {
            // Hash object name
            UInt32 hash = updateHash(info.name, 0);
            // Hash object attributes
            hash = updateHash(info.isSettings, hash);
            hash = updateHash(info.isSingleInst, hash);
            // Hash field information
            foreach (var field in info.fields)
            {
                hash = updateHash(field.name,hash);
                hash = updateHash((UInt32)field.numElements, hash);
                hash = updateHash((UInt32)field.type, hash);
                if (field.type == FieldType.ENUM)
                    foreach (string option in field.options)
                        hash = updateHash(option, hash);
            }
            // Done
            info.id = hash & 0xFFFFFFFE;
        }

        private UInt32 updateHash(bool value, UInt32 hash)
        {
            UInt32 par = (UInt32)(value ? 1 : 0);
            return updateHash(par, hash);
        }

        private UInt32 updateHash(string value, UInt32 hash)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(value);
            UInt32 hashout = hash;
            for (int n = 0; n < bytes.Count(); ++n)
                hashout = updateHash(bytes[n], hashout);

            return hashout;
        }

        private UInt32 updateHash(UInt32 value, UInt32 hash)
        {
            return (hash ^ ((hash << 5) + (hash >> 2) + value));
        }

        private string processObjectAttributes(UavObjectInfo obj, XElement xml)
        {
            XAttribute x = xml.Attribute("name");
            if (x == null)
                return "Object:name attribute is missing";
            obj.name = x.Value;


            x = xml.Attribute("category");
            if (x != null)
                obj.category = x.Value;

            x = xml.Attribute("singleinstance");
            if (x == null)
                return "Object:singleinstance attribute is missing";
            
            switch (x.Value)
            {
                case "true":
                    obj.isSingleInst = true;
                    break;
                case "false":
                    obj.isSingleInst = false;
                    break;
                default:
                    return "Object:singleinstance attribute value is invalid";
            }

            x = xml.Attribute("settings");
            if (x == null)
                return "Object:settings attribute is missing";

            switch (x.Value)
            {
                case "true":
                    obj.isSettings = true;
                    break;
                case "false":
                    obj.isSettings = false;
                    break;
                default:
                    return "Object:settings attribute value is invalid";
            }

            if (obj.isSettings && !obj.isSingleInst)
                return "Object: Settings objects can not have multiple instances";
            return "";
        }

        /*
         * QDomNamedNodeMap attributes = node.attributes();
    QDomNode attr = attributes.namedItem("name");
    if ( attr.isNull() )
        return QString("Object:name attribute is missing");

    info->name = attr.nodeValue();
    info->namelc = attr.nodeValue().toLower();

    // Get category attribute if present
    attr = attributes.namedItem("category");
    if ( !attr.isNull() )
    {
        info->category = attr.nodeValue();
    }

    // Get singleinstance attribute
    attr = attributes.namedItem("singleinstance");
    if ( attr.isNull() )
        return QString("Object:singleinstance attribute is missing");

    if ( attr.nodeValue().compare(QString("true")) == 0 )
        info->isSingleInst = true;
    else if ( attr.nodeValue().compare(QString("false")) == 0 )
        info->isSingleInst = false;
    else
        return QString("Object:singleinstance attribute value is invalid");

    // Get settings attribute
    attr = attributes.namedItem("settings");
    if ( attr.isNull() )
        return QString("Object:settings attribute is missing");

    if ( attr.nodeValue().compare(QString("true")) == 0 )
            info->isSettings = true;
    else if ( attr.nodeValue().compare(QString("false")) == 0 )
        info->isSettings = false;
    else
        return QString("Object:settings attribute value is invalid");


    // Settings objects can only have a single instance
    if ( info->isSettings && !info->isSingleInst )
        return QString("Object: Settings objects can not have multiple instances");

    // Done
    return QString();
         * */
        private string processObjectField(UavObjectInfo obj, XElement xml)
        {
            FieldInfo field = new FieldInfo();
            XAttribute x = xml.Attribute("name");
            if (x == null)
                return "Object:field:name attribute is missing";
            string name = x.Value;

            x = xml.Attribute("cloneof");
            if (x != null)
            {
                string parentName = x.Value;
                FieldInfo field1 = obj.fields.FirstOrDefault(j => j.name == parentName);
                if (field1 != null)
                {
                    FieldInfo newField = (FieldInfo)field1.Clone();
                    newField.name = name;
                    obj.fields.Add(newField);
                    return "";
                }
                else
                    return "Object:field::cloneof parent unknown";
            }
            field.name = name;

            x = xml.Attribute("units");
            if (x == null)
                return "Object:field:units attribute is missing";
            field.units = x.Value;
            all_units.Add(x.Value);

            x = xml.Attribute("type");
            if (x == null)
                return "Object:field:type attribute is missing";
            int index = fieldTypeStrXML.FindIndex(j=>j == x.Value);
            if (index == -1)
                return "Object:field:type attribute value is invalid";
            field.type = (FieldType)index;
            field.numBytes = fieldTypeNumBytes[index];

            field.numElements = 0;
            x = xml.Attribute("elementnames");
            if (x != null)
            {
                string[] names = x.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                field.elementNames = names.Select(j => j.Trim()).ToArray();
                field.numElements = names.Count();
                field.defaultElementNames = false;
            }
            else
            {
                var items = xml.Elements("elementnames").Elements("elementname");
                string[] names = items.Select(j => j.Value).ToArray();
                field.elementNames = names;
                field.numElements = names.Count();
                field.defaultElementNames = false;
            }

            if (field.numElements == 0)
            {
                x = xml.Attribute("elements");
                if (x == null)
                    return "Object:field:elements and Object:field:elementnames attribute/element is missing";
                else
                {
                    field.numElements = int.Parse(x.Value);
                    List<String> names = new List<string>();
                    for (int i = 0; i < field.numElements; i++)
                        names.Add(i.ToString());
                    field.elementNames = names.ToArray();
                    field.defaultElementNames = true;
                }
            }

            if (field.type == FieldType.ENUM)
            {
                x = xml.Attribute("options");
                if (x != null)
                {
                    field.options = x.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(j => j.Trim()).ToArray();
                }
                else
                {
                    var items = xml.Elements("options").Elements("option");
                    field.options = items.Select(j => j.Value).ToArray();
                    if (field.options.Length == 0)
                        return "Object:field:options attribute/element is missing";
                }
            }

            x = xml.Attribute("defaultvalue");
            if(x == null)
            {
                if(obj.isSettings)
                    return "Object:field:defaultvalue attribute is missing (required for settings objects)";
                field.defaultValues = new string[0];
            } else
            {
                List<String> defaults = x.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(j => j.Trim()).ToList();

                if (defaults.Count() != field.numElements)
                {
                    if (defaults.Count() != 1)
                        return "Object:field:incorrect number of default values";
                    
                    for(int i=1; i<field.numElements; i++)
                    {
                        defaults.Add(defaults[0]);
                    }
                }
                field.defaultValues = defaults.ToArray();
            }

            x = xml.Attribute("limits");
            if (x == null)
                field.limitValues = "";
            else
                field.limitValues = x.Value;

            obj.fields.Add(field);
            return "";
        }

        private string processObjectAccess(UavObjectInfo obj, XElement xml)
        {
            XAttribute x = xml.Attribute("gcs");
            if (x == null)
                return "Object:access:gcs attribute is missing";

            obj.gcsAccess = (AccessMode)accessModeStrXML.FindIndex(j => j == x.Value);

            x = xml.Attribute("gcs");
            if (x == null)
                return "Object:access:flight attribute value is invalid";

            obj.flightAccess = (AccessMode)accessModeStrXML.FindIndex(j => j == x.Value);
            return "";
        }
                
        
        private class processObjectMetadataResult
        {
            public UPDATEMODE updateMode {get;set;}
            public int UpdatePeriod {get;set;}
            public bool acked {get;set;}
            public string result;
        }

        private processObjectMetadataResult processObjectMetadata(UavObjectInfo obj, XElement xml, bool getAcked )
        {
            processObjectMetadataResult rv = new processObjectMetadataResult();
            XAttribute x = xml.Attribute("updatemode");
            if(x == null)
            {
                rv.result = "Object:telemetrygcs:updatemode attribute is missing";
                return rv;
            }
            rv.updateMode = (UPDATEMODE)(updateModeStrXML.FindIndex( j => j == x.Value ) + 1);

            x = xml.Attribute("period");
            if(x == null)
            {
                rv.result = "Object:telemetrygcs:period attribute is missing";
                return rv;
            }
            rv.UpdatePeriod = int.Parse(x.Value);

            if (!getAcked)
                return rv;

            x = xml.Attribute("acked");
            if (x == null)
            {
                rv.result = "Object:telemetrygcs:acked attribute is missing";
                return rv;
            }
            switch (x.Value)
            {
                case "true":
                    rv.acked = true;
                    break;
                case "false":
                    rv.acked = false;
                    break;
                default:
                    rv.result = "Object:telemetrygcs:acked attribute value is invalid";
                    return rv;
            }

            return rv;
        }

        private string processObjectDescription(XElement xml, ref String description)
        {
            description += xml.Value;
            return "";
        }

        
        /*
         * 
         *  UAVObjectParser();
    QString parseXML(QString& xml, QString& filename);
    int getNumObjects();
    QList<ObjectInfo*> getObjectInfo();
    QString getObjectName(int objIndex);
    quint32 getObjectID(int objIndex);

    ObjectInfo* getObjectByIndex(int objIndex);
    int getNumBytes(int objIndex);
    QStringList all_units;*/

    }
}
