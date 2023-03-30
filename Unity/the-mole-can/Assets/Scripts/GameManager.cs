using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxTime;

    public float levelTime;
    public int levelScore;
    public int levelKilledEnemies;
    public int gamePlayersLifes;
    public float gameTime;
    public int gameScore;
    public int gameKilledEnemies;

    private float currentTime;
    private float effectsVolume;
    private float musicVolume;
    private SceneMusic sceneMusic;
    private IndicatorsRepository data;
    private IndicatorsRepository dataReserve;
    private int index;

    public float MaxTime => maxTime;
    public float CurrentTime => currentTime;

    private void Awake()
    {
        currentTime = maxTime;
        dataReserve = IndicatorsRepository.DataDeSerialization();
        data = IndicatorsRepository.DataDeSerialization();
        sceneMusic = GetComponent<SceneMusic>();
    }

    private void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        levelScore = 0;
        levelKilledEnemies = 0;
        gamePlayersLifes = data.Indicators[0].CountLifes;

        if (PlayerPrefs.HasKey("musicVolume"))
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
        else
            musicVolume = 0.5f;
        if (PlayerPrefs.HasKey("effectsVolume"))
            effectsVolume = PlayerPrefs.GetFloat("effectsVolume");
        else
            effectsVolume = 0.75f;

        sceneMusic.SetEffectsVolume(effectsVolume);
        sceneMusic.SetMusicVolume(musicVolume);
    }

    private void Update()
    {
        gameTime = data.Indicators[0].Time - data.Indicators[index].Time + maxTime - levelTime;
        gameScore = data.Indicators[0].CountScore - data.Indicators[index].CountScore + levelScore;
        gameKilledEnemies = data.Indicators[0].CountEnemies - data.Indicators[index].CountEnemies + levelKilledEnemies;

        levelTime = (float)Math.Round(currentTime, 1);
    }

    public void ChangeCurrentTime(float time)
    {
        currentTime = time;
    }
    public void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("effectsVolume", sceneMusic.SoundEffectsVolume);
        PlayerPrefs.SetFloat("musicVolume", sceneMusic.MusicVolume);
    }
    public void BackToLevelGameMenuFromPause()
    {
        SceneManager.LoadScene(0);
    }
    public void BackToLevelGameMenuIfGameOver()
    {
        ReserveLevelPoints(index);
        data.Indicators[index].CountLifes = gamePlayersLifes;
        SavePoints();
        BackToLevelGameMenuFromPause();
    }
    public void AllOverAgain()
    {
        File.Delete(Environment.CurrentDirectory + "\\gameData.xml");
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        LevelPoints(index);
        SavePoints();
        SceneManager.LoadScene(index + 1);
    }
    public void RestartLevelIfFromPause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartLevelIfGameOver()
    {
        ReserveLevelPoints(index);
        data.Indicators[index].DateChanges = DateTime.Now.ToString();
        data.Indicators[index].CountLifes = gamePlayersLifes;
        SavePoints();
        RestartLevelIfFromPause();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SavePoints()
    {
            data.Indicators[0].DateChanges = DateTime.Now.ToString();
            data.Indicators[0].Time = 0;
            data.Indicators[0].CountScore = 0;
            data.Indicators[0].CountEnemies = 0;
            data.Indicators[0].CountLifes = gamePlayersLifes;
            for (int i = 0; i < data.Indicators.Count - 1; i++)
            {
                data.Indicators[0].Time += data.Indicators[i].Time;
                data.Indicators[0].CountScore += data.Indicators[i].CountScore;
                data.Indicators[0].CountEnemies += data.Indicators[i].CountEnemies;
            }

            data.DataSerialization();
    }
    private void LevelPoints(int numScene)
    {
        data.Indicators[numScene].DateChanges = DateTime.Now.ToString();
        if (data.Indicators[numScene].CountScore < levelScore)
        {
            data.Indicators[numScene].CountScore = levelScore;
            data.Indicators[numScene].Time = maxTime - levelTime;
            data.Indicators[numScene].CountEnemies = levelKilledEnemies;
        }
        else
        {
            data.Indicators[numScene].Time = dataReserve.Indicators[numScene].Time;
            data.Indicators[numScene].CountScore = dataReserve.Indicators[numScene].CountScore;
            data.Indicators[numScene].CountEnemies = dataReserve.Indicators[numScene].CountEnemies;
        }
        data.Indicators[numScene].CountLifes = gamePlayersLifes;
    }
    private void ReserveLevelPoints(int numScene)
    {
        data.Indicators[numScene].DateChanges = dataReserve.Indicators[numScene].DateChanges;
        data.Indicators[numScene].Time = dataReserve.Indicators[numScene].Time;
        data.Indicators[numScene].CountScore = dataReserve.Indicators[numScene].CountScore;
        data.Indicators[numScene].CountEnemies = dataReserve.Indicators[numScene].CountEnemies;
        data.Indicators[numScene].CountLifes = dataReserve.Indicators[numScene].CountLifes;
    }
}