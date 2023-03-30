using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelProgression : MonoBehaviour
{
    [SerializeField] private Button level_2Button;
    [SerializeField] private Button level_3Button;
    [SerializeField] private Button level_4Button;
    [SerializeField] private Button level_5Button;

    private int nScore;
    private IndicatorsRepository data;

    private void Start()
    {
        data = IndicatorsRepository.DataDeSerialization();
        nScore = data.Indicators[0].CountScore;

        if (nScore > 45)
            level_2Button.interactable = true;
        if (nScore > 110)
            level_3Button.interactable = true;
        if (nScore > 210)
            level_4Button.interactable = true;
        if (nScore > 310)
            level_5Button.interactable = true;
    }
}
