using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class GazePlot : MonoBehaviour {

	public float smoothFactor;
	public GazePoint gazePoint;

	float smoothFunction(){
		return smoothFactor * (1 / (0.0001f+ Mathf.Abs (Vector3.Distance (transform.position, ProjectToPlaneInWorld (gazePoint)))));
	}

	private Vector3 ProjectToPlaneInWorld(GazePoint gazePoint)
	{
		Vector3 gazeOnScreen = gazePoint.Screen;
		gazeOnScreen += (transform.forward * 0f);
		return Camera.main.ScreenToWorldPoint(gazeOnScreen);
	}
		
	// Update is called once per frame
	void Update () {
		gazePoint = EyeTracking.GetGazePoint();

		if(gazePoint != GazePoint.Invalid)
			transform.position = Vector3.MoveTowards (transform.position, ProjectToPlaneInWorld (gazePoint), smoothFunction());
	}


}
