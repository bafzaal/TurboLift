using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	Text text;
	public static float currTime;
	public float speed = 1;
	bool playing = true;
    public GameOverScreen GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
    	text = GetComponent<Text>();
    	Drive.RaceComplete += RunCo;
    }

    // Update is called once per frame
    void Update()
    {
    	if(playing)
    	{
    		currTime += Time.deltaTime * speed;
            int msec = (int)((currTime - (int)currTime) * 100);
            int sec = (int)(currTime % 60);
            int min = (int)(currTime / 60 % 60);

	        // string hours = Mathf.Floor((currTime % 216000) / 3600).ToString("00");
	        // string minutes = Mathf.Floor((currTime % 3600) / 60).ToString("00");
	        // string seconds = (currTime % 60).ToString("00");
	        text.text = min.ToString("00") + ":" + sec.ToString("00") + "." + msec.ToString("00") + "s";
    	}
    }

    public void RunCo()
    {
    	ClickStop();
        GameOverScreen.Setup(text.text);
    }

    public void ClickPlay()
    {
        playing = true;
    }

    public void ClickStop()
    {
        playing = false;
    }

    private void OnDestroy()
    {
        Drive.RaceComplete -= RunCo;
    }
}
