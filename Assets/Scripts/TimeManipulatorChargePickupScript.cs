using UnityEngine;
using System.Collections;

public class TimeManipulatorChargePickupScript : MonoBehaviour {

	public float amount;
	
	void OnTriggerEnter(Collider col) {
		Debug.Log (col.tag);
		if (col.tag == "Player") {
			col.GetComponent<PlayerScript>().timeManipulatorCharge += amount;
			Destroy(gameObject);
		}
	}
}
