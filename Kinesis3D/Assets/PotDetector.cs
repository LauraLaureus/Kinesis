using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotDetector : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        Sprite image = other.gameObject.GetComponent<Image>().sprite;
        if (!string.Equals(image.name, GameObject.Find("Image").GetComponent<RandomGenerator>().getCurrentName())){
            //TODO si el objetos es incorrecto something
        }
        //si el objeto es correcto nothing

    }

   
}
