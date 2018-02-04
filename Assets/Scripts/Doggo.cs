using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doggo : MonoBehaviour {

	public GameObject gammelle;
	public GameObject bed;
	public GameObject zzz;
	public GameObject hand;

	public float health;

	public float power;

	public float mult = 1;
	
	public float fatigue;
	public int slowanim = 1;
	
	public float food;
	
	public float specialgauge;

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
	void Start () {
		DontDestroyOnLoad(this);
		gammelle.SetActive(false);
		bed.SetActive(false);
		zzz.SetActive(false);
		hand.SetActive(false);
		anim = GetComponent<Animator>();
		health = 10;
		power = 5;
		fatigue = 0;
		food = 100;
		specialgauge = 0;
		Debug.Log("training" + stage);
	}

	bool IsIdle()
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
		if (actiontimer > trainingTimer[stage] * slowanim)
		{
			power += 10 * mult;
			health += 10 * mult;
			fatigue += 10;
			food -= 25;
			if (food <= 0)
				food = 0;
			training[stage] = false;
			anim.SetBool("training" + stage, training[stage]);
		}
	}

	void Eat()
	{
		if (actiontimer > eatingTimer * slowanim)
		{
			food += 50;
			if (food > 100)
				food = 100;
			eating = false;
			gammelle.SetActive(false);
			anim.SetBool("eating", eating);
		}
	}

	void Sleep()
	{
		if (actiontimer > sleepingTimer * slowanim)
		{
			fatigue -= 50;
			if (fatigue < 0)
				fatigue = 0;
			sleeping = false;
			anim.SetBool("sleeping", sleeping);
			bed.SetActive(false);
			zzz.SetActive(false);
		}
	}

	void Pet()
	{
		if (actiontimer > pettingTimer * slowanim)
		{
			if (fatigue < 100)
				specialgauge += 1;
			mult = (1 + (specialgauge * 0.8f)) * ((food / 100) + 0.3f);
			fatigue += 50;
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
		mult = (1 + (specialgauge * 0.8f)) * ((food / 100) + 0.3f);
		if (fatigue > 100)
			slowanim = 2;
		else
			slowanim = 1;
	}

	// Update is called once per frame
	void Update () {
		actiontimer += Time.deltaTime;
		CheckAction();
	}
}
