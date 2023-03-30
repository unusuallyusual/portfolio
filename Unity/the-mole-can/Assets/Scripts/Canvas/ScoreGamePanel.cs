using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGamePanel : MonoBehaviour
{
    [SerializeField] private Image gameTimer;
    [SerializeField] private Text levelTimerText;
    [SerializeField] private Text levelScoreText;
    [SerializeField] private Text levelKilledEnemiesText;
    [SerializeField] private Text gamePlayersLifesText;
    
    private GameManager gameM;
    private Image img;

    private void Awake()
    {
        gameM = GetComponent<GameManager>();
        img = gameTimer.GetComponent<Image>();
    }

    private void Update()
    {
        img.fillAmount = gameM.CurrentTime / gameM.MaxTime;

        levelTimerText.text = gameM.levelTime.ToString();
        levelScoreText.text = gameM.levelScore.ToString();
        levelKilledEnemiesText.text = gameM.levelKilledEnemies.ToString();
        gamePlayersLifesText.text = gameM.gamePlayersLifes.ToString() + " x";
    }
}
