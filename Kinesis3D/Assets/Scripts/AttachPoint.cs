using UnityEngine;
using System.Collections;

public class AttachPoint : MonoBehaviour {

	GameObject attached = null;
	Timer timer = null;

	void Start(){
		this.timer = this.gameObject.GetComponent<Timer> ();
		timer.Enable (false);
		timer.setPhysicsDeltaTime (true);
	}

	public void attach(GameObject sceneObject){
		attached = sceneObject;
	}

	public void deattach(){
		attached = null;
	}

	// Update is called once per frame
	void FixedUpdate () {

		RaycastHit hit;

		if (this.GetComponent<PhysicsRayCilinder> ().ForwardCast (out hit)) {
			timer.Enable (true);

			if (timer.isTimeOut ()) {
				if(attached == null)
					attach (hit.collider.gameObject);
				attached.GetComponent<FollowGaze> ().moveTorwards (transform.position);
			}
			
		} else {
			timer.Enable (false);
			timer.Reset ();
			if(attached != null)
				attached.GetComponent<FollowGaze> ().moveTorwards (transform.position);
		}


	}


}
