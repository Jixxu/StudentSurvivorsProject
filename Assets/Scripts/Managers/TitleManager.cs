using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] Button healthIncreaseBTN;

    [SerializeField] Button CritIncreaseBTN;

    [SerializeField] ParticleSystem ps;

    [SerializeField] GameObject heroMenu;


    public static SaveData saveData;
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");
    public void Awake()
    {
        if (saveData == null)
            Load();
        else
            Save();
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
    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnTitleButtonClick()
    {
        SceneManager.LoadScene("Title");
    }

    


    public void OnKatanaButtonClick()
    {

        player.weapons[0].LevelUp();
        player.levelUpMenu.SetActive(false);
        Time.timeScale = 1;

    }
    public void OnScytheButtonClick()
    {
        player.weapons[1].LevelUp();
        player.levelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnEnergyButtonClick()
    {
        player.weapons[2].LevelUp();
        player.levelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void HPBuffLVL()
    {
        player.weapons[3].LevelUp();
        player.levelUpMenu.SetActive(false);
        Time.timeScale = 1;
        ps.Play();

    }
    public void SpeedBuffLVL()
    {
        player.weapons[4].LevelUp();
        player.levelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }
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

    

}
