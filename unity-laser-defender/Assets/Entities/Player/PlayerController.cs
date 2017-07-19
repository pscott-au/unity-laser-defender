using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	public float playerSpeed  = 5.0f;
	float xmin;
	float xmax;
	public float padding = 1;

	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;

	public float health = 150f;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftmost = Camera.main.ViewportToWorldPoint( new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint( new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}

	void Fire() {
		Vector3 startPosition = transform.position + new Vector3 (0, +1.5f, 0);
		GameObject beam =Instantiate(projectile, startPosition, Quaternion.identity ) as GameObject;
		// beam.rigidbody2D.velocity = new Vector3 (0, projectileSpeed,0);
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, projectileSpeed,0);
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			// transform.position += new Vector3 (-playerSpeed * Time.deltaTime, 0, 0);
			transform.position += Vector3.left * playerSpeed * Time.deltaTime;
		} 
		else if (Input.GetKey(KeyCode.RightArrow)  )
		{
			//transform.position += new Vector3(playerSpeed * Time.deltaTime, 0,0);
			transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		} 
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.00001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			//InvokeRepeating ("Fire", 0.00001f, firingRate);
			CancelInvoke("Fire");
		}


		// restrict player to gamespace.
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 ( newX, transform.position.y, transform.position.z );
	}


	void OnTriggerEnter2D(Collider2D col) {

		Projectile missile = col.gameObject.GetComponent<Projectile> ();
		if (missile) {
			Debug.Log("Enemy hit by projectile");
			health -= missile.GetDamage();
			missile.Hit ();
			// Debug.Log (health);
			if (health <= 0f) {
				Debug.Log (health);
				Destroy (gameObject);
			}
		}
		// Destroy (col.gameObject);
		// Destroy (gameObject);

	}
}
