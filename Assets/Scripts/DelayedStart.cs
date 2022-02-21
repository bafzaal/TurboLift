using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{

	public GameObject countDown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartDelay()
    {
    	Time.timeScale = 0;
    	float pauseTime = Time.realtimeSinceStartup + 3f;
    	while(Time.realtimeSinceStartup < pauseTime)
    	{
            Timer.currTime = 0;
    		yield return 0;
    	}
    	countDown.gameObject.SetActive(false);
    	Time.timeScale = 1;
    }
}
