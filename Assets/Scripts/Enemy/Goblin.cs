using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    enum GoblinState
    {
        Idling,
        Chasing,
        Attacking
    }

    GoblinState currentState = GoblinState.Idling;
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
            case GoblinState.Idling:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    currentState = GoblinState.Chasing;
                }
                break;
            case GoblinState.Chasing:
                if (Vector3.Distance(transform.position, player.transform.position) > 1f)
                {
                    animator.SetBool("isWalking", true);
                    base.Update();
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    currentState = GoblinState.Attacking;
                }
                break;
            case GoblinState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = GoblinState.Idling;
                break;
        }
    }
}
