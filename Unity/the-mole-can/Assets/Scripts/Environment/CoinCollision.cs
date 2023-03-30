using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;

    private GameManager gameM;

    private void Awake()
    {
        gameM = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Coin");
            Destroy(this.gameObject);
            gameM.levelScore++;
        }
    }
}
