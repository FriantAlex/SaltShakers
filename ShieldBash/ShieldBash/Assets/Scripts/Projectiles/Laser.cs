using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;


	private LineRenderer laserLine;

	// Use this for initialization
	void Start () {
	
		laserLine = GetComponent<LineRenderer> ();
		laserLine.SetWidth (8, 8);
	}
	
	// Update is called once per frame
	void Update () {
	
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);

	}
}
