using UnityEngine;
using System.Collections;

public class Ricochet : MonoBehaviour {

	public LayerMask collsionMask;

	public Transform transform; // projectile transform
	public float speed; //movement speed
	public float rotSpeed; //rotation speed


	// Use this for initialization
	void Start () {
	
		transform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

		//move object forward
		transform.Translate (Vector3.forward * speed * Time.deltaTime);

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, speed * Time.deltaTime + .1f, collsionMask)) {

			Vector3 reflectDir = Vector3.Reflect (transform.forward, hit.normal);

			float rot =  90 - Mathf.Atan2(reflectDir.z,reflectDir.x) * Mathf.Rad2Deg;

			transform.eulerAngles = new Vector3 (0, rot, 0);

		}
	}


}
