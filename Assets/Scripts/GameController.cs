using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject startofgame;
	public GameObject farmintro;
	public GameObject conquer;
	// public GameObject startofgame;
	// public GameObject startofgame;
	

	void Start () {
		startofgame.SetActive(false);
		farmintro.SetActive(false);
		conquer.SetActive(false);

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
	IEnumerator StartofgameCoroutine()
	{
		int i = 0;
		GameObject[] starttab = new GameObject[] {startofgame,farmintro,conquer};
		while (i < starttab.Length)
		{
			print("sdf");
			starttab[i].SetActive(true);
			while (!Input.GetKeyDown(KeyCode.Space))
				
			starttab[i].SetActive(false);
			i++;
		}
		return(null);
	}

	public void	CallLaunchNotBattle()
	{
		SceneManager.LoadSceneAsync("stage0"/*+GameInfo.stage*/);
		// StartCoroutine(LaunchNotBattle());
		GameInfo.battle = false;
	}

	void Update()
	{
		if (GameInfo.battle == true)
		{
			if (GameInfo.BattleHealth <= 0)
			{
				GameInfo.doggolost = true;
				CallLaunchNotBattle();
			}
			else if (GameInfo.currentennemyhp <= 0)
			{
				GameInfo.stage++;
				CallLaunchNotBattle();
			}
		}
		else
		{
			if (GameInfo.startofgame == false)
			{
				StartCoroutine(StartofgameCoroutine());
				GameInfo.startofgame = true;
			}
		}
	}
}
