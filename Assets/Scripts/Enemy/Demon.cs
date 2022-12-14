using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    enum DemonState
    {
        Idling,
        Chasing,
        Attacking,
        Death
    }
    [SerializeField] public GameObject attackbox;
    DemonState currentState = DemonState.Idling;
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
            case DemonState.Idling:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    currentState = DemonState.Chasing;
                }
                break;
            case DemonState.Chasing:
                base.Update();
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                if (distance < 3f)
                {
                    currentState = DemonState.Attacking;
                }
                if (enemyHp <= 0)
                {
                    currentState = DemonState.Death;
                }
                break;
                
            case DemonState.Attacking:
                animator.SetBool("isWalking", false);
                StartCoroutine(BossAttack());
                currentState = DemonState.Idling;           
                waitTime = 2f;
                break;
            case DemonState.Death:
                animator.SetBool("isWalking", false);
                StartCoroutine(BossDeath());
                currentState = DemonState.Idling;
                waitTime = 2f;
                break;

        }
    }

    IEnumerator BossAttack()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSecondsRealtime(0.75f);
        attackbox.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        attackbox.SetActive(false);
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
