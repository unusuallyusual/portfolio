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
            StartCoroutine(IsDied(false));
            gameM.ChangeCurrentTime(0);
        }

        healthObj.ChangeCurrentHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            currentHealth = 0;
            StartCoroutine(IsDied(IsAlive));
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            IsFinish = true;
            StartCoroutine(IsFinished());
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        AudioManager.instance.Play("PlayerCollision");
        StartCoroutine(IsCollision());
        StartCoroutine(IsDied(IsAlive));
    }

    public void TakeHealth(float health)
    {
        StartCoroutine(IsTakeHealth(health));
    }
    IEnumerator IsTakeHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        anim.SetBool("isHealth", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isHealth", false);       
    }

    IEnumerator IsDied(bool isAlive)
    {
        if (!isAlive)
        {
            AudioManager.instance.Play("GameOver");
            anim.SetTrigger("isDied");
            if (gameObjectPI.enabled == true)
                gameM.gamePlayersLifes--;
            gameObjectPI.enabled = false;
            rbPlayer.gravityScale = -0.01f;
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
            if(gameM.gamePlayersLifes == 0)
                gameOverOverPanel.SetActive(true);
            else
                gameOverPanel.SetActive(true);
        }
    }

    IEnumerator IsFinished()
    {
        AudioManager.instance.Play("FinishGame");
        anim.SetTrigger("isFinished");
        gameObjectPI.enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        nextLevelPanel.SetActive(true);
    }

    public void isPlusLife()
    {
        StartCoroutine(PlusLife());
    }
    IEnumerator PlusLife()
    {
        plusLife.SetActive(true);
        yield return new WaitForSeconds(1f);
        plusLife.SetActive(false);
    }

    IEnumerator IsCollision()
    {
        srPlayer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(.4f);
        srPlayer.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(.3f);
        srPlayer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(.3f);
        srPlayer.color = new Color(1, 1, 1, 1);
    }
}
