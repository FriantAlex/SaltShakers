using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public Transform target;

	private BouncingLaser laser;
	// Use this for initialization
	void Start () {
	
		target = GameObject.FindGameObjectWithTag ("Cart").GetComponent<Transform> ();

		laser = GameObject.FindGameObjectWithTag ("Laser").GetComponent<BouncingLaser> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.LookAt (target);

		if (laser.isHit)
			Destroy (gameObject);
	}
		
}
