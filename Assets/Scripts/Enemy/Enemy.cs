using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject crystalPrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] public GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float enemyHp = 3f;
    public GameObject demon;
    
    public bool isTrackingPlayer = true;
    bool isInvincible;


    Color Originalcolor;
    

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Originalcolor = GetComponent<SpriteRenderer>().color;
        
        
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {


            if (player.ONdamage())
            {
                
            }
        }


    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Originalcolor;
        isInvincible = false;
    }
    internal void Damage(int damage)
    {
        if (!isInvincible)
        {
            enemyHp = enemyHp - damage;
            if (enemyHp <= 0)
            {
                Instantiate(crystalPrefab, transform.position, Quaternion.identity);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);               
                Destroy(gameObject);               
                enemiesKilled();               
                LoadScene();
                
            }
            //enemy takes damage
            StartCoroutine(InvincibilityCoroutine());
        }

    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();

            if (isTrackingPlayer == false)
            {
                direction = new Vector3(1, 0, 0);
            }

            transform.position += direction * Time.deltaTime * speed;

            transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
        }
    }
    public void enemiesKilled()
    {
        //TitleManager.saveData.totalEnemies++;
        if (gameObject.tag == "Merman")
        {
            TitleManager.saveData.merman++;
        }
        else if (gameObject.tag == "Runner")
        {
            TitleManager.saveData.runner++;
        }
        else if (gameObject.tag == "Zombie")
        {
            TitleManager.saveData.zombie++;
        }
        else if (gameObject.tag == "Vampire")
        {
            TitleManager.saveData.vampire++;
        }
        else if (gameObject.tag == "Giant")
        {
            TitleManager.saveData.giant++;
        }
        else if (gameObject.tag == "Mushroom")
        {
            TitleManager.saveData.mushroom++;
        }
        else if (gameObject.tag == "Goblin")
        {
            TitleManager.saveData.goblin++;
        }
        else if (gameObject.tag == "Skeleton")
        {
            TitleManager.saveData.skeleton++;
        }
        else if (gameObject.tag == "FlyingEye")
        {
            TitleManager.saveData.flyingEye++;
        }
        else if (gameObject.tag == "Boss")
        {
            TitleManager.saveData.Boss++;
        }

    }

    public void LoadScene()
    {
        if(gameObject.tag == "Boss")
        {          
            SceneManager.LoadScene("Level2");
        }
    }
}