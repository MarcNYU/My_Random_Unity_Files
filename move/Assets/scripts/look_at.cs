using UnityEngine;
using System.Collections;

public class look_at : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation (target.position - transform.position);
	}
}
