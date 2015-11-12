using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public int bulletSpeed;
	public bullet b;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot();
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.collider.tag == "enemy") {
			currentHealth -= 1;
		}

	}
	void Shoot(){

//		bullet newBullet = Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
//		newBullet.direction = transform.forward * Time.deltaTime * bulletSpeed;
	}
}
