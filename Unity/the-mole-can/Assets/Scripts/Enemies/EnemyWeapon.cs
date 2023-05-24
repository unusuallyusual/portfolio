using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private GameObject whoseWeapon;

    private HingeJoint2D hjWeapon;
    private HealthOfEnemiesOrEnvironment hjWeaponComp;
    private PolygonCollider2D colliderWeapon;

    private void Awake()
    {
        hjWeaponComp = whoseWeapon.GetComponent<HealthOfEnemiesOrEnvironment>();
        hjWeapon = GetComponent<HingeJoint2D>();
        colliderWeapon = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (!hjWeaponComp.IsAlive)
        {
            StartCoroutine(BrokeWeapon());
        }
    }

    IEnumerator BrokeWeapon()
    {
        hjWeapon.enabled = false;
        colliderWeapon.enabled = false;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
