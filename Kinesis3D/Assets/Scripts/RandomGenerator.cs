using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomGenerator : MonoBehaviour {

    public Sprite[] ingredients;
    public float seconds;
    public float timeElapsed;

    private int currentIndex;

    
    private Image image;
	// Use this for initialization
	void Start () {
        image = this.gameObject.GetComponent<Image>();
        timeElapsed = 0;
		changePicture ();
	}
	
	// Update is called once per frame
	void Update () {
        
		if (timeElapsed >= seconds)
		{
			timeElapsed = 0;
			changePicture();
		}
		else {
			timeElapsed += Time.deltaTime;
		}

	}
		
	public void Reset(){
		changePicture ();
		timeElapsed = 0f;
	}

	private void changePicture(){
		currentIndex = (int)(Random.value * ingredients.Length);
		image.sprite = ingredients[currentIndex];
	}


    public string getCurrentName() {
        return ingredients[currentIndex].name;
    }

	public void next(){
		changePicture ();
	}
}
