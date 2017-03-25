using UnityEngine;
using System.Collections;

public class PhysicsRayCilinder : MonoBehaviour {

	Ray top,down,right,left,center;
	public float radius = 0.25f;

	// Use this for initialization
	void Start () {
	
		top = new Ray (transform.position, transform.forward);
		down = new Ray (transform.position, transform.forward);
		right = new Ray (transform.position, transform.forward);
		left = new Ray (transform.position, transform.forward);
		center = new Ray (transform.position, transform.forward);
		updateRays ();
	}


	void updateRays(){
	
		top.origin =  transform.position + transform.up *radius;
		down.origin = transform.position - transform.up * radius;
		left.origin = transform.position - transform.right * radius;
		right.origin = transform.position + transform.right * radius;
		center.origin = transform.position;
		Debug.DrawRay (top.origin, top.direction, Color.yellow);
		Debug.DrawRay (down.origin, down.direction, Color.green);
		Debug.DrawRay (left.origin, left.direction, Color.red);
		Debug.DrawRay (right.origin, right.direction, Color.magenta);
		Debug.DrawRay (center.origin,center.direction, Color.blue);
	}

	public bool ForwardCast(out RaycastHit hit){
		updateRays ();
		RaycastHit hitTop, hitDown, hitLeft, hitRight, hitCenter;
		bool castTop, castDown, castLeft, castRight, castCenter;
		castTop = Physics.Raycast (top,out hitTop);
		castDown = Physics.Raycast (down,out hitDown);
		castLeft = Physics.Raycast (left,out hitLeft);
		castRight = Physics.Raycast (right,out hitRight);
		castCenter = Physics.Raycast (center,out hitCenter);

		if (castTop || castRight || castLeft || castDown || castCenter) {
			hit = filterHit (hitTop, hitDown, hitLeft, hitRight, hitCenter);
			return true;
		} else {
			hit = new RaycastHit();
			return false;
		}
	}

	RaycastHit filterHit (RaycastHit hitTop,RaycastHit  hitDown,RaycastHit hitLeft,RaycastHit hitRight,RaycastHit hitCenter){
		Debug.Log ("RayCast");
		if (hitLeft.Equals(null))
			return hitLeft;
		if (hitTop.Equals(null))
			return hitTop;
		if (hitRight.Equals(null))
			return hitRight;
		if (hitDown.Equals(null))
			return hitDown;
		else
			return hitCenter;
	}
}
