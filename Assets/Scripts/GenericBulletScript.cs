using UnityEngine;
using System.Collections;

public class GenericBulletScript : MonoBehaviour {

	public float damage;

	// Use this for initialization
	void OnCollisionEnter (Collision col) {
		Destroy (gameObject);
		if (col.gameObject.GetComponent<healthScript>()) {
			col.gameObject.GetComponent<healthScript>().health -= damage;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
