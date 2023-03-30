using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HealthDealer : MonoBehaviour
{ 
    [SerializeField] private GameObject gameManager;
    [SerializeField] private float health;

    private GameManager gameM;

    private void Awake()
    {
        gameM = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("+Health");
            Destroy(this.gameObject);

            if (gameObject.CompareTag("LifeBonus"))
            {
                gameM.gamePlayersLifes++;
                collision.gameObject.GetComponent<HealthPlayer>().isPlusLife();
            }

            if (gameObject.CompareTag("Treatment"))
                collision.gameObject.GetComponent<HealthPlayer>().TakeHealth(health);
        }
    }
}
