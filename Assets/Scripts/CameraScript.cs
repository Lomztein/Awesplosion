using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	float targetCamSize;
	bool showDeathScreen;

	// Update is called once per frame
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		InvokeRepeating ("Search",2,1);
	}
	
	void Search () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}

	void Update () {
		if (player) {
			Vector3 playerPos = player.transform.position;
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 relativePos = (2 * playerPos + mousePos)/3;

			transform.position = new Vector3 (relativePos.x,relativePos.y,playerPos.z - 10f);
			targetCamSize = Camera.main.orthographicSize;
			targetCamSize += Input.GetAxis ("MouseWheel");

//			float relativeCamSize = Camera.main.orthographicSize - targetCamSize;
			Camera.main.orthographicSize += Input.GetAxis ("MouseWheel") * 10;
			showDeathScreen = false;
		}else{
			showDeathScreen = true;
		}
		if (Camera.main.orthographicSize < 2.5f) {
			Camera.main.orthographicSize = 2.5f;
		}
		if (Camera.main.orthographicSize > 30f) {
			Camera.main.orthographicSize = 30f;
		}
	}
	void OnGUI () {
		if (showDeathScreen == true) {
			if (GUI.Button (new Rect(Screen.height/2 - 40,Screen.height/2 - 20,400,40),"You are dead. Restart?"))
				Application.LoadLevel ("as_testlevel_01");
		}
	}
}
