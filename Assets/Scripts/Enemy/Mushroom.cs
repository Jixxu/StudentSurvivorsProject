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
                base.Update();
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                if (distance < 1f)
                {
                    currentState = MushroomState.Attacking;
                }
                break;
            case MushroomState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 1f;
                currentState = MushroomState.Idling;
                break;
        }
    }
}
