using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {      
      SceneManager.LoadScene("PlayerDetails");

    }
    public void Leaderboards()
    {      
      SceneManager.LoadScene("Leaderboards");

    }
    public void QuitGame()
    {
    	Application.Quit();
    }
}
