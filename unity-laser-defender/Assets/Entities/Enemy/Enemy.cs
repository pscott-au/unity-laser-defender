using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 3;
	public float shotPerSecond = 0.15f;

	void Fire() {
		Vector3 startPosition = transform.position + new Vector3 (0, -1.5f, 0);
		GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity ) as GameObject;
		//missile.rigidbody2D.velocity = new Vector2 (0, -1);
		Rigidbody2D rb=  missile.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (0, -projectileSpeed);

	}

	void Update() {
		float probability = shotPerSecond * Time.deltaTime;
		if (Random.value < probability) {
			Fire ();
		}
			
		// Random.Range(
		// Fire ();
	}

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
