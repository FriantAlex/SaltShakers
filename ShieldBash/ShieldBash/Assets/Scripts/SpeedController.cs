using UnityEngine;
using System.Collections;

public class SpeedController : MonoBehaviour {

	public float maxSpeed;
	public float acc;


	private Patrol playerController;


	// Use this for initialization
	void Start () {

		playerController = GameObject.FindWithTag ("Cart").GetComponent<Patrol> ();

	}


	void OnTriggerEnter(Collider other) {

		//speeds up cart 
		if (other.gameObject.tag == "Cart") {
			Debug.Log ("Boop");
			//spawner start goes here
			playerController.maxPatrolSpeed = maxSpeed;
			playerController.acceleration = acc;

		}
	}
}
