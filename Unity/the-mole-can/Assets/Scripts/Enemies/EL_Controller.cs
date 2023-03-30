using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EL_Controller : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert, jumpForce;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Transform objectColliders;
    [SerializeField] private PointEffector2D pointEffector;

    enum State
    {
        Idle,
        Walk,
        Revert,
        Attack
    }

    private State currentState;

    private Rigidbody2D rb;
    private int irand;
    private float currentTimeToRevert, currentTimeToAttack;

    private void Start()
    {
        currentState = State.Walk;
        currentTimeToRevert = 0;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        System.Random rnd = new System.Random();
        irand = rnd.Next(0, 5);
    }

    private void Update()
    {
        if (sp.flipX == true)
            objectColliders.rotation = Quaternion.Euler(0, 180, 0);
        else
            objectColliders.rotation = Quaternion.Euler(0, 0, 0);

        if (currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = State.Revert;
        }

        if (currentTimeToAttack >= 2)
        {
            currentTimeToAttack = 0;
            currentState = State.Walk;
        }

        switch (currentState)
        {
            case State.Idle:
                anim.SetBool("Moving", false);
                anim.SetBool("Attack", false);
                currentTimeToRevert += Time.deltaTime;
                break;

            case State.Walk:
                pointEffector.enabled = false;
                anim.SetBool("Moving", true);
                anim.SetBool("Attack", false);
                if (sp.flipX == true)
                    transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                else
                    transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                break;

            case State.Revert:
                sp.flipX = !sp.flipX;
                currentState = State.Walk;
                break;

            case State.Attack:
                anim.SetBool("Moving", false);
                anim.SetBool("Attack", true);
                currentTimeToAttack += Time.deltaTime;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyStopper"))
            currentState = State.Idle;

        if (collision.gameObject.CompareTag("EnemyJumper") && irand < 3)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * irand);

        if (collision.gameObject.CompareTag("Player"))
        {
            pointEffector.enabled = true;
            currentState = State.Attack;
        }
    }
}
