using UnityEngine;
using System.Collections;

public class cam_trigger : MonoBehaviour {

	public cam camControl;
	public GameObject camToActivate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
//		camControl.ActivateCam2();
		camControl.deactivateCams ();
		camToActivate.SetActive(true);
	}
}
