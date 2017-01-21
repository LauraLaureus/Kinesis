using UnityEngine;
using System.Collections;

public class CatchController : MonoBehaviour {

    public delegate void LockEverbody(GameObject sender);
    public static event LockEverbody lockThem;

    public delegate void ReleaseEverybody();
    public static event ReleaseEverybody releaseThem;


     void LockEveryBodyElse(GameObject sender) {
        //Mandar un evento a todos aquellos que sean objetos capturables excepto aquel que manda el mensaje
        if (lockThem != null)
            lockThem(sender);
    }

    void ReleaseEveryBody() {
        if (releaseThem != null)
            releaseThem();
    }

    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
