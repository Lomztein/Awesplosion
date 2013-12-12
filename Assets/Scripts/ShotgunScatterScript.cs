using UnityEngine;
using System.Collections;

public class ShotgunScatterScript : MonoBehaviour {

	public GameObject particle;
	healthScript colHealth;
	public float damage;

	// Use this for initialization
	void Start () {
		Invoke ("Freedom",0.1f);
	}
	
	// Update is called once per frame
	void Freedom() {
		transform.parent = null;
		rigidbody.isKinematic = false;
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag != "Bullet") {
			Destroy (gameObject);
			Instantiate(particle,transform.position,transform.rotation);
			colHealth = col.gameObject.GetComponent<healthScript>();
			if (colHealth) {
				colHealth.health -= damage;
			}
		}
	}
}