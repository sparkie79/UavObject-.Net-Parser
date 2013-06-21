using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public class UAVObjectFieldDescription {
	    private String unit;
	    private String name;
	    private byte type;
		
	    public const byte FIELDTYPE_INT8 = 0;
	    public const byte FIELDTYPE_INT16 = 1;
        public const byte FIELDTYPE_INT32 = 2;
        public const byte FIELDTYPE_UINT8 = 3;
        public const byte FIELDTYPE_UINT16 = 4;
        public const byte FIELDTYPE_UINT32 = 5;
        public const byte FIELDTYPE_FLOAT32 = 6;
        public const byte FIELDTYPE_ENUM = 7;

	    private int objid;
	    private byte fieldid;
	
	    private String[] enumOptions=new String[] {};
	    private String[] elementNames;

	    /**
	     * @param name - the fields name
	     * @param unit - the unit in which the fields value is
	     * @param enumOptions - if field is enumeration - here are the options - otherwise null
	     * @param elementNames - if field is array - here are the names for the elements
	     */
	    public UAVObjectFieldDescription(String name,int objid,byte fieldid,byte type,String unit,String[] enumOptions,String[] elementNames) {
		    this.name=name;
		    this.unit=unit;
		    this.enumOptions=enumOptions;
		    this.elementNames=elementNames;
		    this.objid=objid;
		    this.fieldid=fieldid;
		    this.type=type;
	    }
	
	    public String getUnit() {
		    return unit;
	    }
	    public String getName() {
		    return name;
	    }
	    public String[] getEnumOptions() {
		    return enumOptions;
	    }
	    public String[] getElementNames() {
		    return elementNames;
	    }

	    public int getObjId() {
		    return objid;
	    }
	
	    public byte getFieldId() {
		    return fieldid;
	    }

	    public byte getType() {
		    return type;
	    }
	
    }
}
