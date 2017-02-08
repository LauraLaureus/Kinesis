using UnityEngine;
using System.Collections;

public class ShelfObjectController : MonoBehaviour {

	public GameObject shelfObject;
	private GameObject instance;

	private float timeElapsed = 0;
	public float timeThreshold;

	private bool countTimeEnabled = false;

	// Use this for initialization
	void Start () {
		instance = (GameObject) Instantiate (shelfObject, this.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (instance == null && timeElapsed > timeThreshold)
			spawn ();
		else if (instance == null)
			countTimeEnabled = true;

		if (countTimeEnabled)
			timeElapsed += Time.deltaTime;
	}

	void spawn(){
		instance = (GameObject) Instantiate (shelfObject, this.transform.position, Quaternion.identity);
		timeElapsed = 0;
		countTimeEnabled = false;
	}
}
