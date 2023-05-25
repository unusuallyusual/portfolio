using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGamePanel : MonoBehaviour
{
    //time
    [SerializeField] private GameObject gameTimer;
    [SerializeField] private float maxTime;
    [SerializeField] private Text levelTimerText;
    //worms
    [SerializeField] private Text wormCounterText;
    [SerializeField] private Text finishWormCounterText;
    [SerializeField] private Text maxWormText;
    //health
    [SerializeField] private GameObject gameHealth;
    [SerializeField] private GameObject replenishHealth;
    //panels
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject timeOutPanel;
    [SerializeField] private GameObject finishPanel;

    private float healthCounter;
    private float maxHealth = 10;
    private bool rh = false;
    private int wormCounter;
    private float gameTime;

    public float MaxTime => maxTime;
    public int MaxWorm;

    private Image imgT;
    private Image imgH;
    private Animator anim;

    private void Awake()
    {
        Time.timeScale = 1;
        gameTime = maxTime;
        healthCounter = maxHealth;
        imgT = gameTimer.GetComponent<Image>();
        imgH = gameHealth.GetComponent<Image>();
        levelTimerText = levelTimerText.GetComponent<Text>();
        anim = gameTimer.GetComponent<Animator>();
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;

        if (healthCounter > 10)
            healthCounter = 10;
        if (healthCounter < 0)
            healthCounter = 0;
        if(healthCounter < 1)
            anim.SetTrigger("TimeOut");

        if (gameTime < 0.1f || healthCounter == 0)
            TimeOut();
        if (gameTime < 5)
            anim.SetTrigger("TimeOut");

        if (wormCounter % 4 == 0 && wormCounter != 0)
        {
            if (rh == false)
                ReplenishHealth();
        }
        else
        {
            rh = false;
            replenishHealth.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        imgT.fillAmount = gameTime / MaxTime;
        imgH.fillAmount = healthCounter / maxHealth;
        levelTimerText.text = Math.Round(gameTime, 1).ToString();
        wormCounterText.text = wormCounter.ToString();
        finishWormCounterText.text = wormCounter.ToString();
        maxWormText.text = "/  " + MaxWorm.ToString();
    }

    private void ShowNewPanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gamePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void TimeOut()
    {
        AudioManager.instance.Stop("Music");
        ShowNewPanel(timeOutPanel);
    }

    public void Finish()
    {
        AudioManager.instance.Stop("Music");
        ShowNewPanel(finishPanel);
    }

    public void EatWorm()
    {
        AudioManager.instance.Play("Eat");
        wormCounter += 1;
    }

    public void DamageHealth()
    {
        AudioManager.instance.Play("Damage");
        healthCounter -= 3;
    }

    public void ReplenishHealth()
    {
        replenishHealth.SetActive(true);
        StartCoroutine(PlusHealth());
        rh = true;
    }

    IEnumerator PlusHealth()
    {
        yield return new WaitForSeconds(1f);
        healthCounter += 2;
    }
}
