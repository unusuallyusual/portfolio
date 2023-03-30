using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletExplosive;
    [SerializeField] private GameObject bulletWeak;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;

    private GameObject bullet;
    private HealthObj healthObj;

    private void Awake()
    {
        healthObj = GetComponent<HealthObj>();
    }
    private void Update()
    {
        if (healthObj.CurrentHealth > healthObj.MaxHealth / 2)
            bullet = bulletExplosive;
        else
            bullet = bulletWeak;
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        AudioManager.instance.Play("PlayerShooting");

        if (gameObject.GetComponent<SpriteRenderer>().flipX != true)
            currentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currentBulletVelocity.velocity.y);
        else
            currentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currentBulletVelocity.velocity.y);
    }
}
