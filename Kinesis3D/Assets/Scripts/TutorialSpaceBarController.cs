using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialSpaceBarController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow))
			SceneManager.LoadScene("Game");
	}
}
