using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OrientSpriteToMouse : MonoBehaviour {

	private Camera gameCamera;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		gameCamera = FindObjectOfType<Camera>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 worldPoint = gameCamera.ScreenToWorldPoint(Input.mousePosition);
		if (worldPoint.x > transform.position.x) {
			spriteRenderer.flipX = false;
		} else {
			spriteRenderer.flipX = true;
		}
	}
}

