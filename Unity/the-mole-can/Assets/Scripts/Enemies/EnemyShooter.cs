using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform firePoint;
    [SerializeField] [Range(1, 10)] private int shootFrequency;

    private int fireSpeed;
    private float currentTime = 0;
    private SpriteRenderer spGameObject;

    private void Awake()
    {
        spGameObject = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        System.Random rnd = new System.Random();
        fireSpeed = rnd.Next(1, 10);
        if (((Math.Round(currentTime, 2) * 100 % shootFrequency == 0) && 
            (Math.Round(currentTime, 1)) % shootFrequency == 0))
            ShootBomb(fireSpeed);
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void ShootBomb(int fireSpeed)
    {
        GameObject currentBullet = Instantiate(bomb, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        if(gameObject.CompareTag("EnemysLeader"))
            AudioManager.instance.Play("EnemysLeaderShooting");
        else
            AudioManager.instance.Play("EnemyShooting");

        if (spGameObject.flipX != true)
        {
            firePoint.position = transform.position + new Vector3(-1f, 0.25f);
            currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
        }
        else
        {
            firePoint.position = transform.position + new Vector3(1f, 0.25f);
            currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
        }
    }
}
