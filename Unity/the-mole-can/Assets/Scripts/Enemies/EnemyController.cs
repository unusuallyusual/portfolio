using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;

    private Rigidbody2D rb;
    private float currentTimeToRevert;

    enum State
    {
        Idle,
        Walk,
        Revert
    }

    private State currentState;

    private void Start()
    {
        currentState = State.Walk;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = State.Revert;
        }

        switch (currentState)
        {
            case State.Idle:
                currentTimeToRevert += Time.deltaTime;
                break;

            case State.Walk:
                sp.color = new Color(1.0f, 0.27f, 0.75f, 1.0f);
                if (sp.flipX == true)
                    transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                else
                    transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                break;

            case State.Revert:
                sp.flipX = !sp.flipX;
                currentState = State.Walk;
                break;
        }

        anim.SetBool("Moving", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyStopper"))
            currentState = State.Idle;
    }
}
