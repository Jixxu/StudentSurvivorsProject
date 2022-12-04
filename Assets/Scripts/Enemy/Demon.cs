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
                base.Update();
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                if (distance < 1f)
                {
                    currentState = DemonState.Attacking;
                }
                break;
                
            case DemonState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 1f;
                currentState = DemonState.Idling;
                break;
        }
    }
}
