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
		
		Sprite image = other.gameObject.GetComponent<SpriteRenderer>().sprite;

		if (!string.Equals (image.name, GameObject.Find ("RandomDisplay").GetComponent<RandomGenerator> ().getCurrentName ())) {

			Debug.Log("Trigger Entered_ objetos distintos");
			GameObject.Find ("Canvas").GetComponent<FinalLife> ().lifeLoss ();
			GameObject.Find ("RandomDisplay").GetComponent<RandomGenerator> ().Reset ();
			GameObject.Find ("Smoke").GetComponent<SmokeBlower> ().blow ();

		} 
		else {
			GameObject.Find ("RandomDisplay").GetComponent<RandomGenerator> ().Reset ();
			GameObject.Find ("Smoke").GetComponent<SmokeBlower> ().blow ();
			Debug.Log(other.gameObject.name);

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
