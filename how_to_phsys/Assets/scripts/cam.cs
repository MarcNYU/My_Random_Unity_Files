using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour {

	public GameObject[] cams;
	private int current = 0;
//	public Camera cam1;
//	public Camera cam2;

	// Use this for initialization
	void Start () {

		activateCam (current);
//		cam1.enabled = true;
//		cam2.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
//			cam1.enabled = !cam2.enabled;
//			cam2.enabled = !cam1.enabled;
			current += 1;
			if (current == cams.Length)
			{
				current = 0;
			}
			activateCam(current);
		}
	
	}

	public void deactivateCams(){
		for (int i = 0; i < cams.Length; i++) {
			cams [i].SetActive (false);
		}
	}

	public void activateCam(int cIdx){
//		cam1.enabled = false;
//		cam2.enabled = true;

		deactivateCams ();
		cams [cIdx].SetActive (true);
	}

}
