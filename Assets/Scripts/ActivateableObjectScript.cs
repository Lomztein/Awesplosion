using UnityEngine;
using System.Collections;

public class ActivateableObjectScript : MonoBehaviour {

	public GameObject button;
	public bool locked = true;
	public bool reversed;
	private TriggerScript script;

	void Start () {
		script = button.GetComponent<TriggerScript>();
	}

	void Update () {
		if (button == null) {
			Debug.Log("You forgot to add a button this door, faggola: ",gameObject);
		}else{
			if (reversed == false) {
				if (script.activated == true) {
					collider.enabled = false;
					renderer.enabled = false;
				}else{
					collider.enabled = true;
					renderer.enabled = true;
				}
			}else{
				if (script.activated == false) {
					collider.enabled = false;
					renderer.enabled = false;
				}else{
					collider.enabled = true;
					renderer.enabled = true;
				}
			}
		}
	}
}