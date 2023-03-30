using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelIndicators
{
    /// <summary>
    /// �������� ���������� ���������� ���������� ������ 
    /// </summary>
    /// <param name="DateChanges">����� �������� ������/param>
    /// <param name="CountLifes">���-�� ������ � ������/param>
    /// <param name="CountEnemies">���-�� ������ ������</param>
    /// <param name="CountScore">���-�� ��������� �����</param>
    /// <param name="Name">��� ������</param>
    /// <param name="Time">����� ����������� ������</param>
    /// <param name="EffectsVolume">������� ��������� ��������</param>
    /// <param name="MusicVolume">������� ��������� ������</param>
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
    /// ��� ������
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ���-�� ������
    /// </summary>
    public int CountLifes { get; set; }

    /// <summary>
    /// ���-�� ������ ������
    /// </summary>
    public int CountEnemies { get; set; }

    /// <summary>
    /// ���-�� ��������� �����
    /// </summary>
    public int CountScore { get; set; }

    /// <summary>
    /// ����� ����������� ������
    /// </summary>
    public float Time { get; set; }
}
