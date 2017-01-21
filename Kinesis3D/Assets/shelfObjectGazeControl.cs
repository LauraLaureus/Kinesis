using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;


public class shelfObjectGazeControl : MonoBehaviour {

    private GazeAware _gazeAware;

    // Use this for initialization
    void Start () {
        _gazeAware = GetComponent<GazeAware>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_gazeAware.HasGazeFocus)
        {
            Debug.Log("OK");
        }
        else
            Debug.Log("ERROR");
    }
}
