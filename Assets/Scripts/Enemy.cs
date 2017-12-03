using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private enum State { idle, wander, hunt, attack };
	private State state;
	private Transform target;
	public float speed = 1f;
	public float attackRange = 0.5f;
	public GameObject attackObject;

	Animator animator;

	// Use this for initialization
	void Start () {
		Player player = FindObjectOfType<Player>();
		target = (Transform) player.GetComponent(typeof(Transform));
		animator = GetComponent<Animator>();
		UpdateState(State.idle);
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
			UpdateState(State.attack);
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
        UpdateState(State.idle);
    }

    private void InstantiateAttack(Vector2 attackPosition) {
        Instantiate(attackObject, attackPosition, Quaternion.identity);
    }

	public void HitBySoundCircle() {
		UpdateState(State.hunt);
	}

	public void HitByExplosion() {
		Destroy(this.gameObject);
	}

	private void UpdateState(State newState) {
		state = newState;
		switch (newState) {
			case State.idle:
				animator.SetBool("isWalking", false);
				break;
			case State.wander:
				animator.SetBool("isWalking", true);
				break;
			case State.hunt:
				animator.SetBool("isWalking", true);
				break;
			case State.attack:
				animator.SetBool("isWalking", false);
				break;
		}
		Debug.Log(state.ToString());
	}
}
