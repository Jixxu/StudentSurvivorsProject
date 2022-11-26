using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : BaseWeapons
{
    
    
    void Update()
    {
        if(level > 0)
        {
            player.speed = player.BaseSpeed + 1f;
        }
    }
}
