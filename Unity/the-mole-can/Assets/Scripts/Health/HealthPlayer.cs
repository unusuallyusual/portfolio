using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameOverOverPanel;
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject plusLife;
    [SerializeField] private GameObject gameManager;

    private HealthObj healthObj;
    private float currentHealth;
    private float maxHealth;
    private PlayerInput gameObjectPI;
    private Animator anim;
    private SpriteRenderer srPlayer;
    private Rigidbody2D rbPlayer;
    private GameManager gameM;

    public bool IsAlive => currentHealth > 0;
    public bool IsFinish = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        srPlayer = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
        gameObjectPI = gameObject.GetComponent<PlayerInput>();
        gameM = gameManager.GetComponent<GameManager>();
        healthObj = GetComponent<HealthObj>();
        maxHealth = healthObj.MaxHealth;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (IsAlive != false && IsFinish == false)
            gameM.ChangeCurrentTime(gameM.CurrentTime - Time.deltaTime);
        if (gameM.CurrentTime <= 0)
        {
            isDied(false);
            gameM.ChangeCurrentTime(0);
        }

        healthObj.ChangeCurrentHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            currentHealth = 0;
            isDied(IsAlive);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            IsFinish = true;
            isFinished();
        }
    }

    private async void isCollision()
    {
        srPlayer.color = new Color(1, 1, 1, 0.5f);
        await Task.Delay(300);
        srPlayer.color = new Color(1, 1, 1, 1);
        await Task.Delay(300);
        srPlayer.color = new Color(1, 1, 1, 0.5f);
        await Task.Delay(300);
        srPlayer.color = new Color(1, 1, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        AudioManager.instance.Play("PlayerCollision");
        isCollision();
        isDied(IsAlive);
    }

    public async void TakeHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        anim.SetBool("isHealth", true);
        await Task.Delay(700);
        anim.SetBool("isHealth", false);       
    }

    public async void isDied(bool isAlive)
    {
        if (!isAlive)
        {
            AudioManager.instance.Play("GameOver");
            anim.SetTrigger("isDied");
            if (gameObjectPI.enabled == true)
                gameM.gamePlayersLifes--;
            gameObjectPI.enabled = false;
            rbPlayer.gravityScale = -0.01f;
            await Task.Delay(1000);
            gameObject.SetActive(false);
            if(gameM.gamePlayersLifes == 0)
                gameOverOverPanel.SetActive(true);
            else
                gameOverPanel.SetActive(true);
        }
    }

    private async void isFinished()
    {
        AudioManager.instance.Play("FinishGame");
        anim.SetTrigger("isFinished");
        gameObjectPI.enabled = false;
        await Task.Delay(1000);
        gameObject.SetActive(false);
        nextLevelPanel.SetActive(true);
    }

    public async void isPlusLife()
    {
        plusLife.SetActive(true);
        await Task.Delay(1000);
        plusLife.SetActive(false);
    }
}
