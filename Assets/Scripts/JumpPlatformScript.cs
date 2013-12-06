using UnityEngine;
using System.Collections;

public class JumpPlatformScript : MonoBehaviour {

	public GameObject button;
	public float force;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (button) {
			if (button.GetComponent<TriggerScript>().activated == true) {
				other.rigidbody.AddForce(transform.up * force);
			}
		}else{
			other.rigidbody.AddForce(transform.up * force);
		}
	}
}