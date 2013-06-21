using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using UavTalk.enums;
using System.Runtime.InteropServices;

namespace UavTalk
{
    public abstract class UAVObjectField
    {
        public abstract int getNumBytes();
        public abstract void setValue(Object data) ;
        public abstract void setValue(Object data, int index);
        public abstract String getName();
        public abstract void initialize(UAVObject obj);
        public abstract int pack(ByteBuffer dataOut);
        public abstract int unpack(ByteBuffer dataIn);
        public abstract Object getValue();
        public abstract Object getValue(int index);
        
        public UAVObject parent;
        protected int numElements;

        public int getNumElements()
        {
            return numElements;
        }
    }

    public class UAVObjectField<T> : UAVObjectField where T : struct
    {
        private String name;
	    private String units;
	    private FieldType type;
	    private List<String> elementNames;
	    private List<String> options;
        
        private int numBytesPerElement;
        private int offset;
        private UAVObject obj;
        public List<T> data { get; set; }
        
        public enum FieldType { INT8, INT16, INT32, UINT8, UINT16, UINT32, FLOAT32, ENUM, BITFIELD, STRING };
        Dictionary<FieldType, Type> fieldTypes;

        public UAVObjectField(String name, String units, int numElements, List<String> options, UAVObject parent) {
            List<String> elementNames = new List<String>();
            // Set element names
            for (int n = 0; n < numElements; ++n)
            {
                elementNames.Add(n.ToString());
            }
            // Initialize
            this.parent = parent;
            constructorInitialize(name, units, type, elementNames, options);
        }

        public UAVObjectField(String name, String units, List<String> elementNames, List<String> options, UAVObject parent)
        {
            this.parent = parent;
    	    constructorInitialize(name, units, type, elementNames, options);
        }

        public override void initialize(UAVObject obj){
             this.obj = obj;
            //clear();
	    }

        public UAVObject getObject() {
    	    return obj;
        }

        public FieldType getType() {
    	    return type;
        }

        public String getTypeAsString() {
            switch (type)
            {
                case FieldType.INT8:
                    return "int8";
                case FieldType.INT16:
                    return "int16";
                case FieldType.INT32:
                    return "int32";
                case FieldType.UINT8:
                    return "uint8";
                case FieldType.UINT16:
                    return "uint16";
                case FieldType.UINT32:
                    return "uint32";
                case FieldType.FLOAT32:
                    return "float32";
                case FieldType.ENUM:
                    return "enum";
                case FieldType.BITFIELD:
            	    return "bitfield";
                case FieldType.STRING:
                    return "string";
                default:
                    return "";
            }
        }

        public override String getName() {
    	    return name;
        }

        public String getUnits() {
    	    return units;
        }

        
        public override int getNumBytes()
        {
            return numBytesPerElement * numElements;
        }

        public List<String> getElementNames() {
    	    return elementNames;
        }

        public List<String> getOptions() {
    	    return options;
        }

        /**
         * This function copies this field from the internal storage of the parent object
         * to a new ByteBuffer for UavTalk.  It also converts from the java standard (big endian)
         * to the arm/uavtalk standard (little endian)
         * @param dataOut
         * @return the number of bytes added
         **/
    
	    public override int pack(ByteBuffer dataOut) {
            // Pack each element in output buffer
            for (int index = 0; index < numElements; ++index) {
                dataOut.put<T>(getValue(index));
            }
           
            
            // Done
            return getNumBytes();
        }

	    public override int unpack(ByteBuffer dataIn) {
            for (int index = 0; index < numElements; index++)
                ((List<T>)data)[index] = dataIn.get<T>();
            return getNumBytes();
        }

        /*
        public Object getValue()  { return getValue(0); };
        @SuppressWarnings("unchecked")
	    public synchronized Object getValue(int index)  {
            // Check that index is not out of bounds
            if ( index >= numElements )
            {
                return null;
            }

            switch (type)
            {
                case INT8:
            	    return ((List<Byte>) data).get(index).intValue();
                case INT16:
            	    return ((List<Short>) data).get(index).intValue();
                case INT32:
            	    return ((List<Integer>) data).get(index).intValue();
                case UINT8:
            	    return ((List<Short>) data).get(index).intValue();
                case UINT16:
            	    return ((List<Integer>) data).get(index).intValue();
                case UINT32:
            	    return ((List<Long>) data).get(index);
                case FLOAT32:
            	    return ((List<Float>) data).get(index);
                case ENUM:
                {
            	    List<Byte> l = (List<Byte>) data;
            	    Byte val = l.get(index);

                    //if(val >= options.size() || val < 0)
                    //	throw new Exception("Invalid value for" + name);

                    return options.get(val);
                }
                case BITFIELD:
            	    return ((List<Short>) data).get(index).intValue();

                case STRING:
                {
            	    //throw new Exception("Shit I should do this");
                }
            }
            // If this point is reached then we got an invalid type
            return null;
        }
        */
        public override void setValue(Object data) { setValue(data,0); }

        public override void setValue(object data, int index)
        {
            if (!(data is T))
                throw new ArgumentException();
            setValue((T)data, index);
        }

	    public void setValue(T data, int index) {
    	    // Check that index is not out of bounds
    	    if ( index >= numElements )
                throw new ArgumentOutOfRangeException();
            
            T val = (T)data;
    	    // Get metadata
    	    Metadata mdata = obj.getMetadata();
    	    // Update value if the access mode permits
    	    if ( mdata.GetGcsAccess() == AccessMode.ACCESS_READWRITE )
    	    {
                this.data[index] = val;
    		    //obj.updated();
    	    }
        }
        /*
        public double getDouble() { return getDouble(0); };
        @SuppressWarnings("unchecked")
	    public double getDouble(int index) {
    	    switch (type) {
    	    case ENUM:
    		    return ((List<Byte>)data).get(index);
    	    default:
    		    break;
    	    }
    	    return ((Number) getValue(index)).doubleValue();
        }

        public void setDouble(double value) { setDouble(value, 0); };
        public void setDouble(double value, int index) {
    	    setValue(value, index);
        }

        public int getDataOffset() {
    	    return offset;
        }

        public int getNumBytes() {
            return numBytesPerElement * numElements;
        }

        public int getNumBytesElement() {
    	    return numBytesPerElement;
        }
        */
        public bool isNumeric() {
            switch (type)
            {
                case FieldType.INT8:
                    return true;
                case FieldType.INT16:
                    return true;
                case FieldType.INT32:
                    return true;
                case FieldType.UINT8:
                    return true;
                case FieldType.UINT16:
                    return true;
                case FieldType.UINT32:
                    return true;
                case FieldType.FLOAT32:
                    return true;
                case FieldType.ENUM:
                    return false;
                case FieldType.BITFIELD:
                    return true;
                case FieldType.STRING:
                    return false;
                default:
                    return false;
            }
        }

        public bool isText() {
            switch (type)
            {
                case FieldType.INT8:
                    return false;
                case FieldType.INT16:
                    return false;
                case FieldType.INT32:
                    return false;
                case FieldType.UINT8:
                    return false;
                case FieldType.UINT16:
                    return false;
                case FieldType.UINT32:
                    return false;
                case FieldType.FLOAT32:
                    return false;
                case FieldType.ENUM:
                    return true;
                case FieldType.BITFIELD:
                    return false;
                case FieldType.STRING:
                    return true;
                default:
                    return false;
            }
        }
        /*
	    @Override
	    public String toString() {
            String sout = new String();
            sout += name + ": ";
            for (int i = 0; i < numElements; i++) {
        	    sout += getValue(i).toString();
        	    if (i != numElements-1)
        		    sout += ", ";
        	    else
        		    sout += " ";
            }
    	    if (units.length() > 0)
    		    sout += " (" + units + ")\n";
    	    else
    		    sout += "\n";
            return sout;
        }

        void fieldUpdated(UAVObjectField field) {

        }
        */
        
	    public void clear() {
            data.Clear();
            for(int index = 0; index < numElements; ++index) 
                data.Add(default(T));
        }

        
        public void constructorInitialize(String name, String units, FieldType type, List<String> elementNames, List<String> options) {
            // Copy params
            this.name = name;
            this.units = units;
            this.type = type;
            this.options = options;
            this.numElements = elementNames.Count();
            this.offset = 0;
            this.data = null;
            this.obj = null;
            this.elementNames = elementNames;
            fieldTypes = new Dictionary<FieldType, Type>();
            fieldTypes.Add(FieldType.INT8, typeof(sbyte));
            // Set field size
            data = new List<T>(numElements);
            if (typeof(T).Name.EndsWith("UavEnum"))
            {
                numBytesPerElement = 1;
            }
            else
            {
                T tmp = default(T);
                numBytesPerElement = Marshal.SizeOf(tmp);
                if (typeof(T) == typeof(Uenum))
                    numBytesPerElement = 1;
                else if (typeof(T) == typeof(BitField))
                    numBytesPerElement = 1;
                else if (typeof(T) == typeof(String))
                    numBytesPerElement = 1;
                else if (typeof(T) == typeof(Boolean))
                    numBytesPerElement = 1;
            }
            clear();
        }


        public override Object getValue()  { return getValue(0); }
	    public override Object getValue(int index)  {
            lock(this)
            {
                // Check that index is not out of bounds
                if ( index >= numElements )
                    throw new ArgumentOutOfRangeException();
                return data[index];   
            }
        }

        public UAVObjectField clone()
        {
    	    UAVObjectField<T> newField = new UAVObjectField<T>(name, units, 
    			    new List<String>(elementNames),
    			    new List<String>(options), parent);
    	    newField.initialize(obj);
    	    newField.data = data;
		    return newField;
        }

    }
}
