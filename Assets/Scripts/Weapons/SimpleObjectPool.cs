using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] GameObject snowPrefab;
  
    List<GameObject> pooledObjects = new List<GameObject>();
    int objectIndex;

    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            pooledObjects.Add(Instantiate(snowPrefab));
            
        }
    }

    public GameObject GetObject()
    {
        objectIndex %= pooledObjects.Count;
        return pooledObjects[objectIndex++];
    }
}
