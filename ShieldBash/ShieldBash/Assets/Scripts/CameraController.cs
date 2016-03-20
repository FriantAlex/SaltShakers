using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float xMargin = 1f;        // Distance in the x axis the player can move before the camera follows.
	public float zMargin = 1f;        // Distance in the z axis the player can move before the camera follows.
	public float xSmooth = 8f;        // How smoothly the camera catches up with it's target movement in the x axis.
	public float zSmooth = 8f;        // How smoothly the camera catches up with it's target movement in the z axis.
	public Vector3 max;        // The maximum coordinates the camera can have.
	public Vector3 min;        // The minimum coordinates the camera can have.


	private Transform player;        // Reference to the player's transform.


	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.Find("Cart").transform;
	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}


	bool CheckZMargin()
	{
		// Returns true if the distance between the camera and the player in the z axis is greater than the z margin.
		return Mathf.Abs(transform.position.z - player.position.z) > zMargin;
	}


	void FixedUpdate ()
	{
		TrackPlayer();
	}


	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and z coordinates.
		float targetX = transform.position.x;
		float targetZ = transform.position.z;

		// If the player has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

		// If the player has moved beyond the z margin...
		if(CheckZMargin())
			// ... the target z coordinate should be a Lerp between the camera's current z position and the player's current z position.
			targetZ = Mathf.Lerp(transform.position.z, player.position.z, zSmooth * Time.deltaTime);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX,  transform.position.y, targetZ);
	}

}﻿