using UnityEngine;
using System.Collections;

public class ParticleSystemEnable : MonoBehaviour {

	GameObject child;
	bool restoreNeeded = false;

	void Start(){
		child = this.transform.GetChild (0).gameObject;
	}

	public void enableParticleSystem(bool b,bool loop){
		child.SetActive (b);
		if (!loop) {
			child.GetComponent<ParticleSystem> ().loop = loop;
		}
	}

	void FixedUpdate(){
	
		if (restoreNeeded) {
			child.GetComponent<ParticleSystem> ().loop = true;
			child.SetActive (false);
			restoreNeeded = false;
		}
	}
}
