using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LootLocker.Requests;
public class MapSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMap()
    {

      LootLockerSDKManager.StartGuestSession((response) =>
      {
          if (!response.success)
          {
              Debug.Log("error starting LootLocker session");

              return;
          }else{

            Debug.Log("successfully started LootLocker session");

          }
      });

    	string mapName = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text>().text;
    	SceneManager.LoadScene(mapName);
    }

    public void Back()
    {
        SceneManager.LoadScene("CarSelection");
    }
}
