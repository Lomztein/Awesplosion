using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	private float targetCamSize;
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.transform.position;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 relativePos = (2 * playerPos + mousePos)/3;
		transform.position = new Vector3 (relativePos.x,relativePos.y,playerPos.z - 10f);
//		Debug.Log(Input.GetAxis ("MouseWheel"));
		Camera.main.orthographicSize += Camera.main.orthographicSize * Input.GetAxis ("MouseWheel");
		if (Camera.main.orthographicSize < 2.5f) {
			Camera.main.orthographicSize = 2.5f;
		}
		if (Camera.main.orthographicSize > 30f) {
			Camera.main.orthographicSize = 30f;
		}
	}
}
