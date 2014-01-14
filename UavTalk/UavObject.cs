using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UavTalk
{
public abstract class UAVObject 
{
	public abstract bool isMetadata();

	/**
	 * Object update mode
	 */
	public enum UPDATEMODE {
		UPDATEMODE_MANUAL,   /** Manually update object, by calling the updated() function */
		UPDATEMODE_PERIODIC, /** Automatically update object at periodic intervals */
		UPDATEMODE_ONCHANGE, /** Only update object when its data changes */
        UPDATEMODE_THROTTLED, /** Only update object when its data changes */
	};

	/**
	 * Access mode
	 */
	public enum AccessMode {
		ACCESS_READWRITE = 1, ACCESS_READONLY = 0
	};


    public bool isClone { get;set;}
    public  long objID { get; set; }
    public  long instID { get; set; }
    public  bool isSingleInst { get; set; }
    public  string name { get; set; }
    public  int numBytes { get; set; }
    public  string description { get; set; }
    public UInt32 timestamp { get; set; }
    private List<UAVObjectField> fields;

    public event EventHandler onUpdated;
	
	public UAVObject(long objID, bool isSingleInst, string name) {
		this.objID = objID;
		this.instID = 0;
		this.isSingleInst = isSingleInst;
		this.name = name;
		// this.mutex = new QMutex(QMutex::Recursive);
	}

	public void initialize(long instID) {
		this.instID = instID;
	}

	/**
	 * Initialize objects' data fields
	 *
	 * @param fields
	 *            List of fields held by the object
	 * @param data
	 *            Pointer to that actual object data, this is needed by the
	 *            fields to access the data
	 * @param numBytes
	 *            Number of bytes in the object (total, including all fields)
	 * @throws Exception
	 *             When unable to unpack a field
	 */
	public void initializeFields(List<UAVObjectField> fields, ByteBuffer data,
			int numBytes) {
		this.numBytes = numBytes;
		this.fields = fields;
		// Initialize fields
		for (int n = 0; n < fields.Count(); ++n) {
			this.fields.ElementAt(n).initialize(this);
		}
		unpack(data);
	}

	/**
	 * Get the object ID
	 */
	public long getObjID() {
		return objID;
	}

	/**
	 * Get the instance ID
	 */
	public long getInstID() {
		return instID;
	}

	/**
	 * Returns true if this is a single instance object
	 */
	public bool isSingleInstance() {
		return isSingleInst;
	}

	/**
	 * Get the name of the object
	 */
	public string getName() {
		return name;
	}

	/**
	 * Get the description of the object
	 *
	 * @return The description of the object
	 */
	public string getDescription() {
		return description;
	}

	/**
	 * Set the description of the object
	 *
	 * @param The
	 *            description of the object
	 * @return
	 */
	public void setDescription(string description) {
		this.description = description;
	}

	/**
	 * Get the total number of bytes of the object's data
	 */
	public int getNumBytes() {
		return numBytes;
	}

	// /**
	// * Request that this object is updated with the latest values from the
	// autopilot
	// */
	// /* void UAVObject::requestUpdate()
	// {
	// emit updateRequested(this);
	// } */
	//
	// /**
	// * Signal that the object has been updated
	// */
	// /* void UAVObject::updated()
	// {
	// emit objectUpdatedManual(this);
	// emit objectUpdated(this);
	// } */
	//
	// /**
	// * Lock mutex of this object
	// */
	// /* void UAVObject::lock()
	// {
	// mutex->lock();
	// } */
	//
	// /**
	// * Lock mutex of this object
	// */
	// /* void UAVObject::lock(int timeoutMs)
	// {
	// mutex->tryLock(timeoutMs);
	// } */
	//
	// /**
	// * Unlock mutex of this object
	// */
	// /* void UAVObject::unlock()
	// {
	// mutex->unlock();
	// } */
	//
	// /**
	// * Get object's mutex
	// */
	// QMutex* UAVObject::getMutex()
	// {
	// return mutex;
	// }

	/**
	 * Get the number of fields held by this object
	 */
	public int getNumFields() {
		return fields.Count();
	}

	/**
	 * Get the object's fields
	 */
	public List<UAVObjectField> getFields() {
		return fields;
    }
   
	/**
	 * Get a specific field
	 *
	 * @throws Exception
	 * @returns The field or NULL if not found
	 */
	public UAVObjectField getField(String name) {
		// Look for field
        return fields.FirstOrDefault(j => j.getName() == name);
	}

	/**
	 * Pack the object data into a byte array
	 *
	 * @param dataOut
	 *            ByteBuffer to receive the data.
	 * @throws Exception
	 * @returns The number of bytes copied
	 * @note The array must already have enough space allocated for the object
	 */
	public int pack(ByteBuffer dataOut){
		/*if (dataOut.) < getNumBytes())
			throw new Exception("Not enough bytes in ByteBuffer to pack object");*/
		int numBytes = 0;

        foreach (var field in fields)
        {
            numBytes += field.pack(dataOut);
        }

		return numBytes;
	}

	/**
	 * Unpack the object data from a byte array
	 *
	 * @param dataIn
	 *            The ByteBuffer to pull data from
	 * @throws Exception
	 * @returns The number of bytes copied
	 */
	public int unpack(ByteBuffer dataIn) {
		if( dataIn == null )
			return 0;

		// QMutexLocker locker(mutex);
		int numBytes = 0;
        foreach(var item in fields)
            numBytes += item.unpack(dataIn);

        if (onUpdated != null && !isClone)
            onUpdated(this, null);

		return numBytes;
	}

	// /**
	// * Save the object data to the file.
	// * The file will be created in the current directory
	// * and its name will be the same as the object with
	// * the .uavobj extension.
	// * @returns True on success, false on failure
	// */
	// bool UAVObject::save()
	// {
	// QMutexLocker locker(mutex);
	//
	// // Open file
	// QFile file(name + ".uavobj");
	// if (!file.open(QFile::WriteOnly))
	// {
	// return false;
	// }
	//
	// // Write object
	// if ( !save(file) )
	// {
	// return false;
	// }
	//
	// // Close file
	// file.close();
	// return true;
	// }
	//
	// /**
	// * Save the object data to the file.
	// * The file is expected to be already open for writting.
	// * The data will be appended and the file will not be closed.
	// * @returns True on success, false on failure
	// */
	// bool UAVObject::save(QFile& file)
	// {
	// QMutexLocker locker(mutex);
	// quint8 buffer[numBytes];
	// quint8 tmpId[4];
	//
	// // Write the object ID
	// qToLittleEndian<quint32>(objID, tmpId);
	// if ( file.write((const char*)tmpId, 4) == -1 )
	// {
	// return false;
	// }
	//
	// // Write the instance ID
	// if (!isSingleInst)
	// {
	// qToLittleEndian<quint16>(instID, tmpId);
	// if ( file.write((const char*)tmpId, 2) == -1 )
	// {
	// return false;
	// }
	// }
	//
	// // Write the data
	// pack(buffer);
	// if ( file.write((const char*)buffer, numBytes) == -1 )
	// {
	// return false;
	// }
	//
	// // Done
	// return true;
	// }
	//
	// /**
	// * Load the object data from a file.
	// * The file will be openned in the current directory
	// * and its name will be the same as the object with
	// * the .uavobj extension.
	// * @returns True on success, false on failure
	// */
	// bool UAVObject::load()
	// {
	// QMutexLocker locker(mutex);
	//
	// // Open file
	// QFile file(name + ".uavobj");
	// if (!file.open(QFile::ReadOnly))
	// {
	// return false;
	// }
	//
	// // Load object
	// if ( !load(file) )
	// {
	// return false;
	// }
	//
	// // Close file
	// file.close();
	// return true;
	// }
	//
	// /**
	// * Load the object data from file.
	// * The file is expected to be already open for reading.
	// * The data will be read and the file will not be closed.
	// * @returns True on success, false on failure
	// */
	// bool UAVObject::load(QFile& file)
	// {
	// QMutexLocker locker(mutex);
	// quint8 buffer[numBytes];
	// quint8 tmpId[4];
	//
	// // Read the object ID
	// if ( file.read((char*)tmpId, 4) != 4 )
	// {
	// return false;
	// }
	//
	// // Check that the IDs match
	// if (qFromLittleEndian<quint32>(tmpId) != objID)
	// {
	// return false;
	// }
	//
	// // Read the instance ID
	// if ( file.read((char*)tmpId, 2) != 2 )
	// {
	// return false;
	// }
	//
	// // Check that the IDs match
	// if (qFromLittleEndian<quint16>(tmpId) != instID)
	// {
	// return false;
	// }
	//
	// // Read and unpack the data
	// if ( file.read((char*)buffer, numBytes) != numBytes )
	// {
	// return false;
	// }
	// unpack(buffer);
	//
	// // Done
	// return true;
	// }

	/**
	 * Return a string with the object information
	 */
	public String toString() {
		return toStringBrief(); // + toStringData();
	}

	/**
	 * Return a string with the object information (only the header)
	 */
	public String toStringBrief() {
		return getName(); // + " (" + Integer.toHexString(getObjID()) + " " + Integer.toHexString(getInstID()) + " " + getNumBytes() + ")\n";
	}

	/**
	 * Return a string with the object information (only the data)
	 */
	public String toStringData() {
		String s = "";
		foreach(var field in fields)
        {
			s += field.ToString();
		}
		return s;
	}

	// /**
	// * Emit the transactionCompleted event (used by the UavTalk plugin)
	// */
	// void UAVObject::emitTransactionCompleted(bool success)
	// {
	// emit transactionCompleted(this, success);
	// }

	/**
	 * Java specific functions
	 */
	public UAVObject clone() {
        UAVObject newObj = (UAVObject)base.MemberwiseClone();
        newObj.isClone = true;
		List<UAVObjectField> newFields = new List<UAVObjectField>();
		foreach(var nf in fields)
        {
			nf.initialize(newObj);
			newFields.Add(nf);
		}
		newObj.initializeFields(newFields, new ByteBuffer(numBytes), numBytes);
		return newObj;
	}

	/**
	 * Abstract functions
	 */
	public abstract void setMetadata(Metadata mdata);

	public abstract Metadata getMetadata();

	public abstract Metadata getDefaultMetadata();

	/**
	 * Private data for the object, common to all
	 */
	
}
}