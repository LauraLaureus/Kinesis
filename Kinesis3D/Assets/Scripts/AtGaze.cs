using System.Collections;
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

    private CatchController controller;
    private State currentState;
    private Vector2 lastPosition;
    private GazeAware _gazeAware;
    private Locker locker;
    private Vector3 originalPosition;
    public int counter;

    // Use this for initialization
    void Start () {
		_gazeAware = GetComponent<GazeAware>();
        locker = GetComponent<Locker>();
        controller = GameObject.Find("CatchController").GetComponent<CatchController>();
        currentState = State.LockEveryBodyElse;
	}

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = State.Drop;
        }

        StartCoroutine(currentState.ToString());
        Debug.Log(locker.isLocked);

        
	}

    IEnumerator LockEveryBodyElse() {

    if (_gazeAware.HasGazeFocus && !locker.isLocked)
    {
        controller.SendMessage("LockEveryBodyElse", (object)this.gameObject);
        this.gameObject.layer = 27;

        Vector3 increment = new Vector3(2f, 2f, 2f);
        transform.localScale += increment;

        increment = transform.position;
        increment.z = -5f;
        transform.position = increment;


        lastPosition = new Vector2(transform.position.x, transform.position.y);
        currentState = State.Move;
    }
        yield return 0;
    }


    IEnumerator Move() {

        Vector3 gazePosition = EyeTracking.GetGazePoint().Screen;


        Debug.Log(Vector3.Distance(gazePosition, lastPosition));
        if (Vector3.Distance(gazePosition, lastPosition) > bubleRadius)
        {
            currentState = State.Drop;
        }
        else {
            Debug.Log(gazePosition.ToString());
            gazePosition.z = -1f;
            //gazePosition += (transform.forward * (-2f));
            Vector3 nextPosition = Camera.main.ScreenToWorldPoint(gazePosition);

            this.transform.position = nextPosition;
        }
        yield return 0;
    }


    IEnumerator Drop() {
        //drop
        Debug.Log("Me has abandonado");

        Rigidbody rb =  this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;

        currentState = State.End;
        yield return 0;
        
    }


    IEnumerator End() {
        if (this.transform.position.y <= -3f) {
            //TODO FX 
            controller.SendMessage("ReleaseEveryBody");
            currentState = State.LockEveryBodyElse;
            Destroy(this.gameObject);
            
        }
        yield return 0;
    }

}
