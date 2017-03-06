using UnityEngine;
using System.Collections;

public class AttacheableBehaviour : MonoBehaviour {

	public float currentTimeToAttach = 0f;
	public float limit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision c){
	
		Debug.Log("OnCollisionEnter");
		if (currentTimeToAttach < limit) {
			currentTimeToAttach += Time.deltaTime;
		} else {
			c.collider.gameObject.GetComponent<AttachPoint> ().attach(this.gameObject);

		}
			
	}
}
