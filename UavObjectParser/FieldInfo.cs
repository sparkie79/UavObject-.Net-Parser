using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UavObjectParser
{
    public class FieldInfo : ICloneable
    {
        public String name { get; set; }
        public String units { get; set; }
        public FieldType type { get; set; }
        public int numElements { get; set; }
        public int numBytes { get; set; }
        public String[] elementNames { get; set; }
        public String[] options { get; set; } // for enums only
        public bool defaultElementNames { get; set; }
        public String[] defaultValues { get; set; }
        public String limitValues { get; set; }
        
        public int size { get { return numBytes * numElements; } }

        public string dotnetType
        {
            get
            {
                switch (type)
                {
                    case FieldType.INT8:
                        return "sbyte";
                    case FieldType.INT16:
                        return "Int16";
                    case FieldType.INT32:
                        return "Int32";
                    case FieldType.UINT8:
                        return "byte";
                    case FieldType.UINT16:
                        return "UInt16";
                    case FieldType.UINT32:
                        return "UInt32";
                    case FieldType.FLOAT32:
                        return "float";
                    case FieldType.ENUM:
                        return name + "UavEnum";
                    default:
                        return "";
                }
            }
        }

        public string[] optionSimple
        {
            get { return options.Select(j => simplify(j)).ToArray(); }
        }

        public String[] defaultValuesSimple 
        {
            get { return defaultValues.Select(j => simplify(j)).ToArray(); }
        }

        private string simplify(string text)
        {
            text = Regex.Replace(text, @"[^a-zA-Z0-9]", "");
            if (Regex.IsMatch(text, @"^\d"))
                text = "v" + text;
            return text;
        }

        public object Clone()
        {
            return new FieldInfo()
            {
                name = this.name,
                units = this.units,
                type = this.type,
                numElements = this.numElements,
                numBytes = this.numBytes,
                elementNames = this.elementNames,
                options = this.options,
                defaultElementNames = this.defaultElementNames,
                defaultValues = this.defaultValues,
                limitValues = this.limitValues
            };
        }
    }
}
