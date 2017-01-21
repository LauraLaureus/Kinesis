using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomGenerator : MonoBehaviour {

    public Sprite[] ingredients;
    public float seconds;
    public float timeElapsed;

    private int currentIndex;

    enum States {
        Wait,
        ChangePic
    }

    private States currentState;
    private Image image;
	// Use this for initialization
	void Start () {
        image = this.gameObject.GetComponent<Image>();
        currentState = States.ChangePic;
        timeElapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(currentState.ToString());
	}

    IEnumerator Wait() {
        if (timeElapsed >= seconds)
        {
            timeElapsed = 0;
            currentState = States.ChangePic;
        }
        else {
            timeElapsed += Time.deltaTime;
        }

        yield return 0;
    }

    IEnumerator ChangePic() {
		changePicture ();
        yield return 0;
    }

	private void changePicture(){
		currentIndex = (int)(Random.value * ingredients.Length);
		image.sprite = ingredients[currentIndex];
		currentState = States.Wait;
	}
    public string getCurrentName() {
        return ingredients[currentIndex].name;
    }

	public void next(){
		changePicture ();
	}
}
