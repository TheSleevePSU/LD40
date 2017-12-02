using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class LocomotionController : MonoBehaviour {
	//public Rigidbody rb = GetComponent<Rigidbody>();
	public float maxSpeed = 2f;

	Animator anim;
	Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 inputDirection = new Vector2(inputX, inputY).normalized;
		inputDirection *= maxSpeed;
		rb2D.AddForce(inputDirection);
		anim.SetFloat("speedMoving", rb2D.velocity.magnitude);
	}
}

