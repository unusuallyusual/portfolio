using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeInput : MonoBehaviour
{
    private Animator anim;

    private bool walk = false;
    private bool run = false;
    private bool shoot = false;
    private bool attack = false;
    private bool jump= false;
    private bool dance = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            walk = ClickButton(walk);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            run = ClickButton(run);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            shoot = ClickButton(shoot);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            attack = ClickButton(attack);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            jump = ClickButton(jump);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            dance = ClickButton(dance);
    }

    private void FixedUpdate()
    {
        if (walk)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (run)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if (shoot)
            anim.SetBool("isShooting", true);
        else
            anim.SetBool("isShooting", false);

        if (attack)
            anim.SetBool("isAttack", true);
        else
            anim.SetBool("isAttack", false);

        if (jump)
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);

        if (dance)
            anim.SetBool("isDancing", true);
        else
            anim.SetBool("isDancing", false);

        if (Input.GetKeyDown(KeyCode.Alpha0))
            anim.SetTrigger("isDied");
    }

    private bool ClickButton(bool cb)
    {
        return !cb;
    }
}
