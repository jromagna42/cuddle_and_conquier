using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{	Debug.Log("col");
		Destroy(other.gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("trig");
		Destroy(other.gameObject);
	}
}
