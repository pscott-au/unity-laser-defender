using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health = 150f;


	void OnTriggerEnter2D(Collider2D col) {

		Projectile missile = col.gameObject.GetComponent<Projectile> ();
		if (missile) {
			Debug.Log("Enemy hit by projectile");
			health -= missile.GetDamage();
			missile.Hit ();
			Debug.Log (health);
			if (health <= 0f) {
				Debug.Log (health);
				Destroy (gameObject);
			}
		}
		// Destroy (col.gameObject);
		// Destroy (gameObject);
	
	}
}
