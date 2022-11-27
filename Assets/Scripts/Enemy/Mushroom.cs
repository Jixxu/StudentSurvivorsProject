using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    enum MushroomState
    {
        Idling,
        Chasing,
        Attacking
    }
    
    MushroomState currentState = MushroomState.Idling;
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
            case MushroomState.Idling:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    currentState = MushroomState.Chasing;
                }
                break;
            case MushroomState.Chasing:
                if (Vector3.Distance(transform.position, player.transform.position) > 1f)
                {
                    animator.SetBool("isWalking", true);
                    base.Update();
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    currentState = MushroomState.Attacking;
                }
                break;
            case MushroomState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = MushroomState.Idling;
                break;
        }
    }
}
