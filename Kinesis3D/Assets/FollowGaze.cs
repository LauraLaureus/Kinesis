using UnityEngine;
using System.Collections;

public class FollowGaze : MonoBehaviour {

	public void moveTorwards(Vector3 v){

		//TODO ignore Z axis
		this.transform.position = Vector3.MoveTowards (this.transform.position, v, 1 / Mathf.Abs (Vector3.Magnitude (transform.position, v)));
	}
}
