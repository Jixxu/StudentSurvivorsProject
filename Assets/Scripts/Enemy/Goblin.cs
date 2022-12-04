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
                base.Update();
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                if (distance < 1f)
                {
                    currentState = GoblinState.Attacking;
                }
                break;
            case GoblinState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 1f;
                currentState = GoblinState.Idling;
                break;
        }
    }
}
