using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttachedTimer : MonoBehaviour {

	Text text;
	public GameObject timerObject;
	Timer timer;
	public GameObject anchorObject;

	// Use this for initialization
	void Start () {
		timer = timerObject.GetComponent<Timer> ();
		text = GetComponent<Text> ();
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.queryEnabled ()) {
			text.enabled = true;
			if (!timer.isTimeOut ())
				text.text = (timer.limit - timer.current).ToString ("F2");
		} 
		else {
			text.text = "";
			text.enabled = false;
		}

		Vector3 displacement = Vector3.right * 0.8f;
		this.transform.position = Camera.main.WorldToScreenPoint( anchorObject.transform.position + displacement);
	}
}
