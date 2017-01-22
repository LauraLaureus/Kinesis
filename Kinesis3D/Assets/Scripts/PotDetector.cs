using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotDetector : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        Sprite image = other.gameObject.GetComponent<SpriteRenderer>().sprite;
		if (!string.Equals (image.name, GameObject.Find ("Image").GetComponent<RandomGenerator> ().getCurrentName ())) {
			
			Debug.Log("Trigger Entered_ objetos distintos");
			GameObject.Find ("Canvas").GetComponent<FinalLife> ().lifeLoss ();
			Destroy (other.gameObject);
		} 
		else {
			GameObject.Find ("Image").GetComponent<RandomGenerator> ().next();
			Debug.Log(other.gameObject.name);
			Destroy (other.gameObject);
			Debug.Log("Trigger Entered_ objetos iguales");
		}
       


    }

   
}
