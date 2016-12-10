using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Rigidbody rb;

	public Feet f;
	public float walkSpeed;
	public float jumpStrength;

	private bool grounded;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = f.grounded;
		if (Input.anyKey) {
			FixedUpdate();
		}
	}

	void FixedUpdate() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce(-transform.forward * walkSpeed, ForceMode.Acceleration);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
		}
		if (grounded) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				rb.AddForce (transform.up * jumpStrength, ForceMode.Acceleration);
			}
		} else {
			rb.AddForce (-transform.up * 10f, ForceMode.Acceleration);
		}
	}
}

