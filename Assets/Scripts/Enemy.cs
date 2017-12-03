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
	ThoughtBubble thoughtBubble;

	// Use this for initialization
	void Start () {
		Player player = FindObjectOfType<Player>();
		target = (Transform) player.GetComponent(typeof(Transform));
		animator = GetComponent<Animator>();
		thoughtBubble = (ThoughtBubble) GetComponentInChildren(typeof(ThoughtBubble));
		UpdateState(State.idle);
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
			case State.idle:
				break;
			case State.wander:
				Wander();
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
		if (vectorToTarget != null) {
			if (vectorToTarget.magnitude < attackRange) {
				UpdateState(State.attack);
			} else {
				MoveAlongVector(vectorToTarget);
			}
		}
	}

	private Vector2 GetVectorToTarget() {
		if (target != null) {
			return (target.position - transform.position);
		} else {
			return new Vector2();
		}
	}

	private void MoveAlongVector(Vector2 vector) {
		Vector2 translation = (vector.normalized * speed * Time.deltaTime);
		transform.Translate(translation);
	}

    private void Attack() {
		if (target != null) {
			Vector2 targetPosition = target.position;
			InstantiateAttack(targetPosition);
		}
		UpdateState(State.idle);
    }

	private void Wander() {
		
	}

    private void InstantiateAttack(Vector2 attackPosition) {
        Instantiate(attackObject, attackPosition, Quaternion.identity);
    }

	public void HitBySoundCircle() {
		switch (state) {
			case State.idle:
				UpdateState(State.wander);
				break;
			case State.wander:
				UpdateState(State.hunt);
				break;
		}
	}

	public void HitByExplosion() {
		Destroy(this.gameObject);
	}

	private void UpdateState(State newState) {
		state = newState;
		switch (newState) {
			case State.idle:
				animator.SetBool("isWalking", false);
				thoughtBubble.UpdateThought(ThoughtBubble.Thought.questionMark);
				break;
			case State.wander:
				animator.SetBool("isWalking", true);
				thoughtBubble.UpdateThought(ThoughtBubble.Thought.exclamationPoint);
				break;
			case State.hunt:
				animator.SetBool("isWalking", true);
				thoughtBubble.UpdateThought(ThoughtBubble.Thought.x);
				break;
			case State.attack:
				animator.SetBool("isWalking", false);
				thoughtBubble.UpdateThought(ThoughtBubble.Thought.x);
				break;
		}
		Debug.Log(state.ToString());
	}
}
