using UnityEngine;
using System.Collections;

public class FollowGaze : MonoBehaviour {

	public void moveTorwards(Vector3 v){
		this.transform.position = new Vector3(v.x,v.y,-10f);
	}

}
