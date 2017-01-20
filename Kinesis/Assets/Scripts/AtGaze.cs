using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;


[RequireComponent(typeof(GazeAware))]
public class AtGaze : MonoBehaviour {

	private GazeAware _gazeAware;
	// Use this for initialization
	void Start () {
		_gazeAware = GetComponent<GazeAware>();
	}

	// Update is called once per frame
	void Update () {

		Debug.Log (_gazeAware.HasGazeFocus);
		if(_gazeAware.HasGazeFocus){
			//traer a otra capa.
			this.gameObject.layer = 27;

			Debug.Log("ECOOOOOOOO");
			//ampliar el objeto. 
			Vector3 increment =  new Vector3(0.3f,0.3f,0.3f);
			transform.localScale += increment;
			//GetComponent<Renderer>().bounds.size = GetComponent<Renderer>().bounds.size + increment ;
		}
		
	}
}
