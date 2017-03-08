using UnityEngine;
using System.Collections;

public class AttachPoint : MonoBehaviour {

	GameObject attached = null;

	public void attach(GameObject sceneObject){
		attached = sceneObject;
	}

	public void deattach(){
		attached = null;
	}
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (this.transform.position, Vector3.forward, out hit)) {
			Debug.Log ("Raycast hit!");
			hit.collider.gameObject.GetComponent<FollowGaze> ().moveTorwards (this.transform.position);
		}
	}
}
