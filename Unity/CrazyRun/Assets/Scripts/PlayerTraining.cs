using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTraining : MonoBehaviour
{
    [SerializeField] private GameObject panelHints;
    [SerializeField] private GameObject objHint;

    private Animator anim;

    private enum VarHint
    {
        Forward,
        Back,
        Left,
        Right,
        Idle
    }

    private VarHint hint;

    private void Start()
    {
        anim = objHint.GetComponent<Animator>();
        hint = VarHint.Idle;
    }

    private void Update()
    {

        switch (hint)
        {
            case VarHint.Forward:
                {
                    anim.SetTrigger("Forward");
                    break;
                }
            case VarHint.Back:
                {
                    anim.SetTrigger("Back");
                    break;
                }
            case VarHint.Left:
                {
                    anim.SetTrigger("Left");
                    break;
                }
            case VarHint.Right:
                {
                    anim.SetTrigger("Right");
                    break;
                }
        }

        if (panelHints.activeSelf)
        {
            if (Input.touchCount > 0)
            {
                if (hint == VarHint.Forward && Input.GetTouch(0).deltaPosition.y > 70)
                    PanelNotActive();

                if (hint == VarHint.Back && Input.GetTouch(0).deltaPosition.y < -70)
                    PanelNotActive();

                if (hint == VarHint.Right && Input.GetTouch(0).deltaPosition.x > 30)
                    PanelNotActive();

                if (hint == VarHint.Left && Input.GetTouch(0).deltaPosition.x < -30)
                    PanelNotActive();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("forward"))
                hint = VarHint.Forward;
            if (gameObject.CompareTag("back"))
                hint = VarHint.Back;
            if (gameObject.CompareTag("left"))
                hint = VarHint.Left;
            if (gameObject.CompareTag("right"))
                hint = VarHint.Right;

            panelHints.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void PanelNotActive()
    {
        Time.timeScale = 1;
        panelHints.SetActive(false);
    }
}
