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
		attached.GetComponent<ParticleSystemEnable> ().enableParticleSystem (false,true);
		//Destroy (attached);
		attached.GetComponent<FollowGaze>().fall();
		attached = null;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			this.deattach ();
		}

		RaycastHit hit;

		if (this.GetComponent<PhysicsRayCilinder> ().ForwardCast (out hit) && this.attached == null) {
			timer.Enable (true);

			if (attached == null && hit.collider.gameObject != null) {
				hit.collider.gameObject.GetComponent<FollowGaze>().illuminate();
			}

			if (timer.isTimeOut ()) {
				if (attached == null && hit.collider.gameObject != null) {
					attach (hit.collider.gameObject);
					attached.GetComponent<ParticleSystemEnable> ().enableParticleSystem (true,true);
				}
					
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
