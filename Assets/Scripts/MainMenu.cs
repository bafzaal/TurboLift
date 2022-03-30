using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker.Requests;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {      
      SceneManager.LoadScene("PlayerDetails");

    }
    public void Leaderboards()
    {  
      LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });

      SceneManager.LoadScene("Leaderboards");

    }
    public void QuitGame()
    {
    	Application.Quit();
    }
}
