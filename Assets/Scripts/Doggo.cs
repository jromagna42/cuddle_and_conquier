using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doggo : MonoBehaviour {

	public GameObject gammelle;
	public GameObject bed;
	public GameObject zzz;
	public GameObject hand;
	


	public float mult = 1;
	public int animspeed = 1;

	float	actiontimer = 0f;

	bool	sleeping = false;
	float	sleepingTimer = 6f;

	bool	petting = false;
	float	pettingTimer = 3f;

	bool	eating = false;
	float	eatingTimer = 4f;


	int stage = 0;

	bool[]	training = new bool[] {false, false, false, false, false};
	float[] trainingTimer = new float[] { 4f, 3f, 5f, 7f, 9f};


	Animator anim;
	// Use this for initialization
	void	Start () {
		SetNotBattle();
		// SetBattle();
	}

	void	SetNotBattle()
	{
		if (gammelle != null)
		{
			anim = GetComponent<Animator>();
			gammelle.SetActive(false);
			bed.SetActive(false);
			zzz.SetActive(false);
			hand.SetActive(false);
			// GameInfo.stageSet = true;
		}
	}

	// public GameObject battledoggo;
	// void	SetBattle()
	// {
	// 	Debug.Log("SetBattle");
	// 	// SpriteRenderer sr = GetComponent<SpriteRenderer>();
	// 	// SpriteRenderer srbat = battledoggo.GetComponent<SpriteRenderer>();
	// 	// sr.sprite = srbat.sprite;
	// 	GameInfo.stageSet = true;
	// }

	bool 	IsIdle()
	{
		if (training[stage] == true || sleeping == true || petting == true || eating == true)
			return false;
		return true;
	}
	


	public void StartTrainDoggo()
	{
		if (IsIdle() == false)
			return;
		training[stage] = true;
		anim.SetBool("training" + stage, training[stage]);
		actiontimer = 0f;
		
	}

	public void StartEat()
	{
		if (IsIdle() == false)
			return;
		eating = true;
		anim.SetBool("eating", eating);
		gammelle.SetActive(true);
		actiontimer = 0f;
	}

	public void StartSleep()
	{
		if (IsIdle() == false)
			return;
		sleeping = true;
		anim.SetBool("sleeping", sleeping);
		bed.SetActive(true);
		zzz.SetActive(true);
		actiontimer = 0f;
		
	}

	public void StartPet()
	{
		if (IsIdle() == false)
			return;
		petting = true;
		anim.SetBool("petting", petting);
		hand.SetActive(true);
		actiontimer = 0f;
	}

	void TrainDoggo()
	{
		if (actiontimer > trainingTimer[stage] * animspeed)
		{
			GameInfo.power += 10 * mult;
			GameInfo.health += 10 * mult;
			GameInfo.fatigue += 10;
			GameInfo.food -= 25;
			if (GameInfo.food <= 0)
				GameInfo.food = 0;
			training[stage] = false;
			anim.SetBool("training" + stage, training[stage]);
		}
	}

	void Eat()
	{
		if (actiontimer > eatingTimer * animspeed)
		{
			GameInfo.food += 50;
			if (GameInfo.food > 100)
				GameInfo.food = 100;
			eating = false;
			gammelle.SetActive(false);
			anim.SetBool("eating", eating);
		}
	}

	void Sleep()
	{
		if (actiontimer > sleepingTimer * animspeed)
		{
			GameInfo.fatigue -= 50;
			if (GameInfo.fatigue < 0)
				GameInfo.fatigue = 0;
			sleeping = false;
			anim.SetBool("sleeping", sleeping);
			bed.SetActive(false);
			zzz.SetActive(false);
		}
	}

	void Pet()
	{
		if (actiontimer > pettingTimer * animspeed)
		{
			if (GameInfo.fatigue < 100)
				GameInfo.specialgauge += 1;
			mult = (1 + (GameInfo.specialgauge * 0.8f)) * ((GameInfo.food / 100) + 0.3f);
			GameInfo.fatigue += 50;
			petting = false;
			anim.SetBool("petting", petting);
			hand.SetActive(false);
		}
	}

	void CheckAction()
	{
		if (training[stage] == true)
			TrainDoggo();
		if (eating == true)
			Eat();
		if (sleeping == true)
			Sleep();
		if (petting == true)
			Pet();
		mult = (1 + (GameInfo.specialgauge * 0.8f)) * ((GameInfo.food / 100) + 0.3f);
		if (GameInfo.fatigue > 100)
			animspeed = 2;
		else
			animspeed = 1;
	}

	// Update is called once per frame
	void Update () {

		// if (GameInfo.battle == false)
		// {
			// if (GameInfo.stageSet == false)
			// 	SetNotBattle();
			actiontimer += Time.deltaTime;
			CheckAction();
		// }
		// if (GameInfo.battle == true)
		// {
		// 	if (GameInfo.stageSet == false)
		// 		SetBattle();
		// }
	}
}
