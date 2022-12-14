using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
using TMPro;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerCamera playerCamera;

    [SerializeField] Button healthIncreaseBTN;

    [SerializeField] Button CritIncreaseBTN;

    [SerializeField] ParticleSystem ps;

    [SerializeField] GameObject heroMenu;

    [SerializeField] TMP_Text goldCoins;



    public static SaveData saveData;

    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");
   
    public void Awake()
    {       
        if (saveData == null)
            Load();
        else
            Save();
        //goldCoins.text = saveData.goldCoins.ToString();
    }

    private void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = bf.Deserialize(file) as SaveData;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }

    private void Save()
    {
        FileStream file = null;
        try
        {
            if (!Directory.Exists(Application.persistentDataPath))
                Directory.CreateDirectory(Application.persistentDataPath);
            file = File.Create(SavePath);
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }

    public void Update()
    {
    }


    // Start Menu
    public void OnStartButtonClick()
    { 
        SceneManager.LoadScene("Game");
    }
    public void OnUpgradeButtonClick()
    {
        SceneManager.LoadScene("Upgrade");
    }
    public void WizardsBTN()
    {
        heroMenu.SetActive(true);
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }



    //Death Scene
    public void OnRetryButtonClick()
    {
        StatReset();
        SceneManager.LoadScene("Game");
    }
    public void OnTitleButtonClick()
    {
        StatReset();
        SceneManager.LoadScene("Title");
    }
    public void StatReset()
    {
        TitleManager.saveData.merman = 0;
        TitleManager.saveData.runner = 0;
        TitleManager.saveData.zombie = 0;
        TitleManager.saveData.vampire = 0;
        TitleManager.saveData.giant = 0;
        TitleManager.saveData.mushroom = 0;
        TitleManager.saveData.goblin = 0;
        TitleManager.saveData.skeleton = 0;
        TitleManager.saveData.flyingEye = 0;
        TitleManager.saveData.Boss = 0;
        TitleManager.saveData.exp = 0;
    }

    

    //LevelUp Menu
    public void OnKatanaButtonClick()
    {

        player.weapons[0].LevelUp();
        LevelUpAndPlay();

    }
    public void OnScytheButtonClick()
    {
        player.weapons[1].LevelUp();
        LevelUpAndPlay();
    }
    public void OnEnergyButtonClick()
    {
        player.weapons[2].LevelUp();
        LevelUpAndPlay();
    }
    public void HPBuffLVL()
    {
        player.weapons[3].LevelUp();
        LevelUpAndPlay();
        ps.Play();

    }
    public void SpeedBuffLVL()
    {
        player.weapons[4].LevelUp();
        LevelUpAndPlay();
    }



    //Upgrade Scene
    public void HealthIncrease()
    {
        if (TitleManager.saveData.goldCoins < 25)
        {
            healthIncreaseBTN.interactable = false;
        }
        else
        {
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 25;
            TitleManager.saveData.healthIncrease++;
        }
    }
    public void CritDamage()
    {
        if (TitleManager.saveData.goldCoins < 100)
        {
            CritIncreaseBTN.interactable = false;
        }
        else
        {
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 100;
            TitleManager.saveData.CritDamage++;
        }
    }
    public void Return()
    {
        SceneManager.LoadScene("Title");
    }
    
    //Option Menu
    
    void LevelUpAndPlay()
    {
        player.levelUpMenu.SetActive(false);
        Time.timeScale = 1;
        
    }
    
}
