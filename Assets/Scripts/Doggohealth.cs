﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doggohealth : MonoBehaviour {

	Image img;

	void Start()
	{
		img = GetComponent<Image>();
	}

	void Update () {
		// Debug.Log(GameInfo.health+ "  " + GameInfo.BattleHealth+ "  " + GameInfo.health / GameInfo.BattleHealth);
		img.fillAmount = GameInfo.BattleHealth / GameInfo.health;
	}
}
