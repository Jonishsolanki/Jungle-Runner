using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playgame, pausegame;
    private bool isplay = true;
   public void pause()
    {
        if (isplay == true)
        {
            Time.timeScale = 0;
            playgame.SetActive(true);
            pausegame.SetActive(false);
            isplay=false;
        }
    }
    public void play()
    {
        Time.timeScale = 1;
        pausegame.SetActive(true);
        playgame.SetActive(false);
        isplay = true;
    }
    public void exit()
    {
        //Application.Quit();
        SceneManager.LoadScene(0);
    }
}
