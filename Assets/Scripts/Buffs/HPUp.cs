using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUp : BaseWeapons
{
    
    public void HPup()
    {
        if (level >= 1)
        {
            player.MaxplayerHP = player.CurrentMaxPlayerHP + (level * 2);
        }
    }
}
