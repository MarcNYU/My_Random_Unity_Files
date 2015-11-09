using UnityEngine;
using System.Collections;

public class mouse_movement : MonoBehaviour {

	public float x_sensitivity;
	public float y_sensitivity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Mouse X") > 1 || Input.GetAxis("Mouse X") < 1 ) 
		{
			transform.Rotate(transform.up, Input.GetAxis("Mouse X") *  x_sensitivity);
		}
		if (Input.GetAxis("Mouse Y") > 1 || Input.GetAxis("Mouse Y") < 1) 
		{
			transform.Rotate(transform.right, -Input.GetAxis("Mouse Y") * y_sensitivity);
		}
	
	}
}
