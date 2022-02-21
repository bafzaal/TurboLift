using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassengerCounter : MonoBehaviour
{
	private TextMeshProUGUI passengerCountText;
	private int passengerCountValue;

    private void Awake()
    {
        Drive.ArrowDrivenOver += RunCo;
        passengerCountText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        passengerCountValue = 0;
    }

    void Update()
    {
    	passengerCountText.text = passengerCountValue.ToString() + "/3";
    	if(passengerCountValue == 3)
    		passengerCountText.color = new Color32(80, 200, 120, 255);
    }

    private IEnumerator Pulse()
    {
    	for(float i = 1f; i <= 1.2f; i += 0.05f)
    	{
    		passengerCountText.rectTransform.localScale = new Vector3(i, i, i);
    		yield return new WaitForEndOfFrame();
    	}

    	passengerCountText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    	passengerCountValue += 1;

    	for(float i = 1.2f; i >= 1f; i -= 0.05f)
    	{
    		passengerCountText.rectTransform.localScale = new Vector3(i, i, i);
    		yield return new WaitForEndOfFrame();
    	}

    	passengerCountText.rectTransform.localScale = new Vector3(1f, 1f, 1f);

    }

    public void RunCo()
    {
    	StartCoroutine(Pulse());
    }

    private void OnDestroy()
    {
    	Drive.ArrowDrivenOver -= RunCo;
    }
}
