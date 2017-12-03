using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class LocomotionController : MonoBehaviour {
	//public Rigidbody rb = GetComponent<Rigidbody>();
	public float maxSpeed = 3f;

	Animator anim;
	Rigidbody2D rb2D;
	FootstepGenerator footstepGenerator;

	private Vector2 positionThisFrame;
	private Vector2 positionPreviousFrame;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2D = GetComponent<Rigidbody2D>();
		footstepGenerator = GetComponent<FootstepGenerator>();
		InitializePositionTracking();
	}
	
	// Update is called once per frame
	void Update () {
		DetectCrouch();
		footstepGenerator.UpdateDistanceTraveled(DistanceTraveledPreviousFrame());
	}

	private void DetectCrouch() {
		if (Input.GetButton("Fire1")) {
			anim.SetBool("crouch", true);
		} else {
			anim.SetBool("crouch", false);
		}
	}

	void FixedUpdate() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 inputDirection = new Vector2(inputX, inputY).normalized;
		inputDirection *= maxSpeed;
		rb2D.AddForce(inputDirection);
		anim.SetFloat("speedMoving", rb2D.velocity.magnitude);
	}

	float DistanceTraveledPreviousFrame() {
		positionThisFrame = transform.position;
		Vector2 vectorTraveledPreviousFrame = positionThisFrame - positionPreviousFrame;
		positionPreviousFrame = positionThisFrame;
		return vectorTraveledPreviousFrame.magnitude;
	}

	void InitializePositionTracking() {
		positionThisFrame = transform.position;
		positionPreviousFrame = positionThisFrame;
	}
}

