using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPbar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;

    private void Update()
    {
        if (HeroManger.playerIndex == 1)
        {
            float expRatio = (float)player.currentExp / player.expTolevel;
            foreground.transform.localScale = new Vector3(expRatio, 1, 1);
        }
        else if (HeroManger.playerIndex == 2)
        {
            float expRatio = (float)player.currentExp / player.expTolevel;
            foreground.transform.localScale = new Vector3(expRatio, 1, 1);
        }
        else if (HeroManger.playerIndex == 3)
        {
            float expRatio = (float)player.currentExp / player.expTolevel;
            foreground.transform.localScale = new Vector3(expRatio, 1, 1);
        }
            
    }
}
