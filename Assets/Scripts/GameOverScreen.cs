using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

	public Text pointsText;

    public void Setup(string score)
    {
    	gameObject.SetActive(true);
    	pointsText.text = score;
    }

    public void RestartButton()
    {
    	SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
