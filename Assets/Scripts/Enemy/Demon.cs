using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    enum DemonState
    {
        Idling,
        Chasing,
        Attacking
    }

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
                if (Vector3.Distance(transform.position, player.transform.position) > 1f)
                {
                    animator.SetBool("isWalking", true);
                    base.Update();
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    currentState = DemonState.Attacking;
                }
                break;
            case DemonState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = DemonState.Idling;
                break;
        }
    }
}
