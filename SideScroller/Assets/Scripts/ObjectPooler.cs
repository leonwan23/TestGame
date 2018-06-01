using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    //public GameObject pooledPlatformObject;

    public int pooledAmount;

    List<GameObject> pooledObjectList;

	// Use this for initialization
	void Start () {
        pooledObjectList = new List<GameObject>();

        for(int i =0; i<pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            //GameObject obj1 = (GameObject)Instantiate(pooledPlatformObject);
            obj.SetActive(false);
            //obj1.SetActive(false);
            pooledObjectList.Add(obj);
            //pooledObjectList.Add(obj1);
        }
	}
	
    public GameObject getPooledObject()
    {
        for(int i=0; i < pooledObjectList.Count; i++)
        {
            if (!pooledObjectList[i].activeInHierarchy)
            {
                return pooledObjectList[i];
            }
            
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjectList.Add(obj);

        return obj;
    }
}
