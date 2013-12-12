using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public RaycastHit hit;
	public float damage;
	public float force;

	// Use this for initialization
	void Start () {
		LineRenderer line = GetComponent<LineRenderer>();
		Physics.Raycast (transform.position,transform.forward,out hit,Mathf.Infinity);
		line.SetPosition(0,transform.position);
		line.SetPosition(1,hit.point);
		line.SetWidth (0.2f,0.2f);

		healthScript hitHealth = hit.transform.GetComponent<healthScript>();
		if (hitHealth) {
			hitHealth.health -= damage;
		}

		Rigidbody hitRigidbody = hit.transform.GetComponent<Rigidbody>();
		if (hitRigidbody) {
			hitRigidbody.AddForce(transform.forward * force);
		}
		TriggerScript hitTrigger = hit.transform.GetComponent<TriggerScript>();
		if (hitTrigger) {
			hitTrigger.activated = true;
		}

		Debug.Log(hit.transform.name);
		Invoke ("Destroy",0.1f);
	}
	
	// Update is called once per frame
	void Destroy () {
		Destroy (gameObject);
	}
}
