using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LocomotionController : MonoBehaviour {

	public float speed = 2f;
	//private CapsuleCollider2D colliderComponent;

	// Use this for initialization
	void Start () {
		//colliderComponent = GetComponent<CapsuleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 targetPosition = CalculateTargetPosition(transform.position, inputX, inputY);
		transform.position = targetPosition;
	}

	private Vector2 CalculateTargetPosition(Vector3 currentPosition, float inputX, float inputY) {
		float currentX = currentPosition.x;
		float currentY = currentPosition.y;
		float targetX = currentX + (inputX * speed * Time.deltaTime);
		float targetY = currentY + (inputY * speed * Time.deltaTime);
		return new Vector2(targetX, targetY);
	}

	// private bool CanMove(Vector2 moveTarget) {
	// 	Vector2 size = colliderComponent.size;
	// 	CapsuleDirection2D direction = colliderComponent.direction;
	// 	Collider2D[] colliders = Physics2D.OverlapCapsuleAll(moveTarget, size, direction, 0f);
	// 	foreach (Collider2D c in colliders) {
	// 		Debug.Log(c.ToString());
	// 	}
	// 	return true;
	// }
}

