using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Player : MonoBehaviour
{

    
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject levelUpMenu;

    [SerializeField] public BaseWeapons[] weapons;

    [SerializeField] TMP_Text goldDisplay;

    [SerializeField] PlayerCamera playercamera;


    Material material;

    public float speed = 7f;
    public float BaseSpeed = 7f;
    //health
    public int playerHP;
    public int MaxplayerHP;
    public int CurrentMaxPlayerHP;

    //Heals
    public int SmallHP = 2;
    public int BigHP = 5;

    //Exp
    internal int currentExp;
    internal int expTolevel = 5;
    internal int currentlevel;

    public AudioClip levelUpSound;

    Animator animator;
    bool isInvincible;

    public virtual void Start()
    {
        MaxplayerHP = MaxplayerHP + TitleManager.saveData.healthIncrease;
        playerHP = MaxplayerHP;
        animator = GetComponent<Animator>();

        material = spriteRenderer.material;
        
    }
    public void AddExp()
    {
        currentExp++;
        if (currentExp == expTolevel)
        {
            AudioSource.PlayClipAtPoint(levelUpSound, transform.position);
            currentExp = 0;
            expTolevel += 5;
            currentlevel++;

            Time.timeScale = 0;
            levelUpMenu.SetActive(true);
            playercamera.DepthOfField.focalLength.Override(300);
           
            
        }
    }

    public float GetHPRatio()
    {
        return (float) playerHP/ MaxplayerHP;
    }
    internal void AddSmallHP()
    {
        playerHP = playerHP + SmallHP;
        if(playerHP > MaxplayerHP)
        {
            playerHP = MaxplayerHP;
        }
    }
    internal void AddBigHP()
    {
        playerHP = playerHP + BigHP;
        if (playerHP > MaxplayerHP )
        {
            playerHP = MaxplayerHP;
        }
    }

    public bool ONdamage()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
            isInvincible = true;
            playercamera.Shake(0.2f,1);

            if (--playerHP <= 0)
            {
                StartCoroutine(DeathCoroutine());
            }
            return true;
        }
        return false;
    }

   


    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        //spriteRenderer.color = Color.red;
        material.SetFloat("_Flash", 0.33f);
        yield return new WaitForSeconds(0.5f);
        material.SetFloat("_Flash", 0);
        //spriteRenderer.color = Color.white;
        isInvincible = false;
    }

    IEnumerator DeathCoroutine()
    {
        playercamera.colorAdjustments.saturation.Override(-100);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Destroy(gameObject);
        SceneManager.LoadScene("Death");
    }

    public virtual void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;



        if (inputX > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (inputX < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        bool isRunning = (inputX != 0 || inputY != 0 ? true : false);
        if (inputX != 0)
        {
            isRunning = true;
        }
        else if (inputY != 0)
        {
            isRunning = true;
        }
        animator.SetBool("isRunning", isRunning);
        goldDisplay.text = TitleManager.saveData.goldCoins.ToString();
    }

    
}