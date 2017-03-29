using UnityEngine;
using System.Collections;

public class FollowGaze : MonoBehaviour {

	public void moveTorwards(Vector3 v){
		this.transform.position = new Vector3(v.x,v.y,-10.5f);
	}

	public void fall(){
		this.gameObject.AddComponent<Rigidbody> ();
	}

	void OnBecameInvisible(){
		this.GetComponent<AudioSource> ().enabled = true;
	}
}
