using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class GazePlot : MonoBehaviour {

	public float smoothFactor;
	public GazePoint gazePoint;

	//NOT USING 26/03/2017
	float smoothFunction(){
		return smoothFactor * (1 / (1f+ Mathf.Abs (Vector3.Distance (transform.position, ProjectToPlaneInWorld (gazePoint)))));
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

		if (gazePoint != GazePoint.Invalid) {
			Vector3 destiny = ProjectToPlaneInWorld (gazePoint);
			transform.position = Vector3.MoveTowards (transform.position,destiny, smoothFunction());
		}
			
	}


}
