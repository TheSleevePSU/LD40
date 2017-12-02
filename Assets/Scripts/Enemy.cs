using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private enum State { idle, wander, hunt, attack };
	private State state = State.idle;
	private Transform target;
	public float speed = 1f;
	public float attackRange = 0.5f;
	public GameObject attackObject;

	// Use this for initialization
	void Start () {
		Player player = FindObjectOfType<Player>();
		target = (Transform) player.GetComponent(typeof(Transform));
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
			case State.idle:
				break;
			case State.wander:
				break;
			case State.hunt:
				Hunt();
				break;
			case State.attack:
				Attack();
				break;
		}
	}

    private void Hunt() {
		Vector2 vectorToTarget = GetVectorToTarget();
		if (vectorToTarget.magnitude < attackRange) {
			state = State.attack;
		} else {
			MoveAlongVector(vectorToTarget);
		}
	}

	private Vector2 GetVectorToTarget() {
		return (target.position - transform.position);
	}

	private void MoveAlongVector(Vector2 vector) {
		Vector2 translation = (vector.normalized * speed * Time.deltaTime);
		transform.Translate(translation);
	}

    private void Attack() {
		Vector2 targetPosition = target.position;
        InstantiateAttack(targetPosition);
        state = State.idle;
    }

    private void InstantiateAttack(Vector2 attackPosition) {
        Instantiate(attackObject, attackPosition, Quaternion.identity);
    }
}
