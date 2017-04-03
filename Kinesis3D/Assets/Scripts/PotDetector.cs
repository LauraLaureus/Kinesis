using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotDetector : MonoBehaviour {

	AudioSource audio;

	void Start(){
		this.audio = this.gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other)
    {
		
		string image = other.gameObject.GetComponent<SpriteRenderer>().sprite.name;

		if (!string.Equals (image, GameObject.Find ("RandomDisplay").GetComponent<RandomGenerator> ().getCurrentName ())) {

			GameObject.Find ("Canvas").GetComponent<FinalLife> ().lifeLoss ();
			GameObject.Find ("RandomDisplay").GetComponent<RandomGenerator> ().Reset ();
			GameObject.Find ("Smoke").GetComponent<SmokeBlower> ().blow ();

		} 
		else {
			GameObject.Find ("RandomDisplay").GetComponent<RandomGenerator> ().Reset ();
			GameObject.Find ("Smoke").GetComponent<SmokeBlower> ().right ();

		}
		this.audio.enabled = true;
		GameObject.Find ("PlayerGaze").GetComponent<AttachPoint> ().deattach ();
		Destroy (other.gameObject);
	

    }

	void FixedUpdate(){
		if(this.audio.enabled && !this.audio.isPlaying)
			this.audio.enabled = false;
	}
   
}
