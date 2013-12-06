using UnityEngine;
using System.Collections;

public class InfomationShowingScript : MonoBehaviour {

	public string text;
	private bool showText;
	public Collider other = null;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			showText = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			showText = false;
		}
	}

	void OnGUI () {
		if (other != null) {
			Vector3 colScreenPos = Camera.main.WorldToScreenPoint(other.gameObject.transform.position);
			if (showText) {
				GUI.Label(new Rect(colScreenPos.x - 50,-colScreenPos.y + Screen.height - 20,Screen.width,20),text);
			}
		}
	}
}