using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float directionToMouse = Vector2.Angle(transform.position,Camera.main.ScreenToViewportPoint(Input.mousePosition));
		Debug.Log (directionToMouse);
	}
}