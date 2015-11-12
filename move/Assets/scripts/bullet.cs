using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public Vector3 dir;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += dir * Time.deltaTime * speed;
	
	}

	void OnCollisonEnter(Collision col){
		Debug.Log ("hit");
	}
}
