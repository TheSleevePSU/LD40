using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepGenerator : MonoBehaviour {

	public GameObject soundCircle;

	private float distancePerFootstep = 0.5f;
	private float distanceTraveledSinceLastFootstep = 0f;
	public Vector2 soundCircleOffset = new Vector2(0, -0.25f);

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
		Instantiate(soundCircle, transform.position, Quaternion.identity);
	}
}
