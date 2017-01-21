using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotDetector : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        Sprite image = other.gameObject.GetComponent<SpriteRenderer>().sprite;
		if (!string.Equals (image.name, GameObject.Find ("Image").GetComponent<RandomGenerator> ().getCurrentName ())) {
			//TODO si el objetos es incorrecto Quitar una vida.
			Debug.Log("Trigger Entered_ objetos distintos");
		} 
		else {
			//si el objeto es correcto decirle que cree un lazy spawn
			Debug.Log("Trigger Entered_ objetos iguales");
		}
       


    }

   
}
