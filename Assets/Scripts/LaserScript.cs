using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public RaycastHit hit;
	public float damage;

	// Use this for initialization
	void Start () {
		LineRenderer line = GetComponent<LineRenderer>();
		Physics.Raycast (transform.position,transform.forward,out hit,Mathf.Infinity);
		line.SetPosition(0,transform.position);
		line.SetPosition(1,hit.point);
		hit.transform.GetComponent<healthScript>().health -= damage;
		hit.rigidbody.AddForce (transform.forward * 500);
		Debug.Log(hit.transform.name);
		Invoke ("Destroy",0.1f);
	}
	
	// Update is called once per frame
	void Destroy () {
		Destroy (gameObject);
	}
}
