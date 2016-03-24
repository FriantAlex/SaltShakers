using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public Transform target;
	public bool destroyed = false;


	private GameObject[] laser;
	// Use this for initialization
	void Start () {
	

		target = GameObject.FindGameObjectWithTag ("Cart").GetComponent<Transform> ();



	}
	
	// Update is called once per frame
	void Update () {
		laser = GameObject.FindGameObjectsWithTag ("Enemy");
	
		transform.LookAt (target);
		for (int i = 0; i < laser.Length; i++) {

			var hit = laser[i].GetComponent<BouncingLaser>();
			if (hit.isHit)
				Destroy (gameObject);

		}

		}
	}
