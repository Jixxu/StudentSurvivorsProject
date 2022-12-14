using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCrystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            GameObject[] SuperCrystal = GameObject.FindGameObjectsWithTag("Crystal");
            int crystals = SuperCrystal.Length;
            for (int i = 0; i <= crystals; i++)
            {
                player.AddExp();
            }

            Destroy(gameObject);
            DestroyAll();
        }


    }
    public void DestroyAll()
    {
        foreach (GameObject cry in GameObject.FindGameObjectsWithTag("Crystal"))
        {
            Destroy(cry);
        }
    }
}
