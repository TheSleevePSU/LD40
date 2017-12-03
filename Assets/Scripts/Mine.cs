using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy != null) {
			Detonate();
		}
		Player player = other.gameObject.GetComponent<Player>();
		if (player != null) {
			Detonate();
		}
	}

	private void Detonate() {
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
