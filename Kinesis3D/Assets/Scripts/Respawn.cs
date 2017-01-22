using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	enum State{
		Wait,
		Spawn
	}

	private State currentState;
	public float limit;
	public float current;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		currentState = State.Wait;
		current = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Physics.Raycast(this.transform.position, Vector3.back, 1f)){
			StartCoroutine (currentState.ToString ());
		}
	}

	IEnumerator Wait(){

		current += Time.deltaTime;
		if (current >= limit) {
			current = 0f;
			currentState = State.Spawn;
		}
		yield return 0;
	}

	IEnumerator Spawn(){
		Instantiate (prefab, this.transform.position, Quaternion.identity);
		GameObject.Find("CatchController").GetComponent<CatchController>().SendMessage("LockEveryBodyElse", (object)this.gameObject);
		currentState = State.Wait;
		yield return 0;
	}
}
