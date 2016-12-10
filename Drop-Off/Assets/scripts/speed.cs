using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class speed : MonoBehaviour {

	public Text t;
	public Text d;
	public GameObject c;

	private string s;
	private string x;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		s = "Speed: " + c.GetComponent<control> ().speed.ToString ();
		t.text = s;

		x = "Distance: " + Mathf.Abs(c.transform.position.z) % 637;
		d.text = x;
	}
}
