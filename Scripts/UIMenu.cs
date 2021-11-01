using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void storeOpen()
    {
        SceneManager.LoadScene(2);
    }
}
