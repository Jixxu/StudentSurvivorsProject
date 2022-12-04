using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSpawner : BaseWeapons
{
    [SerializeField] GameObject snowBall;
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
                //instantiate(scythe, transform.position, Quaternion.Euler(0, 0, angle));
                var snowBall = pool.GetObject();
                snowBall.transform.position = transform.position;
                snowBall.transform.rotation = Quaternion.Euler(0, 0, angle);
                snowBall.SetActive(true);

            }
       }

    }
}