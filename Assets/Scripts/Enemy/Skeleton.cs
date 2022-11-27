using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    enum SkeletonState
    {
        Idling,
        Chasing,
        Attacking
    }

    SkeletonState currentState = SkeletonState.Idling;
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
            case SkeletonState.Idling:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    currentState = SkeletonState.Chasing;
                }
                break;
            case SkeletonState.Chasing:
                if (Vector3.Distance(transform.position, player.transform.position) > 1f)
                {
                    animator.SetBool("isWalking", true);
                    base.Update();
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    currentState = SkeletonState.Attacking;
                }
                break;
            case SkeletonState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = SkeletonState.Idling;
                break;
        }
    }
}
