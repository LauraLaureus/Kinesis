using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	public void pause(bool pause){

		if (pause)
			onPause ();
		else
			onResume ();
	}

	void onPause(){
		Time.timeScale = 0;
		pauseMenu.SetActive(true);
	}

	void onResume(){
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
	}
}
