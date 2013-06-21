using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public class UAVDataObject : UAVObject
    {
        private UAVMetaObject mobj;
        private bool isSet;

        /**
	 * @brief Constructor for UAVDataObject
	 * @param objID the object id to be created
	 * @param isSingleInst
	 * @param isSet
	 * @param name
	 */
	public UAVDataObject(long objID, Boolean isSingleInst, Boolean isSet, String name) : base(objID, isSingleInst, name) {
        float.Parse("1", CultureInfo.InvariantCulture);
		mobj = null;
		this.isSet = isSet;
	}
	/**
	 * Initialize instance ID and assign a metaobject
	 */
	public void initialize(long instID, UAVMetaObject mobj)
	{
	    //QMutexLocker locker(mutex);
	    this.mobj = mobj;
	    base.initialize(instID);
	}

	
	public override bool isMetadata() { return false; }
	/**
	 * Assign a metaobject
	 */
	public void initialize(UAVMetaObject mobj)
	{
	    //QMutexLocker locker(mutex);
	    this.mobj = mobj;
	}


    public override Metadata getDefaultMetadata()
    {
        throw new NotImplementedException();
    }

	/**
	 * Returns true if this is a data object holding module settings
	 */
	public bool isSettings()
	{
	    return isSet;
	}

	/**
	 * Set the object's metadata
	 */

	public override void setMetadata(Metadata mdata)
	{
	    if ( mobj != null )
	    {
	        mobj.setData(mdata);
	    }
	}

	/**
	 * Get the object's metadata
	 */
	public override Metadata getMetadata()
	{
	    if ( mobj != null)
	    {
	        return mobj.getData();
	    }
	    else
	    {
	        return getDefaultMetadata();
	    }
	}

	/**
	 * Get the metaobject
	 */
	public UAVMetaObject getMetaObject()
	{
	    return mobj;
	}

    // TODO: Make abstract
    public virtual UAVDataObject clone(long instID) {
		return (UAVDataObject) base.clone();
    }

   
    }
}
