using UnityEngine;
using System.Collections;

public class GranadeScript : MonoBehaviour {

	public float time;
	public GameObject particle;
	public float radius;
	public float power;

	// Use this for initialization
	void Start () {
		Invoke("Explode",time);
	}
	
	// Update is called once per frame
	void Explode () {
		Instantiate (particle,transform.position,transform.rotation);
		Destroy (gameObject);
		Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
		foreach (Collider hit in colliders) {
			
			if (hit && hit.rigidbody) {
				hit.rigidbody.AddExplosionForce(power,transform.position,radius,1f);
			}
			if (hit && hit.GetComponent<healthScript>()) {
				float distance = Vector2.Distance (transform.position,hit.transform.position);
				float distanceFactor = distance/radius;
				hit.GetComponent<healthScript>().health -= (power/50);// * distanceFactor;
			}
		}
	}
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.GetComponent<Rigidbody>()) {
			Explode();
		}
	}
}