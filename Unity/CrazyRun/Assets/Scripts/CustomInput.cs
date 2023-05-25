using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomInput : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float force = 1f;

    private Vector2 touchB;
    private Vector2 touchE;
    private float distX;
    private float distY;

    public GameObject pl;
    private Rigidbody rb;

    private void Awake()
    {
        rb = pl.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches.Length == 1)
                {
                    if (Input.touches[0].phase == TouchPhase.Began)
                    {
                        touchB = Input.touches[0].position;
                        touchE = touchB;
                    }
                    if (Input.touches[0].phase == TouchPhase.Ended)
                        touchE = Input.touches[0].position;

                    distX = Math.Abs(touchE.x - touchB.x);
                    distY = Math.Abs(touchE.y - touchB.y);

                    if (distX > 100)
                    {
                        if (touchE.x - touchB.x > 0)
                            rb.velocity += Vector3.right * Time.deltaTime * distX * force;
                        if (touchE.x - touchB.x < 0)
                            rb.velocity += -Vector3.right * Time.deltaTime * distX * force;
                    }
                    if (distY > 50)
                    {
                        if (touchE.y - touchB.y > 0)
                            rb.velocity += Vector3.forward * Time.deltaTime * distY * force;
                        if (touchE.y - touchB.y < 0)
                            rb.velocity += Vector3.back * Time.deltaTime * distY * force;
                    }
                }
            }
        }
    }
}
