using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerDetailsController : MonoBehaviour
{

    public static PlayerDetailsController instance;
    public InputField PlayerNameField;
    public string PlayerName;

    private void Awake(){
      instance = this;
      DontDestroyOnLoad(this.gameObject);
    }


    public void SelectMap()
    {
      PlayerName = PlayerNameField.text.ToString();
    	SceneManager.LoadScene("MapSelect");
    }

    public void Back()
    {
      SceneManager.LoadScene("Menu");
    }
}

