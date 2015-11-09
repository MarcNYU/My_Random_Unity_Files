using UnityEngine;
using System.Collections;

public class camTrigger : MonoBehaviour {
	
	public camControl camControl;
	public GameObject camToActivate;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	//called any time a rigid body enters the collider of my trigger
	void OnTriggerEnter(Collider other)
	{
		
		//deactivate other cameras
		camControl.DeactivateAllCams();

		//activate camToActivate
		camToActivate.SetActive(true);
		
	}
}