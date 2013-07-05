using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UavTalk
{
    public class UAVObjectManager
    {
        /*public class CallbackListener extends Observable {
		public void event (UAVObject obj) {
			    setChanged();
			    notifyObservers(obj);
		    }
	    }
	    private final CallbackListener newInstance = new CallbackListener();
	    public void addNewInstanceObserver(Observer o) {
		    synchronized(newInstance) {
			    newInstance.addObserver(o);
		    }
	    }
	    private final CallbackListener newObject = new CallbackListener();
	    public void addNewObjectObserver(Observer o) {
		    synchronized(newObject) {
			    newObject.addObserver(o);
		    }
	    }*/
	    private const int MAX_INSTANCES = 10;

	    // Use array list to store objects since rarely added or deleted
	    private List<List<UAVObject>> objects = new List<List<UAVObject>>();

        public delegate void NewInstanceDelegate(UAVObject obj);
        public event NewInstanceDelegate onNewInstance;

	    public UAVObjectManager()
	    {
		    //mutex = new QMutex(QMutex::Recursive);
	    }

	    /**
	     * Register an object with the manager. This function must be called for all newly created instances.
	     * A new instance can be created directly by instantiating a new object or by calling clone() of
	     * an existing object. The object will be registered and will be properly initialized so that it can accept
	     * updates.
	     * @throws Exception
	     */
	    public bool registerObject(UAVDataObject obj)
	    {
		    // Check if this object type is already in the list
            foreach(var instList in objects)
            {
			    // Check if the object ID is in the list
			    if( (instList.Count() > 0) && (instList.ElementAt(0).getObjID() == obj.getObjID() )) {
				    // Check if this is a single instance object, if yes we can not add a new instance
				    if(obj.isSingleInstance()) {
					    return false;
				    }
				    // The object type has alredy been added, so now we need to initialize the new instance with the appropriate id
				    // There is a single metaobject for all object instances of this type, so no need to create a new one
				    // Get object type metaobject from existing instance
				    UAVDataObject refObj = (UAVDataObject) instList.ElementAt(0);
				    if (refObj == null)
				    {
					    return false;
				    }
				    UAVMetaObject mobj = refObj.getMetaObject();

				    // Make sure we aren't requesting to create too many instances
				    if(obj.getInstID() >= MAX_INSTANCES || instList.Count() >= MAX_INSTANCES || obj.getInstID() < 0) {
					    return false;
				    }

				    // If InstID is zero then we find the next open instId and create it
				    if (obj.getInstID() == 0)
				    {
					    // Assign the next available ID and initialize the object instance the nadd
					    obj.initialize(instList.Count(), mobj);
					    instList.Add(obj);
					    return true;
				    }

				    // Check if that inst ID already exists
                    if(instList.Any(j=>j.getObjID() == obj.getObjID()))
                        return false;
				    
				    // If the instance ID is specified and not at the default value (0) then we need to make sure
				    // that there are no gaps in the instance list. If gaps are found then then additional instances
				    // will be created.
				    for(long instId = instList.Count(); instId < obj.getInstID(); instId++) {
					    UAVDataObject newObj = obj.clone(instId);
					    newObj.initialize(mobj);
					    instList.Add(newObj);
					    if(onNewInstance != null)
                            onNewInstance(newObj);
				    }
                    
				    obj.initialize(mobj);
				    instList.Add(obj);
                    if(onNewInstance != null)
                            onNewInstance(obj);
				    
                    if(instList.Any(j=>j.getObjID() == obj.getObjID()))
                        return false;
                    
				    // Check if there are any gaps between the requested instance ID and the ones in the list,
				    // if any then create the missing instances.
				    for (long instId = instList.Count(); instId < obj.getInstID(); ++instId)
				    {
					    UAVDataObject cobj = obj.clone(instId);
					    cobj.initialize(mobj);
					    instList.Add(cobj);
					    if(onNewInstance != null)
                            onNewInstance(cobj);
				    }

				    // Finally, initialize the actual object instance
				    obj.initialize(mobj);
				    // Add the actual object instance in the list
				    instList.Add(obj);
				    if(onNewInstance != null)
                            onNewInstance(obj);
				    return true;
			    }

		    }

		    // If this point is reached then this is the first time this object type (ID) is added in the list
		    // create a new list of the instances, add in the object collection and create the object's metaobject
		    // Create metaobject
		    String mname = obj.getName();
		    mname += "Meta";

		    UAVMetaObject bmobj = new UAVMetaObject(obj.getObjID()+1, mname, obj);
		    // Initialize object
		    obj.initialize(0, bmobj);
		    // Add to list
		    addObject(obj);
		    addObject(bmobj);
		    return true;
	    }

	    public void addObject(UAVObject obj)
	    {
		    // Add to list
		    List<UAVObject> ls = new List<UAVObject>();
		    ls.Add(obj);
		    objects.Add(ls);
		    if(onNewInstance != null)
                onNewInstance(obj);
	    }

	    /**
	     * Get all objects. A two dimentional QList is returned. Objects are grouped by
	     * instances of the same object type.
	     */
	    public List<List<UAVObject>> getObjects()
	    {
		    return objects;
	    }

	    /**
	     * Same as getObjects() but will only return DataObjects.
	     */
	    public List< List<UAVDataObject> > getDataObjects()
	    {
		    List< List<UAVDataObject> > dObjects = new List< List<UAVDataObject> > ();

            foreach(var instList in objects)
            {
			    // If no instances skip
			    if(instList.Count() == 0)
				    continue;

			    // If meta data skip
			    if(instList.ElementAt(0).isMetadata())
				    continue;

			    List<UAVDataObject> newInstList = new List<UAVDataObject>();
                foreach(var instIt in instList)
                {
				    newInstList.Add((UAVDataObject) instIt);
			    }
			    dObjects.Add(newInstList);
		    }
		    // Done
		    return dObjects;
	    }

	    /**
	     * Same as getObjects() but will only return MetaObjects.
	     */
	    public List <List<UAVMetaObject> > getMetaObjects()
	    {
		    List< List<UAVMetaObject> > mObjects = new List< List<UAVMetaObject> > ();

            foreach(var instList in objects)
            {
			    // If no instances skip
			    if(instList.Count() == 0)
				    continue;

			    // If meta data skip
			    if(!instList.ElementAt(0).isMetadata())
				    continue;

			    List<UAVMetaObject> newInstList = new List<UAVMetaObject>();
                foreach(var instIt in instList)
                {
				    newInstList.Add((UAVMetaObject) instIt);
			    }
			    mObjects.Add(newInstList);
		    }
		    // Done
		    return mObjects;
	    }


        public T getObject<T>() where T : UAVObject
        {
            return (T)getObject(typeof(T).Name, 0, 0);
        }

	    /**
	     * Returns a specific object by name only, returns instance ID zero
	     * @param name The object name
	     * @return The object or null if not found
	     */
	    public UAVObject getObject(String name)
	    {
		    return getObject(name, 0, 0);
	    }

        public UAVObject getObject(Type type)
        {
            return getObject(type.Name, 0, 0);
        }

	    /**
	     * Get a specific object given its name and instance ID
	     * @returns The object is found or NULL if not
	     */
	    public UAVObject getObject(String name, long instId)
	    {
		    return getObject(name, 0, instId);
	    }

	    /**
	     * Get a specific object with given object ID and instance ID zero
	     * @param objId the object id
	     * @returns The object is found or NULL if not
	     */
	    public UAVObject getObject(long objId)
	    {
		    return getObject(null, objId, 0);
	    }

	    /**
	     * Get a specific object given its object and instance ID
	     * @returns The object is found or NULL if not
	     */
	    public UAVObject getObject(long objId, long instId)
	    {
		    return getObject(null, objId, instId);
	    }

	    /**
	     * Helper function for the public getObject() functions.
	     */
	    public UAVObject getObject(String name, long objId, long instId)
	    {
		    // Check if this object type is already in the list
            foreach(var instList in objects)
            {
			    if (instList.Count() > 0) {
				    if ( (name != null && instList.ElementAt(0).getName() == name) || (name == null && instList.ElementAt(0).getObjID() == objId) ) {
					    // Look for the requested instance ID
                        return instList.FirstOrDefault(j => j.getInstID() == instId);
				    }
			    }
		    }

		    return null;
	    }

	    /**
	     * Get all the instances of the object specified by name
	     */
	    public List<UAVObject> getObjectInstances(String name)
	    {
		    return getObjectInstances(name, 0);
	    }

	    /**
	     * Get all the instances of the object specified by its ID
	     */
	    public List<UAVObject> getObjectInstances(long objId)
	    {
		    return getObjectInstances(null, objId);
	    }

	    /**
	     * Helper function for the public getObjectInstances()
	     */
	    public List<UAVObject> getObjectInstances(String name, long objId)
	    {
		    // Check if this object type is already in the list
            foreach(var instList in objects)
            {
			    if (instList.Count() > 0) {
				    if ( (name != null && instList.ElementAt(0).getName() == name) || (name == null && instList.ElementAt(0).getObjID() == objId) ) {
					    return instList;
				    }
			    }
		    }

		    return null;
	    }

	    /**
	     * Get the number of instances for an object given its name
	     */
	    public int getNumInstances(String name)
	    {
		    return getNumInstances(name, 0);
	    }

	    /**
	     * Get the number of instances for an object given its ID
	     */
	    public int getNumInstances(long objId)
	    {
		    return getNumInstances(null, objId);
	    }

	    /**
	     * Helper function for public getNumInstances
	     */
	    public int getNumInstances(String name, long objId)
	    {
		    return getObjectInstances(name,objId).Count();
	    }

    }
}
