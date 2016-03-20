using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	public Transform[] waypoints; //list of point
	public float maxPatrolSpeed = 6; //max speed
	public float acceleration; //how fast top speed is reached
	public float deceleration; // how fast speed of 0 is reached
	public bool patrolLoop = true; // loops partol
	public int dampingLook = 4; // rotation speed
	public float pauseDuration; // stop at point
	public float speed = 0.0f; // keep constant


	private float curTime;
	private int currentWayPoint = 0;

	void Awake(){
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



	
		if (currentWayPoint < waypoints.Length) {
			PatrolCycle ();
		} else {
			if (patrolLoop) {
				currentWayPoint = 0;
			}
		}
	}

	void PatrolCycle(){

		speed = Mathf.Lerp (speed, maxPatrolSpeed, acceleration * Time.deltaTime);

		Vector3 nextWayPoint = waypoints[currentWayPoint].position;

		Vector3 moveDirection = nextWayPoint - transform.position;

		if(moveDirection.magnitude < 1.5){
			Debug.Log("Enemy is close to nextWayPoint");

			if(curTime == 0)
				curTime = Time.time;
			
			if((Time.time - curTime) >= pauseDuration){
				Debug.Log("Increasing Waypoint");
				currentWayPoint++;
				curTime = 0;
				}
			}else{
				Debug.Log("Reaching in rotation " + moveDirection.magnitude);

				var rot = Quaternion.LookRotation(nextWayPoint - transform.position);

				transform.rotation = Quaternion.Slerp(transform.rotation,rot,Time.deltaTime * dampingLook);

				//charController.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);

			transform.position = Vector3.MoveTowards (transform.position, nextWayPoint, speed * Time.deltaTime);
			}
		}

	//draws partol path
	void OnDrawGizmos(){

		if (waypoints == null)
			return;

		if (waypoints != null) {

			for (int i = 1; i < waypoints.Length; i++) {

				Gizmos.color = Color.green;
				Gizmos.DrawLine (waypoints [i].position, waypoints [i - 1].position);
			}
		}

		}

	}
