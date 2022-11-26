using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject merman;
    [SerializeField] GameObject runner;
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject vampire;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Giant;
    [SerializeField] GameObject smallhp;
    [SerializeField] GameObject bighp;
    [SerializeField] GameObject SuperCrystal;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] GameObject Player3;

    private void Awake()
    {
        if (HeroManger.playerIndex == 1)
        {
            Player1.SetActive(true);
        }
        else if (HeroManger.playerIndex == 2)
        {
            Player2.SetActive(true);
        }
        else if (HeroManger.playerIndex == 3)
        {
            Player3.SetActive(true);
        }
        
    }
    private void Start()
    {
        StartCoroutine(SpawnCoroutineItems());
        StartCoroutine(SpawnCoroutineEnemy());
        StartCoroutine(Spawnboss(Boss,1));


    }

    private void Update()
    {
        int seconds = (int)Time.time;

        timerText.text = seconds.ToString();
        int minutes = seconds / 60;

        if (minutes >= 1)
        {
            seconds -= minutes * 60;
        }
        if (seconds < 10 && minutes < 10)
        {
            timerText.text = "0" + minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (seconds < 10)
        {
            timerText.text = minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (minutes < 10)
        {
            timerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }
    }

    private IEnumerator SpawnCoroutineEnemy()
    {

       
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnEnemies(Giant, 2);
            //SpawnEnemies(merman, 10);
            //SpawnEnemies(zombie, 10);
            //yield return new WaitForSeconds(10f);
            //SpawnEnemies(vampire, 10);
            //yield return new WaitForSeconds(10f);
            //SpawnEnemies(runner, 3, false);
            //yield return new WaitForSeconds(10f);
            //SpawnEnemies(merman, 15);
            //SpawnEnemies(zombie, 7);
            //yield return new WaitForSeconds(20f);
            //SpawnEnemies(merman, 15);
            //SpawnEnemies(vampire, 10);
            //yield return new WaitForSeconds(20f);
            //SpawnEnemies(merman, 15);
            //SpawnEnemies(zombie, 10);
            //yield return new WaitForSeconds(20f);
            //SpawnEnemies(zombie, 15);
            //SpawnEnemies(vampire, 10);
            //yield return new WaitForSeconds(20f);
            //SpawnEnemies(zombie, 30);
            //SpawnEnemies(runner, 7, false);
            //yield return new WaitForSeconds(20f);
            //SpawnEnemies(vampire, 40);
            //SpawnEnemies(runner, 10, false);
            //SpawnEnemies(merman, 30);
            //yield return new WaitForSeconds(30f);
            //SpawnEnemies(merman, 30);
            //SpawnEnemies(zombie, 20);
            //SpawnEnemies(vampire, 20);
            //yield return new WaitForSeconds(30f);
            //SpawnEnemies(merman, 50);
            //SpawnEnemies(vampire, 40);
            //yield return new WaitForSeconds(40f);
            //SpawnEnemies(vampire, 50);
            //SpawnEnemies(zombie, 40);
            //yield return new WaitForSeconds(40f);
            //SpawnEnemies(zombie, 50);
            //SpawnEnemies(merman, 50);
            //SpawnEnemies(vampire, 50);
            //yield return new WaitForSeconds(25f);


        }

    }
    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTracking = true)
    {
        if (player != null)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
                if (!isTracking)
                {
                    spawnPosition = new Vector3(-10, 0, 0);
                }
                spawnPosition += player.transform.position;
                GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                Enemy enemy = enemyObject.GetComponent<Enemy>();
                enemy.isTrackingPlayer = isTracking;

            }
        }
    }
    IEnumerator Spawnboss(GameObject bossEnemy, int numberOfBosses, bool isTracking = true)
    {
        while (true)
        {
            for (int i = 0; i < numberOfBosses; i++)
            {
                yield return new WaitForSeconds(300f);
                Vector3 bossSpawn = Random.insideUnitCircle.normalized * 10;
                bossSpawn += player.transform.position;
                GameObject enemyobject = Instantiate(bossEnemy, bossSpawn, Quaternion.identity);
                Enemy enemy = enemyobject.GetComponent<Enemy>();
                enemy.isTrackingPlayer = isTracking;

            }
        }
    }

    private IEnumerator SpawnCoroutineItems()
    {
        while (true)
        {
            Vector3 randomPosition = Random.insideUnitCircle.normalized * 5;
            yield return new WaitForSeconds(10f);
            Instantiate(smallhp, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(10f);
            Instantiate(bighp, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(SuperCrystal,randomPosition, Quaternion.identity);
        }
    }



}