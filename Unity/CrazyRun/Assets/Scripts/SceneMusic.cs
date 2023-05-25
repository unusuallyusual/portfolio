using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMusic : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play("Music");
    }

    public void ButtonClick()
    {
        AudioManager.instance.Play("Click");
    }
}
