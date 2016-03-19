using UnityEngine;
using System.Collections;

public class Slower : MonoBehaviour {

	public float speed;
	public float acc;


	private NavMeshAgent playerAgent;
	
	
	// Use this for initialization
	void Start () {
		
		playerAgent = GameObject.FindWithTag ("Cart").GetComponent<NavMeshAgent> ();
		
	}
	
	
	void OnTriggerEnter(Collider other) {
		
		//speeds up cart 
		if (other.gameObject.tag == "Cart") {
			Debug.Log ("Boop");
			//spawner start goes here
			playerAgent.speed = speed;
			playerAgent.acceleration = acc;
			
		}
	}
}
