using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelIndicators
{
    /// <summary>
    /// Создание экземпляра параметров достижений игрока 
    /// </summary>
    /// <param name="DateChanges">Время создание записи/param>
    /// <param name="CountLifes">Кол-во жизней у игрока/param>
    /// <param name="CountEnemies">Кол-во убитых врагов</param>
    /// <param name="CountScore">Кол-во набранных очков</param>
    /// <param name="Name">Имя игрока</param>
    /// <param name="Time">Время прохождения уровня</param>
    /// <param name="EffectsVolume">Уровень громкости эффектов</param>
    /// <param name="MusicVolume">Уровень громкости музыки</param>
    public LevelIndicators(string dateChanges, int countLifes, int countEnemies, int countScore, string name, float time)
    {
        DateChanges = dateChanges;
        CountLifes = countLifes;
        CountEnemies = countEnemies;
        CountScore = countScore;
        Name = name;
        Time = time;
    }

    public LevelIndicators() : this(Convert.ToString(DateTime.Now), 2, 0, 0, "", 0) { }

    public string DateChanges { get; set; }

    /// <summary>
    /// Имя игрока
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Кол-во жизней
    /// </summary>
    public int CountLifes { get; set; }

    /// <summary>
    /// Кол-во убитых врагов
    /// </summary>
    public int CountEnemies { get; set; }

    /// <summary>
    /// Кол-во набранных очков
    /// </summary>
    public int CountScore { get; set; }

    /// <summary>
    /// Время прохождения уровня
    /// </summary>
    public float Time { get; set; }
}
