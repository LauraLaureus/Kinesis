using UnityEngine;
using System.Collections;

public class AttachPoint : MonoBehaviour {

	GameObject attached = null;
	Timer timer = null;

	void Start(){
		this.timer = this.gameObject.GetComponent<Timer> ();
		timer.Enable (false);
	}

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

			if (attached == null) {
				attached = hit.collider.gameObject;
				this.timer.Enable (true);
			} 
			else {
				if (attached != hit.collider.gameObject) {
					attached = null;
					timer.Enable (false);
					timer.Reset ();
				} 
				else if(timer.isTimeOut()) {
					attached.GetComponent<FollowGaze> ().moveTorwards (this.transform.position);
				}
			}

			//hit.collider.gameObject.GetComponent<FollowGaze> ().moveTorwards (this.transform.position);
		}else{
			attached = null;
			timer.Enable (false);
			timer.Reset ();
		}
	}


}
