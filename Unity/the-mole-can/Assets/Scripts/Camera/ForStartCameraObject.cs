using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForStartCameraObject : MonoBehaviour
{
    private int index;
    private Animator anim;

    private void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        anim = GetComponent<Animator>();

        switch (index)
        {
            case 1:
                anim.SetTrigger("Level_1");
                break;
            case 2:
                anim.SetTrigger("Level_2");
                break;
            case 3:
                anim.SetTrigger("Level_3");
                break;
            case 4:
                anim.SetTrigger("Level_4");
                break;
        }
    }

}
