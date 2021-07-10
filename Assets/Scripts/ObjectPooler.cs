using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum ObjectType{
	gombaEnemy =  0,
	greenEnemy =  1
}

[System.Serializable]
public  class ObjectPoolItem
{
	public  int amount;
	public  GameObject prefab;
	public  bool expandPool;
	public  ObjectType type;
}

public  class ExistingPoolItem
{
	public  GameObject gameObject;
	public  ObjectType type;

	// constructor
	public  ExistingPoolItem(GameObject gameObject, ObjectType type){
		// reference input
		this.gameObject  =  gameObject;
		this.type  =  type;
	}
}


public class ObjectPooler : Singleton<ObjectPooler>
{

    public static ObjectPooler SharedInstance;
    public  List<ObjectPoolItem> itemsToPool; // types of different object to pool
    public  List<ExistingPoolItem> pooledObjects; // a list of all objects in the pool, of all types

    override public void Awake()
    {
        base.Awake();
        SharedInstance = this;
        pooledObjects  =  new  List<ExistingPoolItem>();
        Debug.Log("ObjectPooler Awake");

        foreach (ObjectPoolItem item in  itemsToPool)
        {   
            Debug.Log("ObjectPooler Awake (foreach):" + item.prefab);
            for (int i =  0; i  <  item.amount; i++)
            {
                
                // this 'pickup' a local variable, but Unity will not remove it since it exists in the scene
                GameObject pickup = (GameObject)Instantiate(item.prefab);
                pickup.SetActive(false);
                pickup.transform.parent  =  this.transform;
                //ExistingPoolItem e =  new  ExistingPoolItem(pickup, item.type);
                pooledObjects.Add(new  ExistingPoolItem(pickup, item.type));
                Debug.Log("ObjectPooler Awake (item.prefab):" + item.prefab);
                Debug.Log("ObjectPooler Awake (pickup):" + pickup);
                Debug.Log("ObjectPooler Awake (pooledObjects[i].type):" + pooledObjects[i].type);
                Debug.Log("ObjectPooler Awake (for):" + i);
                Debug.Log("ObjectPooler Awake (pooledObjects):" + pooledObjects.Count);
            }
        }
        foreach (ExistingPoolItem item in pooledObjects){Debug.Log("pooledObjects:" + item.type);};
    }

    // override  public  void  Awake(){
	// 	base.Awake();
	// 	// Debug.Log("awake called");
	// 	// other instructions...
	// }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    public  GameObject  GetPooledObject(ObjectType type)
    {   
        Debug.Log("GetPooledObject Called!");
        // return inactive pooled object if it matches the type
        for (int i =  0; i  <  pooledObjects.Count; i++)
        {   
            Debug.Log("GetPooledObject In For Loop: i:" + i); 
            Debug.Log("GetPooledObject In For Loop: !pooledObjects[i].gameObject.activeInHierarchy:" + !pooledObjects[i].gameObject.activeInHierarchy); 
            Debug.Log("GetPooledObject In For Loop: pooledObjects[i].type:" + pooledObjects[i].type); 
            Debug.Log("GetPooledObject In For Loop: type:" + type); 
            if (!pooledObjects[i].gameObject.activeInHierarchy  &&  pooledObjects[i].type  ==  type)
            {
                Debug.Log("GetPooledObject return inactive pooled object of type");
                return  pooledObjects[i].gameObject;
            }
        }

        // this will be called when no more active object is present, item to expand pool if required
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.type == type)
            {
                if (item.expandPool)
                {
                    Debug.Log("GetPooledObject if expandPool is True");
                    GameObject pickup = (GameObject)Instantiate(item.prefab);
                    pickup.SetActive(false);
                    pickup.transform.parent  =  this.transform;
                    pooledObjects.Add(new  ExistingPoolItem(pickup, item.type));
                    return  pickup;
                }
            }
        }

        return null;
    }

}
