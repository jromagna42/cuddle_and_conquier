using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnenyScript : MonoBehaviour {

	public	GameObject projectile;
	float 	nextshot;
	float	shoottimer = 0f;


	void Start () {
		GameInfo.battle = true;
		GameInfo.maxennemyhp = GameInfo.ennemyLifeTab[GameInfo.stage];
		GameInfo.currentennemyhp = GameInfo.ennemyLifeTab[GameInfo.stage];
	}
	
	void	Shoot()
	{
		Instantiate(projectile, transform.position, transform.rotation);
		shoottimer = 0;
		nextshot = Random.Range(0, GameInfo.ennemyspeedTab[GameInfo.stage]);
	}

	void Update () {
		shoottimer += Time.deltaTime;
		if (shoottimer > nextshot)
			Shoot();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
	//s	Debug.Log("triger" + other.tag);
		if (other.tag == "woof")
		{
			GameInfo.currentennemyhp -= GameInfo.power;
		}
		if (other.tag == "superwoof")
		{
			GameInfo.currentennemyhp -= GameInfo.power * 10;
		}
	}
}
