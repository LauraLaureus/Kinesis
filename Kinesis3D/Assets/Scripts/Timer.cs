using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float limit;
	public float current;
	private bool isEnabled;
	private bool isPhysicsDeltaTime;

	public void Reset(){
		this.current = 0;
	}
		
	public void Enable(bool enable){
		this.isEnabled = enable;
	}

	public bool queryEnabled(){
		return isEnabled;
	}

	// Use this for initialization
	void Start () {
		this.isEnabled = false;
		this.current = 0f;
	}

	public bool isTimeOut(){
		return this.current >= this.limit;
	}

	public void setPhysicsDeltaTime(bool phy){
		this.isPhysicsDeltaTime = phy;
	}

	// Update is called once per frame
	void Update () {
		if (isEnabled && !isPhysicsDeltaTime) {
			this.current += Time.deltaTime;
		}
		//Debug.Log ("Timer: " + this.current.ToString ());
	}

	void FixedUpdate(){
		if (isEnabled && isPhysicsDeltaTime) {
			this.current += Time.fixedDeltaTime;
		}
		Debug.Log ("Physics Timer: " + this.current.ToString ());
	
	}
}
