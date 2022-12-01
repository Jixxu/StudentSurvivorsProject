using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField] TMP_Text mermanKilled;
    [SerializeField] TMP_Text runnerKilled;
    [SerializeField] TMP_Text zombieKilled;
    [SerializeField] TMP_Text vampireKilled;
    [SerializeField] TMP_Text giantKilled;
    [SerializeField] TMP_Text goblinKilled;
    [SerializeField] TMP_Text skeletonKilled;
    [SerializeField] TMP_Text mushroomKilled;
    [SerializeField] TMP_Text bossKilled;
    [SerializeField] TMP_Text flyingKilled;
    [SerializeField] TMP_Text goldCoins;
    [SerializeField] TMP_Text crystals;



    void Start()
    {
        mermanKilled.text = TitleManager.saveData.merman.ToString();
        runnerKilled.text = TitleManager.saveData.runner.ToString();
        zombieKilled.text = TitleManager.saveData.zombie.ToString();
        vampireKilled.text = TitleManager.saveData.vampire.ToString();
        giantKilled.text = TitleManager.saveData.giant.ToString();
        goblinKilled.text = TitleManager.saveData.goblin.ToString();
        skeletonKilled.text = TitleManager.saveData.skeleton.ToString();
        mushroomKilled.text = TitleManager.saveData.mushroom.ToString();
        bossKilled.text = TitleManager.saveData.Boss.ToString();
        flyingKilled.text = TitleManager.saveData.flyingEye.ToString();
        goldCoins.text = TitleManager.saveData.goldCoins.ToString();
        crystals.text = TitleManager.saveData.exp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
