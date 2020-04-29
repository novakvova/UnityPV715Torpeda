using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene_Game");
    }
   
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame2()
    {
        SceneManager.LoadScene("Scene_Birds");
    }
}
