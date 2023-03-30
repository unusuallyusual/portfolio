using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDillerBullet : MonoBehaviour
{
    [SerializeField] private float damage;

    private HealthOfEnemiesOrEnvironment collisionHealthOf;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionHealthOf = collision.gameObject.GetComponent<HealthOfEnemiesOrEnvironment>();
        if (collisionHealthOf)
            collisionHealthOf.TakeDamage(damage);
        Destroy(gameObject, 3f);
    }
}
