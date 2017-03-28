using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotDetector : MonoBehaviour {


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

		GameObject.Find ("PlayerGaze").GetComponent<AttachPoint> ().deattach ();
		Destroy (other.gameObject);
    

    }

   
}
