using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class EnergyBall : BaseWeapons
{
    
    public GameObject target;
    private Vector3 offset;
   
    private void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(this.level.ToString());
    }
    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;


    }
    public void Update()
    {
        
        float inputX = Input.GetAxisRaw("Horizontal");
        if (inputX != 0)
        {
            offset.Set(inputX > 0 ? -1 : 1, 0, 0);
        }

       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(2);
        }
        //Boss boss = collision.GetComponent<Boss>();
        //if (boss != null)
        //{
        //    boss.Damage(2);
        //}
        //FlyingEye flyingEye = collision.GetComponent<FlyingEye>();
        //if(flyingEye != null)
        //{
        //    flyingEye.Damage(2);
        //}
    }


}
