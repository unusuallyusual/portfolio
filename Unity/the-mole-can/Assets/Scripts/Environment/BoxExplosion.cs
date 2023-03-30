using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BoxExplosion : MonoBehaviour
{
    private void Start()
    {
        if(CompareTag("Explosion"))
            AudioManager.instance.Play("BoxExplosion");
    }
    private void Update()
    {
        Destroy(gameObject, 0.5f);
    }
}
