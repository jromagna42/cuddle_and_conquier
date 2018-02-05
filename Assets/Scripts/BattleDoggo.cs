using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class	BattleDoggo : MonoBehaviour {

	public GameObject woof;
	public GameObject superWoof;
	Animator	anim;
	bool		jumping;
	float		jumptimer = 0f;
	float		jumpDuration = 1.5f;

	float		smallWooftimer = 0f;
	float		smallWoofCD = 0.5f;
	bool		canSmallWoof = false;

	float		superWooftimer = 0f;
	float		superWoofCD = 10f;
	bool		canSuperWoof = false;

	void		Start()
	{
		anim = GetComponent<Animator>();
	}

	void		Jump()
	{
		jumping = true;
		anim.SetBool("jumping",true);
		jumptimer = 0f;
	}

	void		SuperWoof()
	{
		Instantiate(superWoof, transform.position, transform.rotation);
		superWooftimer = 0f;
		canSuperWoof = false;
	}

	void		SmallWoof()
	{
		Instantiate(woof, transform.position, transform.rotation);
		smallWooftimer = 0f;
		canSmallWoof = false;
	}

	void		CheckAction()
	{
		transform.position = Vector3.zero;
		if (smallWooftimer > smallWoofCD)
			canSmallWoof = true;
		if (superWooftimer > superWoofCD)
			canSuperWoof = true;
		if (jumptimer > jumpDuration)
		{
			jumping = false; 
			anim.SetBool("jumping",false);
		}
	}
	// Update is called once per frame
	void		Update () {
		if (Input.GetKeyDown(KeyCode.Space) & jumping == false)
		{
			Jump();
		}
		if (Input.GetKeyDown(KeyCode.B) & canSuperWoof == true)
		{
			SuperWoof();
		}
		if (Input.GetKeyDown(KeyCode.Mouse0) & canSmallWoof == true)
		{
			SmallWoof();
		}
		jumptimer += Time.deltaTime;
		smallWooftimer += Time.deltaTime;
		superWooftimer += Time.deltaTime;
		CheckAction();
	}
}
