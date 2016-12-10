using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour {

	private Rigidbody rb;
	public float speed;




	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() 
	{
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
			rb.AddForce(transform.forward * speed);
		}

		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
			rb.AddForce(-transform.forward * speed);
		}

	}
}
