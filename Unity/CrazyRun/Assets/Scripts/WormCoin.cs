using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCoin : MonoBehaviour
{
    [SerializeField] private ScoreGamePanel scoreGame;

    private void Awake()
    {
        scoreGame = scoreGame.GetComponent<ScoreGamePanel>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreGame.EatWorm();
            Destroy(gameObject);
        }
    }
}
