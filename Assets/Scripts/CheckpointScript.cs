using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject player;
	bool isRespawning;
	bool enabled;
	PlayerScript script;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			player = other.gameObject;
			enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null && isRespawning == false && enabled == true) {
			Invoke("Respawn",3f);
			isRespawning = true;
		}
	}
	void Respawn () {
		player = (GameObject)Instantiate(playerPrefab,transform.position,Quaternion.identity);
		player.tag = "Player";
		isRespawning = false;
		Camera.main.transform.SendMessage ("Search");
	}
}
