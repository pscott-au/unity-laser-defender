using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


	public float damage = 10f;


	public float GetDamage() {
		return damage;
	}
	// Use this for initialization
	public void Hit() {
		Debug.Log ("HIT TRIGGERED");
		Destroy (gameObject);
	}
}
