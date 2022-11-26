using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapons : MonoBehaviour
{
    public int level = 0;
    [SerializeField] protected Player player;

    public void LevelUp()
    {
        if (++level == 1)
        {
            gameObject.SetActive(true);

        }
    }
}