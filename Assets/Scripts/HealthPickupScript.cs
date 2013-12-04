using UnityEngine;
using System.Collections;

public class HealthPickupScript : MonoBehaviour {

	public float amount;
	
	void OnTriggerEnter(Collider col) {
		Debug.Log (col.tag);
		if (col.tag == "Player") {
			col.GetComponent<healthScript>().health += amount;
			Destroy(gameObject);
		}
	}
}
