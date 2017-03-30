using UnityEngine;
using System.Collections;

public class ParticleSystemController : MonoBehaviour {

	public int maxIterations;
	public int iterations;
	ParticleSystem sys;

	// Use this for initialization
	void Start () {
		sys = this.gameObject.GetComponent<ParticleSystem> ();
		sys.Stop ();
	}
	
	public void illuminate(){
		sys.loop = false;
		sys.Play ();
	}

	public void lightUp(){
		sys.loop = true;
		sys.Play ();
	}

	public void blow(){
		sys.Stop ();
	}

	void Update(){
		if (iterations >= maxIterations) {
			sys.Stop ();
			iterations = 0;
			this.blow ();
		} else if (sys.isPlaying && !sys.loop) {
			iterations += 1;
		}
	}
}
