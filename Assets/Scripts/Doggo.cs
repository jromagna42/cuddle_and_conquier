using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doggo : MonoBehaviour {


	public int health;
	public int power;
	public int tired;
	public int specialgauge;

	bool	training = false;
	Animator anim;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		anim = GetComponent<Animator>();
		health = 10;
		power = 5;
		tired = 0;
		specialgauge = 0;

	}
	
	void TrainDoggo()
	{
		training = true;
		anim.SetBool("training", training);

		

	}

	// Update is called once per frame
	void Update () {
		
	}
}
