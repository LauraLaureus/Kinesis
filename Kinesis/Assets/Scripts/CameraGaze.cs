using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class CameraGaze : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject focusedObject = EyeTracking.GetFocusedObject ();
		if (null != focusedObject) {
			Debug.Log (focusedObject.name);
		}

	}
}
