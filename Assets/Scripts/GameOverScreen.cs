using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

public class GameOverScreen : MonoBehaviour
{

	public Text pointsText;

    public void Setup(string score, float currTime)
    {
    	gameObject.SetActive(true);
    	pointsText.text = score;

      Debug.Log(currTime);
      int milliseconds = (int)(currTime*1000);
      string sceneName = SceneManager.GetActiveScene().name;
      int leaderBoardID = 0;

      if(sceneName =="GameScene"){
        leaderBoardID = 2116;
      }
      else if(sceneName =="GameScene2"){
        leaderBoardID = 2117;
      }else if(sceneName =="GameScene3"){
        leaderBoardID = 2119;
      }

      LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
      LootLockerSDKManager.SubmitScore(PlayerDetailsController.instance.PlayerName, milliseconds , leaderBoardID, (response) =>
      {
          if (response.statusCode == 200) {
              Debug.Log("Successful");
          } else {
              Debug.Log("failed: " + response.Error);
          }
      });
    }

    public void RestartButton()
    {
        Scene scene = SceneManager.GetActiveScene();
    	  SceneManager.LoadScene(scene.name);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
