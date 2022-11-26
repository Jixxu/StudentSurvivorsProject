using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManger : MonoBehaviour
{
    public static int playerIndex = 1;
    
    [SerializeField] Button Player1BTN;
    [SerializeField] Button Player2BTN;
    [SerializeField] Button Player3BTN;
   
    public void Start()
    {
       
    }
    public void onClickChooseP1()
    {
        playerIndex = 1;
        Player2BTN.interactable = false;
        Player3BTN.interactable = false;
        
        

        
    }
    public void onClickChooseP2()
    {
        playerIndex = 2;
        Player1BTN.interactable = false;
        Player3BTN.interactable = false;
        
    }
    public void onClickChooseP3()
    {
        playerIndex = 3;
        Player1BTN.interactable = false;
        Player2BTN.interactable = false;
        
    }
}
