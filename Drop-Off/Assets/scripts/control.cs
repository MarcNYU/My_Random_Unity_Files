using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
	
	Rigidbody rb;
	public float speed;
	public float turn;
	public float shift;

	private bool hitR = false;
	private bool hitL = false;
	private bool drift = false;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		FixedUpdate();

		if (hitL == false) {
			if (Input.GetKey (KeyCode.LeftArrow))
			{
				transform.position -= transform.right * shift * Time.deltaTime;
//				if (drift == true) {
//					transform.RotateAround(transform.position, transform.up, -turn);
//				}
//				else {
//					transform.position -= transform.right * shift * Time.deltaTime;
//				}
			}
		}
		if (hitR == false) {
			if (Input.GetKey (KeyCode.RightArrow))
			{
				transform.position += transform.right * shift * Time.deltaTime;
//				if (drift == true) {
//					transform.RotateAround(transform.position, transform.up, turn);
//				}
//				else {
//					transform.position += transform.right * shift * Time.deltaTime;
//				}
			}
		}

		if (speed < 10) {
			speed = 0;
		}
	}

	void FixedUpdate () {

		rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
		if (drift == true) {
//			if (Input.GetKey (KeyCode.UpArrow)) {
//				transform.position += transform.forward * speed/2f * Time.deltaTime;
//			}
			speed -= .001f;
		}

	}
	
	void OnCollisionEnter (Collision col) {
		if (col.collider.tag == "wallR") {
			hitR = true;
		}
		if (col.collider.tag == "wallL") {
			hitL = true;
		}

	}

	void OnCollisionStay (Collision col) {
		if (col.collider.tag == "wallR") {
			hitR = true;
		}
		if (col.collider.tag == "wallL") {
			hitL = true;
		}
	}

	void OnCollisionExit (Collision col) {
		if (col.collider.tag == "wallR") {
			hitR = false;
		}
		if (col.collider.tag == "wallL") {
			hitL = false;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.GetComponent<Collider> ().tag == "DropOff") {
			drift = true;
			//speed = speed/2f;
			//rb.angularDrag = .5f;
			//rb.drag = 1f;
		}
		if (col.GetComponent<Collider> ().tag == "SpdBump") {
			speed -= 2.5f;
			rb.angularDrag += .01f;
		}
	}
	void OnTriggerStay(Collider col){
		if (col.GetComponent<Collider> ().tag == "OffRoad") {
			speed -= 1f;
			rb.angularDrag += .01f;
		}
		if (col.GetComponent<Collider> ().tag == "wall") {
			speed = 0f;
			rb.angularDrag += 1f;
			rb.drag = 1f;
		}
	}
}
