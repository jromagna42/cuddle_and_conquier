using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public GameObject player;
	public Text fatiguetext;
	public Text foodtext;
	public Text healthtext;
	public Text powertext;
	public Text multtext;
	
	
	Doggo	doggoScript;
	// Use this for initialization
	void Start () {
		doggoScript = player.GetComponent<Doggo>();
	}

	void Update()
	{
		fatiguetext.text = "fatigue : " + GameInfo.fatigue;
		foodtext.text = "food : " + GameInfo.food;
		healthtext.text = "health : " + GameInfo.health;
		powertext.text = "power : " + GameInfo.power;
		multtext.text = "training mult = " + doggoScript.mult;
		if (GameInfo.fatigue > 100f)
			fatiguetext.color = Color.red;
		else
			fatiguetext.color = Color.black;
			
		if (GameInfo.food == 0)
			foodtext.color = Color.red;
		else
			foodtext.color = Color.black;
	}

	// void CallStartTrainDoggo()
	// {
	// 	doggoScript.StartTrainDoggo();
	// }

	// void CallStartEat()
	// {
	// 	doggoScript.StartEat();
	// }

	// void CallStartSleep()
	// {
	// 	doggoScript.StartSleep();
	// }

	// void CallStartPet()
	// {
	// 	doggoScript.StartPet();
	// }
	
}
