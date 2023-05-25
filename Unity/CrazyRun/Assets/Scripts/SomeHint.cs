using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeHint : MonoBehaviour
{
    [SerializeField] private GameObject gb;
    [SerializeField] private float time;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gb.SetActive(true);
            StartCoroutine(IsDestroy());
        }
    }

    IEnumerator IsDestroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

