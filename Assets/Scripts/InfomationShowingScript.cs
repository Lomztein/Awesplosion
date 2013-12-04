using UnityEngine;
using System.Collections;

public class InfomationShowingScript : MonoBehaviour {

	public string text = "Test";
	bool showText = true;
	public Collider col = null;

	// Use this for initialization
	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			showText = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.tag == "Player") {
			showText = false;
		}
	}

	void OnGUI () {
		Vector3 colScreenPos = Camera.main.WorldToScreenPoint(col.transform.position);
		if (showText) {
			GUI.Label(new Rect(Input.mousePosition.x - 50,-Input.mousePosition.y + Screen.height - 20,Screen.width,20),text);
		}
	}
}