using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapons
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer.enabled = boxCollider2D.enabled;
        StartCoroutine(KatanaCoroutine());
        
    }

    IEnumerator KatanaCoroutine()
    {
        while (true)
        {
            
                transform.localScale = Vector3.one * level;
                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
                yield return new WaitForSeconds(1f);

                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;
                yield return new WaitForSeconds(2f);
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            if (TitleManager.saveData.CritDamage >= 1)
            {
                int randNum = Random.Range(0, 100);

                if (randNum >= 90)
                {
                    enemy.Damage(3);

                }
                else
                {
                    enemy.Damage(1);
                }
            }
            else
            {
                enemy.Damage(1);
            }


        }
       
        //FlyingEye flyingEye = collision.gameObject.GetComponent<FlyingEye>();

        //if (flyingEye != null)
        //{
        //    if (TitleManager.saveData.CritDamage >= 1)
        //    {
        //        int randNum = Random.Range(0, 100);

        //        if (randNum >= 90)
        //        {
        //            flyingEye.Damage(3);

        //        }
        //        else
        //        {
        //            flyingEye.Damage(1);
        //        }
        //    }
        //    else
        //    {
        //        flyingEye.Damage(1);
        //    }
        //}
        

    }
}