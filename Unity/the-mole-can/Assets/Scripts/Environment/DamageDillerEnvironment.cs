using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DamageDillerEnvironment : MonoBehaviour
{
    [SerializeField] private float damage;

    private PolygonCollider2D pc2dEnvironment;
    private PointEffector2D pe2dEnvironment;
    private bool hasPointEffector = false;

    private void Awake()
    {
        pc2dEnvironment = transform.GetComponent<PolygonCollider2D>();
        hasPointEffector = transform.TryGetComponent(typeof(PointEffector2D), out Component component);
        pe2dEnvironment = (PointEffector2D)component;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<HealthPlayer>().TakeDamage(damage);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (hasPointEffector && transform.gameObject.CompareTag("Enemy") 
                || hasPointEffector && transform.gameObject.CompareTag("EnemyBomb"))
                CollisionEffect();
    }

    private async void CollisionEffect()
    {
        pc2dEnvironment.isTrigger = true;
        pe2dEnvironment.enabled = true;
        pc2dEnvironment.isTrigger = false;
        await Task.Delay(500);
        pe2dEnvironment.enabled = false;
    }
}
