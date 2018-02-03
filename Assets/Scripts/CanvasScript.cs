using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

	public GameObject player;
	Doggo	doggoScript;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		doggoScript = player.GetComponent<Doggo>();
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
