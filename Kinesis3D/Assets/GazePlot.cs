using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class GazePlot : MonoBehaviour {


	private Vector3 previousPoint = Vector3.zero;
	private bool hasPrevious = false;
	public float smoothFactor;
	public GazePoint gazePoint;

	public Vector3 smoothify(Vector3 point){
		if (!hasPrevious) {
			previousPoint = point;
			hasPrevious = true;
		}


		Vector3 smoothedPoint = new Vector3 (
			point.x * (1-smoothFactor)+ previousPoint.x*smoothFactor,
			point.y * (1-smoothFactor)+ previousPoint.y*smoothFactor,
			point.z * (1-smoothFactor)+ previousPoint.z*smoothFactor
		);

		previousPoint = smoothedPoint;
		return smoothedPoint;
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
			transform.position = Vector3.MoveTowards (transform.position, ProjectToPlaneInWorld (gazePoint), smoothFactor);
	}


}
