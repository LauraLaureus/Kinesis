using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttachedTimer : MonoBehaviour {

	Text text;
	Timer timer;

	// Use this for initialization
	void Start () {
		timer = GetComponentInParent<Timer> ();
		text = GetComponent<Text> ();
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.queryEnabled ()) {
			text.enabled = true;
			if(!timer.isTimeOut())
				text.text = (timer.limit - timer.current).ToString("F2");
		}
	}
}
