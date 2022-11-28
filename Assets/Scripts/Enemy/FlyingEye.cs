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
    [SerializeField] GameObject knifePrefab;
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
                    animator.SetBool("IsWalking", true);
                    base.Update();
                }
                else
                {
                    animator.SetBool("IsWalking", false);
                    currentState = FlyingState.Attacking;
                }
                break;
            case FlyingState.Attacking:
                animator.SetTrigger("Attack");
                waitTime = 5f;
                currentState = FlyingState.Idling;
                SpawnKnife();
                break;
        }
    }

    

    IEnumerator SpawnKnife()
    {
        yield return new WaitForSeconds(1f);
        double valueX = player.transform.position.x - transform.position.x;
        double valueY = player.transform.position.y - transform.position.y;
        double tan = valueY / valueX;
        double angle = ConvertRadians(Math.Atan2(valueY, valueX));

        Instantiate(knifePrefab, transform.position, Quaternion.Euler(0, 0, (float)angle));
    }
    public static double ConvertRadians(double radians)
    {
        return Mathf.Rad2Deg * radians;
    }
}
