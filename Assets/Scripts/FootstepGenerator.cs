using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepGenerator : MonoBehaviour {

	private float distancePerFootstep = 0.5f;
	private float distanceTraveledSinceLastFootstep = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateDistanceTraveled(float distanceTraveledThisFrame) {
		distanceTraveledSinceLastFootstep += distanceTraveledThisFrame;
		if (distanceTraveledSinceLastFootstep > distancePerFootstep) {
			TakeStep();
			distanceTraveledSinceLastFootstep = 0f;
		}
	}

	private void TakeStep() {
		Debug.Log("Generate footstep sound");
	}
}
