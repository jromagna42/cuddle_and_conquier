using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choosebadguys : MonoBehaviour {

	public GameObject[] ennemylist;

	// Use this for initialization
	void Start () {
		foreach(GameObject go in ennemylist)
			go.SetActive(false);
		ennemylist[GameInfo.stage].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
