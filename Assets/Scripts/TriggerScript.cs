using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	public GameObject button;
	public bool activated;
	public string triggerTag;
	public bool activateOnPlayerCollision;
	
	// Update is called once per frame
	void Update () {
		if (activated == true) {
			button.renderer.material.color = Color.green;
		}
		if (activated == false) {
			button.renderer.material.color = Color.red;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == triggerTag) {
			activated = true;
		}
		if (other.tag == "Player" || activateOnPlayerCollision == true) {
			activated = true;
		}
	}
}