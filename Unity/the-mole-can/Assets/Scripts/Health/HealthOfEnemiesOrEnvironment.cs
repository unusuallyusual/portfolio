using UnityEngine;

public class HealthOfEnemiesOrEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject gameManager;

    private EnemyController eControl;
    private GameManager gameM;
    private HealthObj healthObj;
    private float currentHealth;
    private float maxHealth;
    public bool IsAlive => currentHealth > 0;

    private void Awake()
    {
        eControl = GetComponent<EnemyController>();
        gameM = gameManager.GetComponent<GameManager>();
        healthObj = GetComponent<HealthObj>();
        maxHealth = healthObj.MaxHealth;
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("EnemyBomb") && collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        healthObj.ChangeCurrentHealth(currentHealth);
        if (currentHealth < maxHealth && gameObject.CompareTag("Enemy"))
            eControl.enabled = true;

        if (!IsAlive && !gameObject.CompareTag("EnemyBomb"))
        {
            if (!gameObject.CompareTag("Damageable"))
                gameM.levelKilledEnemies++;
            if (gameObject.CompareTag("Scarecrow") || gameObject.CompareTag("VillageScarecrow"))
                gameM.levelScore += 10;
            if (gameObject.CompareTag("Enemy"))
                gameM.levelScore += 1;
            if (gameObject.CompareTag("EnemysLeader"))
                gameM.levelScore += 50;

            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

}
