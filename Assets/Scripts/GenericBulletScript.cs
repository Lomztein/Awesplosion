using UnityEngine;
using System.Collections;

public class GenericBulletScript : MonoBehaviour {

	public float damage;
	public GameObject particle;
	healthScript colHealth;

	// Use this for initialization
	void OnCollisionEnter (Collision col) {
		Destroy (gameObject);
		Instantiate(particle,transform.position,transform.rotation);
		colHealth = col.gameObject.GetComponent<healthScript>();
		if (colHealth) {
			colHealth.health -= damage;
		}
	}
}