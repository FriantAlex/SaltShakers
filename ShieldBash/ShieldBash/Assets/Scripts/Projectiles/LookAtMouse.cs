using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	public GameObject projectile;
	public Transform shotSpawn;


	private Camera cam;

	// Use this for initialization
	void Start () {
	
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 mousePos = Input.mousePosition;

		mousePos =  cam.ScreenToWorldPoint(new Vector3 (mousePos.x,mousePos.y,9.5f));

		transform.LookAt (mousePos);

		if (Input.GetMouseButtonDown (0))
			Instantiate (projectile, shotSpawn.position, shotSpawn.rotation);

	}
}
