using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSpawner : BaseWeapons
{
    [SerializeField] GameObject scythe;
    [SerializeField] SimpleObjectPool pool;

    void Start()
    {
        StartCoroutine(SpawnScytheCoroutine());
    }

    IEnumerator SpawnScytheCoroutine()
    {
       while (true)
      {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < level; i++)
            {


                float angle = Random.Range(0, 360);
                //nstantiate(scythe, transform.position, Quaternion.Euler(0, 0, angle));
                var scythe = pool.GetObject();
                scythe.transform.position = transform.position;
                scythe.transform.rotation = Quaternion.Euler(0, 0, angle);
                scythe.SetActive(true);

            }
       }

    }
}