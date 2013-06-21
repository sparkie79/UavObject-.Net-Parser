using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public class UAVMetaObject : UAVObject
    {
        private UAVObject parent;
	    private Metadata ownMetadata;
	    private Metadata parentMetadata;

        public UAVMetaObject(long objID, String name, UAVDataObject parent) : base(objID, true, name) {
		    this.parent = parent;

		    ownMetadata = new Metadata();

		    ownMetadata.flags = 0; // TODO: Fix flags
		    ownMetadata.gcsTelemetryUpdatePeriod = 0;
		    ownMetadata.loggingUpdatePeriod = 0;


		    List<String> modesBitField = new List<String>();
		    modesBitField.Add("FlightReadOnly");
		    modesBitField.Add("GCSReadOnly");
		    modesBitField.Add("FlightTelemetryAcked");
		    modesBitField.Add("GCSTelemetryAcked");
		    modesBitField.Add("FlightUpdatePeriodic");
		    modesBitField.Add("FlightUpdateOnChange");
		    modesBitField.Add("GCSUpdatePeriodic");
		    modesBitField.Add("GCSUpdateOnChange");

            List<UAVObjectField> fields = new List<UAVObjectField>();
		    fields.Add( new UAVObjectField<bool>("Modes", "", 1, modesBitField, parent) );
            fields.Add(new UAVObjectField<UInt16>("Flight Telemetry Update Period", "ms", 1, null, parent));
            fields.Add(new UAVObjectField<UInt16>("GCS Telemetry Update Period", "ms", 1, null, parent));
            fields.Add(new UAVObjectField<UInt16>("Logging Update Period", "ms", 1, null, parent));

		    int numBytes = fields.Sum(j=>j.getNumBytes());
		    
		    // Initialize object

		    // Initialize parent
		    base.initialize(0);
		    initializeFields(fields, new ByteBuffer(numBytes), numBytes);

		    // Setup metadata of parent
		    parentMetadata = parent.getDefaultMetadata();
	    }

	    public override bool isMetadata() 
        {
		    return true;
	    }

	    /**
	     * Get the parent object
	     */
	    public UAVObject getParentObject()
	    {
		    return parent;
	    }

	    /**
	     * Set the metadata of the metaobject, this function will
	     * do nothing since metaobjects have read-only metadata.
	     */
	    public override void setMetadata(Metadata mdata)
	    {
		    return; // can not update metaobject's metadata
	    }

	    /**
	     * Get the metadata of the metaobject
	     */
	    public override Metadata getMetadata()
	    {
		    return ownMetadata;
	    }

	    /**
	     * Get the default metadata
	     */
	    public override Metadata getDefaultMetadata()
	    {
		    return ownMetadata;
	    }

	    /**
	     * Set the metadata held by the metaobject
	     */
	    public void setData(Metadata mdata)
	    {
		    //QMutexLocker locker(mutex);
		    parentMetadata = mdata;
		    // TODO: Callbacks
		    //	    emit objectUpdatedAuto(this); // trigger object updated event
		    //	    emit objectUpdated(this);
	    }

	    /**
	     * Get the metadata held by the metaobject
	     */
	    public Metadata getData()
	    {
    //		QMutexLocker locker(mutex);
		    return parentMetadata;
	    }


	

        }
    }
