using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] GameObject scythePrefab;
  
    List<GameObject> pooledObjects = new List<GameObject>();
    int objectIndex;

    private void Awake()
    {
        for (int i = 0; i < 1000; i++)
        {
            pooledObjects.Add(Instantiate(scythePrefab));
            
        }
    }

    public GameObject GetObject()
    {
        objectIndex %= pooledObjects.Count;
        return pooledObjects[objectIndex++];
    }
}
