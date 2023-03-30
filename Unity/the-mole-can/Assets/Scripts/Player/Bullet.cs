using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Animator anim;
    private Collider2D bulletCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        bulletCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            AudioManager.instance.Play("BulletExplosion");
            anim.SetTrigger("bulletExplosion");
            bulletCollider.enabled = false;
            Destroy(gameObject, 0.1f);
        }
    }
}
