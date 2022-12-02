using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] GameObject scythePrefab;
    [SerializeField] GameObject bigHpPrefab;
    [SerializeField] GameObject smallHpPrefab;
    [SerializeField] GameObject superCrystalPrefab;
    List<GameObject> pooledObjects = new List<GameObject>();
    int objectIndex;

    private void Awake()
    {
        for (int i = 0; i < 1000; i++)
        {
            pooledObjects.Add(Instantiate(scythePrefab));
            pooledObjects.Add(Instantiate(bigHpPrefab));
            pooledObjects.Add(Instantiate(smallHpPrefab));
            pooledObjects.Add(Instantiate(superCrystalPrefab));
        }
    }

    public GameObject GetObject()
    {
        objectIndex %= pooledObjects.Count;
        return pooledObjects[objectIndex++];
    }
}
