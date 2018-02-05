using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	void Start () {
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
		SceneManager.LoadSceneAsync("battle"+GameInfo.stage);
		
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
		SceneManager.LoadSceneAsync("stage"+GameInfo.stage);
		// StartCoroutine(LaunchNotBattle());
	}
}
