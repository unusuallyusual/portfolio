using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinMove : MonoBehaviour
{
    private SliderJoint2D slide;

    private void Start()
    {
        slide = GetComponent<SliderJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            slide.useMotor = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            slide.useMotor = false;
    }
}
