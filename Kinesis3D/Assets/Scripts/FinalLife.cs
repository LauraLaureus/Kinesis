using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalLife : MonoBehaviour {
	private int life;
	public GameObject[] lifes;


	// Use this for initialization
	void Start () {
		life = 3;
	}

	public void lifeLoss(){
		life--;
		lifes [life].SetActive (false);

		if (life == 0) {
			SceneManager.LoadScene ("GameOver"); 
		}
	}
}