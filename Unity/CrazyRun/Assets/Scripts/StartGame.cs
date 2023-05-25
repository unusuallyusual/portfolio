using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StartLevel_1()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLevel_2()
    {
        SceneManager.LoadScene(2);
    }

    public void StartLevel_3()
    {
        SceneManager.LoadScene(3);
    }

    public void StartLevel_4()
    {
        SceneManager.LoadScene(4);
    }

    public void StartLevel_5()
    {
        SceneManager.LoadScene(5);
    }
}
