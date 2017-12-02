using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private enum State { idle, wander, hunt, attack };
	private State state = State.hunt;
	private Transform target;
	public float speed = 1f;

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
				break;
		}
	}

	private void Hunt() {
		Vector2 vectorToTarget = GetVectorToTarget();
		MoveAlongVector(vectorToTarget);
	}

	private Vector2 GetVectorToTarget() {
		return (target.position - transform.position);
	}

	private void MoveAlongVector(Vector2 vector) {
		Vector2 translation = (vector.normalized * speed * Time.deltaTime);
		transform.Translate(translation);
	}
}
