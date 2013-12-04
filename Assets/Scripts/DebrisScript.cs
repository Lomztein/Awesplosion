using UnityEngine;
using System.Collections;

public class DebrisScript : MonoBehaviour {

	public Vector3 debrisVelocity;

	// Use this for initialization
	void Start () {
		Rigidbody[] children = gameObject.transform.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody debris in children) {
			Debug.Log (debrisVelocity*50);
			debris.rigidbody.AddForce(debrisVelocity);
		}
	}
}