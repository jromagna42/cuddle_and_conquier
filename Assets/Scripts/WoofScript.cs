using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoofScript : MonoBehaviour {

	float	speed = 10f;
	float	deathTimer = 0f;

	void Update () {
		transform.position = transform.position + (speed * Vector3.right * Time.deltaTime);
		deathTimer += Time.deltaTime;
		if (deathTimer > 5f)
			Destroy(this);
	}
}
