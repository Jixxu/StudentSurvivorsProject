using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image Foreground;
    void Update()
    {
        if (player != null)
        {
            if (HeroManger.playerIndex == 1)
            {
                float hpRatio = (float)player.playerHP / player.MaxplayerHP;
                Foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
            }
            else if (HeroManger.playerIndex == 2)
            {
                float hpRatio = (float)player.playerHP / player.MaxplayerHP;
                Foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
            }
            else if (HeroManger.playerIndex == 3)
            {
                float hpRatio = (float)player.playerHP / player.MaxplayerHP;
                Foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
            }

        }

    }
}