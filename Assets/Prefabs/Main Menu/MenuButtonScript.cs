using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour {

	public string scene;
	public string type;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Bullet") {
			if (type == "Load") {
				Debug.Log ("Loading level: "+scene);
				Application.LoadLevel (scene);
			}
			if (type == "Quit"){
				Application.Quit();
			}
		}
	}
}
