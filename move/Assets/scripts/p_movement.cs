using UnityEngine;
using System.Collections;

public class p_movement : MonoBehaviour {

//	public Vector3 go;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
		{
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
		}
		else if(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A))
		{
			transform.position -= transform.right * Time.deltaTime * moveSpeed;
		}
		else if(Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
		{
			transform.position -= transform.forward * Time.deltaTime * moveSpeed;
		}
		else if(Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
		{
			transform.position += transform.right * Time.deltaTime * moveSpeed;
		}
	}
}
