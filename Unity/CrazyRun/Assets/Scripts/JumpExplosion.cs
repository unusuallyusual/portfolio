using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpExplosion : MonoBehaviour
{
  [SerializeField] private float Power;
  [SerializeField] private float Radius;

  public void Explode()
  {
    Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, Radius);

    for (int i = 0; i < overlappedColliders.Length; i++)
    {
      Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
      if (rigidbody)
      {
        rigidbody.AddExplosionForce(Power, transform.position, Radius);
        Vector3 explosionsPosition = transform.position;
      }
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    Explode();
  }
}
