using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public GameObject button;
	public bool locked = true;

	// Update is called once per frame
	void Update () {
		if (button == null) {
			Debug.Log("You forgot to add a button this door, faggola",gameObject);
		}else{
			if (button.GetComponent<TriggerScript>().activated == true) {
				Destroy (gameObject);
			}
		}
	}
}