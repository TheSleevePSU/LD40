using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionController : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		UpdatePosition(inputX, inputY);
	}

	private void UpdatePosition(float inputX, float inputY) {
        float translationX = (inputX * speed * Time.deltaTime);
		float translationY = (inputY * speed * Time.deltaTime);
		transform.Translate(translationX, translationY, 0);
    }
}

