using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	private Rigidbody rb;
	public float driveSpeed;
	public float jumpStrenght;
	public bool grounded = false;
	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionStay(Collision col){
		if (col.collider.tag == "Ground") {
			grounded = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.collider.tag == "Ground") {
			grounded = false;
		}
	}

	void FixedUpdate (){
		if(Input.GetKey (KeyCode.Space))
		{
			rb.AddForce(transform.up * jumpStrenght, ForceMode.VelocityChange);
		}
		if(Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
		{
//			transform.position += transform.forward * Time.deltaTime * moveSpeed;
			rb.AddForce(transform.forward * driveSpeed);
		}
		else if(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A))
		{

		}
		else if(Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
		{

		}
		else if(Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
		{

		}
	}
}
