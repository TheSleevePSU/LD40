﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HitByAttack() {
		Debug.Log("Player hit by Attack");
		Destroy(this.gameObject);
	}

	public void HitByExplosion() {
		Debug.Log("Player hit by Explosion");
		Destroy(this.gameObject);
	}
}
