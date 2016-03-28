using UnityEngine;
using System.Collections;

public class TempArcher : MonoBehaviour {

	public GameObject projectilePrefab;
	public float shotDelay;
	public Transform shotSpawn;


	public Transform target;
	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("FireProjectile", 1f, shotDelay);

	}
	
	// Update is called once per frame
	void Update () {


	}

	void FireProjectile (){

		var clone = Instantiate (projectilePrefab, shotSpawn.position, transform.rotation) as GameObject;

	}
}
