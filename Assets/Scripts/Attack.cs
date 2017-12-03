using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	private float timeToLive = 0.25f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, timeToLive);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Player player = other.gameObject.GetComponent<Player>();
		if (player != null) {
			player.SendMessage("HitByAttack", this);
		}
	}
}
