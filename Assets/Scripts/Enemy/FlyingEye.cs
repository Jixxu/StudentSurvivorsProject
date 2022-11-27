using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingEye : MonoBehaviour
{
    [SerializeField] GameObject crystalPrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float enemyHp = 50f;
    [SerializeField] bool isflyingeye;



    public bool isTrackingPlayer = true;
    bool isInvincible;

    Color Originalcolor;
    GameObject Enemytype;


    enum FlyingState
    {
        Idling,
        Chasing,
        Attacking,
        
    }
    [SerializeField] GameObject projectilePrefab;
    FlyingState currentState = FlyingState.Idling;
    Animator animator;
    float waitTime = 2f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Originalcolor = GetComponent<SpriteRenderer>().color;
        if (isflyingeye)
        {
            StartCoroutine(BossCameraCoroutine());
        }
        animator = GetComponent<Animator>();
    }

    IEnumerator BossCameraCoroutine()
    {
        Time.timeScale = 0;
        //Camera.main.GetComponent<PlayerCamera>().target = transform;

        yield return new WaitForSecondsRealtime(5f);

        // Camera.main.GetComponent<PlayerCamera>().target = player.transform;

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {


            if (player.ONdamage())
            {
                //Destroy(gameObject);
            }
        }


    }

    IEnumerator DamageCoroutine()
    {

        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Originalcolor;

    }
    internal IEnumerator Damage(int damage)
    {
        if (!isInvincible)
        {
            enemyHp = enemyHp - damage;
            if (enemyHp <= 100)
            {
                speed = 4f;
            }
            if (enemyHp <= 0)
            {
                Instantiate(crystalPrefab, transform.position, Quaternion.identity);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
                animator.SetTrigger("Dead");
                yield return new WaitForSeconds(2f);
                Destroy(gameObject);
                //yield return new WaitForSeconds(5f);
                //SceneManager.LoadScene("Level2");
            }
            //enemy takes damage
            StartCoroutine(DamageCoroutine());
        }

    }

    void Update()
    {
        
        switch (currentState)
        {
            case FlyingState.Idling:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    currentState = FlyingState.Chasing;
                }
                break;
            case FlyingState.Chasing:
                if (Vector3.Distance(transform.position, player.transform.position) > 5f)
                {
                    animator.SetBool("isWalking", true);
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
                else
                {
                    animator.SetBool("isWalking", false);
                    currentState = FlyingState.Attacking;
                }
                break;
            case FlyingState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = FlyingState.Idling;
                spawnProjectile();
                break;
            

        }
    }
    IEnumerator spawnProjectile()
    {
        yield return new WaitForSeconds(1f);
        double valueX = player.transform.position.x - transform.position.x;
        double valueY = player.transform.position.y - transform.position.y;
        double tan = valueY / valueX;
        double angle = ConvertRadians(Math.Atan2(valueY, valueX));

        Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, (float)angle));
    }
    public static double ConvertRadians(double radians)
    {
        return Mathf.Rad2Deg * radians;
    }
}
