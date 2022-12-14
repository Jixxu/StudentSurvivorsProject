using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUp : BaseWeapons
{
    [SerializeField] Player2 player2;
    [SerializeField] Player3 player3;
    
    public void Update()
    {
        if (level > 0)
        {
            if (HeroManger.playerIndex == 1)
            {
                player.MaxplayerHP = player.CurrentHP + (level * 2);
            }
            else if (HeroManger.playerIndex == 2)
            {
                player.MaxplayerHP = player.CurrentHP + (level * 2);
            }
            else if (HeroManger.playerIndex == 3)
            {
                player3.MaxplayerHP = player3.CurrentHP + (level * 2);
            }
        }
    }
}
