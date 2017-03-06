using UnityEngine;
using System.Collections;

public partial class AtGaze: MonoBehaviour {

	private static  Vector3 previousPoint = Vector3.zero;
	private static bool hasPrevious = false;
	public static float smoothFactor;

	public static Vector3 smoothify(Vector3 point){
		if (!hasPrevious) {
			previousPoint = point;
		}

		Vector3 smoothedPoint = new Vector3 (
			point.x * (1-smoothFactor)+ previousPoint.x*smoothFactor,
			point.y * (1-smoothFactor)+ previousPoint.y*smoothFactor,
			point.z * (1-smoothFactor)+ previousPoint.z*smoothFactor
		);
		return smoothedPoint;
	}
}
