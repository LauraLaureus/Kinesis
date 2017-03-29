using UnityEngine;
using System.Collections;

public class ParticleSystemEnable : MonoBehaviour {

	GameObject child;

	void Start(){
		child = this.transform.GetChild (0).gameObject;
	}

	public void enableParticleSystem(bool b){
		child.SetActive (b);
	}
}
