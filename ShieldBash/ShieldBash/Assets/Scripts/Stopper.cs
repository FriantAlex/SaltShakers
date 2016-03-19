using UnityEngine;
using System.Collections;

public class Stopper : MonoBehaviour {

    public bool isStopped = false;


    private NavMeshAgent playerAgent;


    // Use this for initialization
    void Start () {
	
		playerAgent = GameObject.FindWithTag ("Cart").GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {

		// testing resuming path

		if (isStopped && Input.GetKey (KeyCode.Mouse0)) { //resume if trigger or condition is met
			isStopped = false;
			playerAgent.Resume ();
		}
	
	}

	void OnTriggerEnter(Collider other) {
	
		//stops cart 
		if (other.gameObject.tag == "Cart") {
			Debug.Log ("Boop");
			//spawner start goes here
			playerAgent.Stop ();
			isStopped = true;
		}
	}
}
