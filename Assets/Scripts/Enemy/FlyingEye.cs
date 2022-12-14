using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingEye : Enemy
{
    enum FlyingState
    {
        Idling,
        Chasing,
        Attacking,
        Death
    }
    [SerializeField] GameObject ballPrefab;
    FlyingState currentState = FlyingState.Idling;
    Animator animator;
    float waitTime = 2f;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    protected override void Update()
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
                    base.Update();
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    currentState = FlyingState.Attacking;
                }
                if (enemyHp <= 0)
                {
                    currentState = FlyingState.Death;
                }
                break;
            case FlyingState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 1f;
                currentState = FlyingState.Idling;
                SpawnBall();
                break;
            case FlyingState.Death:
                animator.SetBool("isWalking", false);
                StartCoroutine(BossDeath());
                currentState = FlyingState.Idling;
                waitTime = 2f;
                break;
        }
    }



    internal void SpawnBall()
    {
        var flyingEye = transform.position;

        var targetPos = player.transform.position;

        Vector3 points = (targetPos - flyingEye);

        float angle = MathF.Atan2(points.y, points.x) * Mathf.Rad2Deg;

        Instantiate(ballPrefab, transform.position, Quaternion.Euler(0, 0, angle));
    }

    IEnumerator BossDeath()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSecondsRealtime(0.8f);
        Destroy(gameObject);
    }
    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        material.SetFloat("_Flash", 0.33f);
        yield return new WaitForSeconds(1f);
        material.SetFloat("_Flash", 0f);
        spriteRenderer.color = Originalcolor;
        isInvincible = false;
    }
    public override void Damage(int damage)
    {
        if (!isInvincible)
        {
            enemyHp = enemyHp - damage;
            if (enemyHp <= 0)
            {
                Instantiate(crystalPrefab, transform.position, Quaternion.identity);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);


            }
            //enemy takes damage
            StartCoroutine(InvincibilityCoroutine());
        }

    }
}
