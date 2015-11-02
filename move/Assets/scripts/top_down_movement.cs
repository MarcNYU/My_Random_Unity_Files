using UnityEngine;
using System.Collections;

public class top_down_movement : MonoBehaviour {

	public float walkingSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) 
		{
//			transform.position = Input.mousePosition;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground") 
			{
				Vector3 move;
				move = hit.point - transform.position;
				move.Normalize();

				transform.position += move * Time.deltaTime * walkingSpeed;
//				transform.position = Vector3.Lerp(transform.position, hit.point, .2f);
			}
		}
	
	}
}
