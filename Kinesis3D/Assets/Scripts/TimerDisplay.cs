using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour {

	public Text display;
	public float limit;
	public float current;

	// Use this for initialization
	void Start () {
		display = this.GetComponent<Text> ();
	}

	public void Reset(){
		GameObject.Find ("RandomDisplay").GetComponent<RandomGenerator> ().timeElapsed = 0f;
		display.text = (0f).ToString("F2");
	}

	// Update is called once per frame
	void Update () {
	
		// actualizar los dos parámetros
		limit = GameObject.Find("RandomDisplay").GetComponent<RandomGenerator>().seconds;
		current = GameObject.Find("RandomDisplay").GetComponent<RandomGenerator> ().timeElapsed;

		// mostrar los segundos restantes en el texto
		display.text = (limit - current).ToString("F2");
	}
}
