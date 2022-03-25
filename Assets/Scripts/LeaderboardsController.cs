using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;
using UnityEngine.SceneManagement;

public class LeaderboardsController : MonoBehaviour
{

    public TextMeshProUGUI[] Entries1;
    public TextMeshProUGUI[] Entries2;
    public TextMeshProUGUI[] Entries3;
    
    int count = 5;
    // Start is called before the first frame update
    void Start()
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


      LootLockerSDKManager.GetScoreList(2116, count, (response) =>
      {
          if (response.statusCode == 200) {
              Debug.Log("Successful");
              LootLockerLeaderboardMember[] scores = response.items;
    
              for(int i=0; i<scores.Length; i++){
                int currTime = scores[i].score/1000;
                int msec = (int)((currTime - (int)currTime) * 100);
                int sec = (int)(currTime % 60);
                int min = (int)(currTime / 60 % 60);
	              string member_score = min.ToString("00") + ":" + sec.ToString("00") + "." + msec.ToString("00") + "s";


                Entries1[i].text = (scores[i].member_id + " - " + member_score);
              }

          } else {
              Debug.Log("failed: " + response.Error);
          }
      });


      LootLockerSDKManager.GetScoreList(2117, count, (response) =>
      {
          if (response.statusCode == 200) {
              Debug.Log("Successful");
              LootLockerLeaderboardMember[] scores = response.items;
    
              for(int i=0; i<scores.Length; i++){
                int currTime = scores[i].score/1000;
                int msec = (int)((currTime - (int)currTime) * 100);
                int sec = (int)(currTime % 60);
                int min = (int)(currTime / 60 % 60);
	              string member_score = min.ToString("00") + ":" + sec.ToString("00") + "." + msec.ToString("00") + "s";


                Entries2[i].text = (scores[i].member_id + " - " + member_score);
              }

          } else {
              Debug.Log("failed: " + response.Error);
          }
      });


      LootLockerSDKManager.GetScoreList(2119, count, (response) =>
      {
          if (response.statusCode == 200) {
              Debug.Log("Successful");
              LootLockerLeaderboardMember[] scores = response.items;
    
              for(int i=0; i<scores.Length; i++){
                int currTime = scores[i].score/1000;
                int msec = (int)((currTime - (int)currTime) * 100);
                int sec = (int)(currTime % 60);
                int min = (int)(currTime / 60 % 60);
	              string member_score = min.ToString("00") + ":" + sec.ToString("00") + "." + msec.ToString("00") + "s";


                Entries3[i].text = (scores[i].member_id + " - " + member_score);
              }

          } else {
              Debug.Log("failed: " + response.Error);
          }
      });


    }



    public void Back()
    {
      SceneManager.LoadScene("Menu");
    }
}
