using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBullet : MonoBehaviour {

	float				speed = 6;
	Vector3				dir;
	float				deathTimer = 0f;

	void Start () {
		dir = (GameInfo.battledoggopos - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + (speed * dir * Time.deltaTime);
		deathTimer += Time.deltaTime;
		if (deathTimer > 5f)
			Destroy(this.gameObject);
	}
}
