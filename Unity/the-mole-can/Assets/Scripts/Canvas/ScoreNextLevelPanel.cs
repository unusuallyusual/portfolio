using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreNextLevelPanel : MonoBehaviour
{
    [SerializeField] private Text gameTimerText;
    [SerializeField] private Text levelTimerText;
    [SerializeField] private Text gameScoreText;
    [SerializeField] private Text levelScoreText;
    [SerializeField] private Text gameKilledEnemiesText;
    [SerializeField] private Text levelKilledEnemiesText;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private int maxLevelScore;
    [SerializeField] private int maxLevelKilledEnemies;
    
    private GameManager gameM;
    private int gameScore;
    private int index;

    private void Awake()
    {
        gameM = GetComponent<GameManager>();
        index = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        gameTimerText.text = gameM.gameTime.ToString();
        levelTimerText.text = Math.Round((gameM.MaxTime - gameM.levelTime), 1).ToString();
        gameScore = gameM.gameScore;
        gameScoreText.text = gameScore.ToString();
        levelScoreText.text = gameM.levelScore.ToString() + "/" + maxLevelScore.ToString();
        gameKilledEnemiesText.text = gameM.gameKilledEnemies.ToString();
        levelKilledEnemiesText.text = gameM.levelKilledEnemies.ToString() + "/" + maxLevelKilledEnemies.ToString();

        //nextLevelButton
        if ((index == 1 && gameScore > 45)
            || (index == 2 && gameScore > 110)
            || (index == 3 && gameScore > 210)
            || (index == 4 && gameScore > 310))
            nextLevelButton.interactable = true;
    }
}
