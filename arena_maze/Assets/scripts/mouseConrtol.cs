using UnityEngine;
using System.Collections;

public class mouseConrtol : MonoBehaviour {
	public float x_sensitivity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse X") != 0 ) 
		{
			transform.Rotate(transform.up, Input.GetAxis("Mouse X") *  x_sensitivity);
		}
	
	}
}
