using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Transform firePoint;

    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            anim.SetBool("isShooting", true);
        else
            anim.SetBool("isShooting", false);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
            Jump();

        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            firePoint.position = transform.position + new Vector3(-0.15f, 0.1f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            firePoint.position = transform.position + new Vector3(0.15f, 0.1f);
        }

        if (Input.GetAxis("Horizontal") != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        if (Mathf.Abs(direction) > 0.01f)
            HorizontalMovement(direction);
    }

    private void Jump()
    {
        if(isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void HorizontalMovement(float direction)
    {
        if (Mathf.Abs(rb.velocity.x) <= speed)
            rb.velocity = new Vector2(rb.velocity.x + curve.Evaluate(direction)/20, rb.velocity.y);
    }
}
