using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField] private ScoreGamePanel scorePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            scorePanel.TimeOut();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            scorePanel.Finish();
        }
    }
}
