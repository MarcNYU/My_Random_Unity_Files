using UnityEngine;
using System.Collections;

public class h_wallTimer : MonoBehaviour {

	public float wallSpeed;
	public GameObject wall;
	public Vector3 comparator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		comparator.y = -1.0f;
		if (transform.position.y > comparator.y) {
			transform.position -= transform.up * Time.deltaTime * wallSpeed;
		} 
	}
}
