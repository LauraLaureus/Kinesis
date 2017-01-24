﻿using System.Collections;
using UnityEngine;
using Tobii.EyeTracking;


[RequireComponent(typeof(GazeAware))]
public class AtGaze : MonoBehaviour {

    enum State
    {
        LockEveryBodyElse,
        Move,
        Drop,
        End
    };

    

    public GameObject controllerObject;
    public float bubleRadius;
    public int limit;
	public bool dragging;

    private CatchController controller;
    private State currentState;
    private Vector2 lastPosition;
    private GazeAware _gazeAware;
    private Locker locker;
    private Vector3 originalPosition;
	private AudioSource fx;
	private Rigidbody rb;

    public int counter;
	private float distance;

	public GameObject anim;
	private Animator animator;

    // Use this for initialization
    void Start () {
		_gazeAware = GetComponent<GazeAware>();
        locker = GetComponent<Locker>();
        controller = GameObject.Find("CatchController").GetComponent<CatchController>();
        currentState = State.LockEveryBodyElse;
		fx = GetComponent<AudioSource> ();
		animator = anim.GetComponent<Animator> ();
		animator.Stop ();
	}

	// Update is called once per frame
	void Update () {

		if (dragging) {
		
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint (distance);
			rayPoint.z = -1f;
			transform.position = rayPoint;
		}

        
	}

	void OnMouseDown(){
		distance = Vector3.Distance (transform.position, Camera.main.transform.position);
		dragging = true;
		fx.Play();
		if (GetComponent<Rigidbody> () == null) {
			rb =  this.gameObject.AddComponent<Rigidbody>();
			rb.useGravity = false;
			rb.mass = 0f;
			rb.constraints = RigidbodyConstraints.FreezeRotation;
		}
		animator.Play ("Waves");
	}

	void OnMouseUp(){
		dragging = false;
		Drop ();
		animator.Stop ();
	}


    IEnumerator LockEveryBodyElse() {

    if (_gazeAware.HasGazeFocus && !locker.isLocked)
    {
        controller.SendMessage("LockEveryBodyElse", (object)this.gameObject);
        this.gameObject.layer = 27;

		//TODO modificar para colocar la luz. 
        Vector3 increment = new Vector3(1f, 1f, 1f);
        transform.localScale += increment;

        increment = transform.position;
        increment.z = -5f;
        transform.position = increment;


        lastPosition = new Vector2(transform.position.x, transform.position.y);
		//TODO start FX
		
        currentState = State.Move;
    }
        yield return 0;
    }


    IEnumerator Move() {

        Vector3 gazePosition = EyeTracking.GetGazePoint().Screen;


        if (Vector3.Distance(gazePosition, lastPosition) > bubleRadius)
        {
			fx.Stop ();
            currentState = State.Drop;
        }
        else {
            
            gazePosition.z = 0.0f;

            Vector3 nextPosition = Camera.main.ScreenToWorldPoint(gazePosition);

			nextPosition.z = -1.9f;
            this.transform.position = nextPosition;
        }
        yield return 0;
    }


    void Drop() {
		this.gameObject.layer = 27;
		rb.useGravity = true;        
    }


    IEnumerator End() {
        if (this.transform.position.y <= -3f) {
            //TODO FX 
            controller.SendMessage("ReleaseEveryBody");
            Destroy(this.gameObject);
            
        }
        yield return 0;
    }


		

	public void releaseEveryBody(){
		this.controller.SendMessage("ReleaseEveryBody");
	}


	void OnDestroy(){
		releaseEveryBody ();
	}

}
