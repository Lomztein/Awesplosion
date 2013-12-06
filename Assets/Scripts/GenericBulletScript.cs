using UnityEngine;
using System.Collections;

public class GenericBulletScript : MonoBehaviour {

	public float damage;
	public GameObject particle;

	// Use this for initialization
	void OnCollisionEnter (Collision col) {
		Destroy (gameObject);
		Instantiate(particle,transform.position,transform.rotation);
		if (col.gameObject.GetComponent<healthScript>()) {
			col.gameObject.GetComponent<healthScript>().health -= damage;
		}
	}
}