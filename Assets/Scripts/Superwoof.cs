using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Superwoof : MonoBehaviour {
	Image img;
	public GameObject doggo;
	BattleDoggo scriptdoggo;

	void Start()
	{
		img = GetComponent<Image>();
		scriptdoggo = doggo.GetComponent<BattleDoggo>();
	}

	void Update () {
		// Debug.Log(GameInfo.health+ "  " + GameInfo.BattleHealth+ "  " + GameInfo.health / GameInfo.BattleHealth);
		img.fillAmount = scriptdoggo.superWooftimer / scriptdoggo.superWoofCD;
		if (scriptdoggo.canSuperWoof == true)
			img.color = Color.green;
		else
			img.color = Color.yellow;
	}
}

