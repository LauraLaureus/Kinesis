using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour {

	public Text display;
	public float limit;
	public float current;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// actualizar los dos parámetros
		limit = this.gameObject.GetComponent<RandomGenerator>().seconds;
		current = this.gameObject.GetComponent<RandomGenerator> ().timeElapsed;

		// mostrar los segundos restantes en el texto
		display.text = (limit - current).ToString("F2");
	}
}
