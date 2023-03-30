using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] private float timeToEnd;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("EndNote", false);
    }

    private void Update()
    {
        timeToEnd -= Time.deltaTime;
        if(timeToEnd < 0)
            anim.SetBool("EndNote", true);
    }
}
