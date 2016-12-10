using UnityEngine;
using System.Collections;

public class Feet : MonoBehaviour {

	public bool grounded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnCollisionStay(Collision col) {
//		if (col.collider.tag == "Ground") {
//			grounded = true;
//		}
//	}
//		
//	void OnCollisionExit(Collision col) {
//		if (col.collider.tag == "Ground") {
//			grounded = false;
//		}
//	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Ground") {
			grounded = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.tag == "Ground") {
			grounded = false;
		}
	}
}
