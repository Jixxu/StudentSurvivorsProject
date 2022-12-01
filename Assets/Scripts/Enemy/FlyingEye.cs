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
        Attacking
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
                break;
            case FlyingState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 1f;
                currentState = FlyingState.Idling;
                SpawnBall();
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
}
