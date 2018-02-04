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
		DontDestroyOnLoad(this);
		doggoScript = player.GetComponent<Doggo>();
	}

	void Update()
	{
		fatiguetext.text = "fatigue : " + doggoScript.fatigue;
		foodtext.text = "food : " + doggoScript.food;
		healthtext.text = "health : " + doggoScript.health;
		powertext.text = "power : " + doggoScript.power;
		multtext.text = "training mult = " + doggoScript.mult;
		if (doggoScript.fatigue > 100f)
			fatiguetext.color = Color.red;
		else
			fatiguetext.color = Color.black;
			
		if (doggoScript.food == 0)
			foodtext.color = Color.red;
		else
			foodtext.color = Color.black;
	}

	void CallStartTrainDoggo()
	{
		doggoScript.StartTrainDoggo();
	}

	void CallStartEat()
	{
		doggoScript.StartEat();
	}

	void CallStartSleep()
	{
		doggoScript.StartSleep();
	}

	void CallStartPet()
	{
		doggoScript.StartPet();
	}
	
}
