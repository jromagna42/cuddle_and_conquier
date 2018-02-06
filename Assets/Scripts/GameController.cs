using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// public GameObject startofgame;
	// public GameObject farmintro;
	// public GameObject conquer;
	// public GameObject startofgame;
	// public GameObject startofgame;
	public GameObject[] loosetab;
	public GameObject[] canvastab;

	void Start () {
		foreach (GameObject go in canvastab)
			go.SetActive(false);
		foreach (GameObject go in loosetab)
			go.SetActive(false);
		// startofgame.SetActive(false);
		// farmintro.SetActive(false);
		// conquer.SetActive(false);
		// DontDestroyOnLoad(this);
	}

	// IEnumerator	LaunchBattle()
	// {
	// 	AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("battle"+GameInfo.stage);
	// 	while (!asyncLoad.isDone)
    //     {
    //         yield return null;
    //     }
	// 	// GameInfo.stageSet = false;
	// 	// Destroy(this);
	// }

	public void	CallLaunchBattle()
	{			
		SceneManager.LoadSceneAsync("battle0"/*+GameInfo.stage*/);
	//	GameInfo.battle = true;
		// StartCoroutine(LaunchBattle());
	}

	// IEnumerator LaunchNotBattle()
	// {
	// 	AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("stage"+GameInfo.stage);
	// 	while (!asyncLoad.isDone)
    //     {
    //         yield return null;
    //     }
	// 	// GameInfo.stageSet = false;
	// 	// Destroy(this);
	// }

	public void	CallLaunchNotBattle()
	{
		GameInfo.battle = false;
		SceneManager.LoadSceneAsync("stage0"/*+GameInfo.stage*/);
		// StartCoroutine(LaunchNotBattle());
		
	}



	void Update()
	{
		if (GameInfo.battle == true)
		{
			if (GameInfo.BattleHealth <= 0)
			{	
				GameInfo.doggolost = true;
				GameInfo.loosecanvasnumber = 0;
				GameInfo.looseactivatenextcanvas = true;
				GameInfo.loosecanvasactivated = false;
				
				CallLaunchNotBattle();
			}
			else if (GameInfo.currentennemyhp <= 0)
			{
				GameInfo.stage++;
				GameInfo.currentennemyhp = 1f;
				CallLaunchNotBattle();
			}
		}
		else
		{
			if (GameInfo.activatenextcanvas == true && GameInfo.canvasnumber < GameInfo.canvasperstage[GameInfo.stage] && GameInfo.doggolost == false && GameInfo.canvasnumber < canvastab.Length)
			{
				canvastab[GameInfo.canvasnumber].SetActive(true);
				GameInfo.activatenextcanvas = false;
				GameInfo.canvasactivated = true;
			}
			if (GameInfo.canvasnumber<16 && GameInfo.canvasactivated == true && Input.GetKeyDown(KeyCode.Space) && GameInfo.canvasnumber < canvastab.Length && GameInfo.doggolost == false)
			{
				canvastab[GameInfo.canvasnumber].SetActive(false);
				GameInfo.activatenextcanvas = true;
				GameInfo.canvasnumber++;
			}

			if (GameInfo.doggolost == true && GameInfo.looseactivatenextcanvas == true)
			{
				loosetab[GameInfo.loosecanvasnumber].SetActive(true);
				GameInfo.loosecanvasactivated = true;
				GameInfo.looseactivatenextcanvas = false;
			}
			if (GameInfo.doggolost == true && Input.GetKeyDown(KeyCode.Space) && GameInfo.loosecanvasactivated == true)
			{
				loosetab[GameInfo.loosecanvasnumber].SetActive(false);
				GameInfo.loosecanvasnumber++;
				GameInfo.looseactivatenextcanvas = true;
				GameInfo.loosecanvasactivated = false;
				if (GameInfo.loosecanvasnumber == 2)
					GameInfo.doggolost = false;
			}

		}
	}
}
