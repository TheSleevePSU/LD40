using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 0.25f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy != null) {
			enemy.SendMessage("HitByExplosion", this);
		}
		Player player = other.gameObject.GetComponent<Player>();
		if (player != null) {
			player.SendMessage("HitByExplosion", this);
		}
	}
}
