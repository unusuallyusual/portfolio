using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject pausePanel;

    private PlayerMovement playerMovement;
    private Shooter shooter;
    private float horizontalDirection;
    private bool isJumpButtonPressed;
    private GameManager gameM;
    private bool buttonPause;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        gameM = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (buttonPause)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }

        horizontalDirection = Input.GetAxisRaw("Horizontal");
        isJumpButtonPressed |= Input.GetButtonDown("Vertical");
        
        if (Input.GetButtonDown("Jump"))
            shooter.Shoot();

        if (Input.GetKeyDown(KeyCode.P))
            PauseGameMenu();
    }
    private void FixedUpdate()
    {
        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        isJumpButtonPressed = false;
    }

    public void PauseGameMenu()
    {
        buttonPause = !buttonPause;
    }
}
