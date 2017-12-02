using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LocomotionController : MonoBehaviour {
	//public Rigidbody rb = GetComponent<Rigidbody>();
	public float maxSpeed = 2f;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 targetPosition = CalculateTargetPosition(transform.position, inputX, inputY);
		transform.position = targetPosition;
	}

	//A tutorial I was using ran all physics throuch a fixed update instead of reg update
	/*void FixedUpdate(){
	 * float inputX = Input.GetAxis("Horizontal");
	 * float inputY = Input.GetAxis("Vertical");
	 * rb.velocity = new Vector2(inputX * maxSpeed, inputY * maxSpeed);
	 * 
	 * anim.SetFloat("speedMoving", Mathf.Abs()
	 * }
	*/
	private Vector2 CalculateTargetPosition(Vector3 currentPosition, float inputX, float inputY) {
		float currentX = currentPosition.x;
		float currentY = currentPosition.y;
		float targetX = currentX + (inputX * maxSpeed * Time.deltaTime);
		float targetY = currentY + (inputY * maxSpeed * Time.deltaTime);
		return new Vector2(targetX, targetY);
	}
}

