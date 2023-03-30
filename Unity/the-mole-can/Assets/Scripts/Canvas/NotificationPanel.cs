using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] notes;
    [SerializeField] private float[] timeToNote;
    
    private GameManager gameM;
    private int countNotes;

    private void Start()
    {
        gameM = GetComponent<GameManager>();
        countNotes = notes.Length;
    }

    private void Update()
    {
        for (int i = 0; i < countNotes; i++)
            if (gameM.MaxTime - gameM.CurrentTime > timeToNote[i])
                notes[i].SetActive(true);
    }
}
