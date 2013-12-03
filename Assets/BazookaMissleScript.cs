using UnityEngine;
using System.Collections;

public class BazookaMissleScript : MonoBehaviour {

	public float speed;
	public GameObject particle;
	public float radius;
	public float power;

	// Update is called once per frame
	void Update () {
		rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
	}
	void OnCollisionEnter () {
		Instantiate (particle,transform.position,transform.rotation);
		Destroy (gameObject);
		Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
		foreach (Collider hit in colliders) {
			if (hit && hit.rigidbody) {
				hit.rigidbody.AddExplosionForce(power,transform.position,radius,3f);
			}
			if (hit && hit.GetComponent<healthScript>()) {
				hit.GetComponent<healthScript>().health -= 50;
			}
		}
	}
}
