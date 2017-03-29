using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	Timer timer;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		timer = this.GetComponent<Timer> ();
		timer.limit += Random.value*10f;
	}


	// Update is called once per frame
	void Update () {
		if (!Physics.Raycast (this.transform.position, Vector3.back, 1f)) {
			timer.Enable (true);

			if (timer.isTimeOut ()) {
				Debug.Log ("Pawn");
				Vector3 displacement = Vector3.back * 0.2f;
				Instantiate (prefab, this.transform.position+displacement, Quaternion.identity);
				timer.Enable (false);
				timer.Reset ();
			}


		} 
	}

}
