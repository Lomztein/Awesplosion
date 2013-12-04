using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float angleToMouse;
	public Vector3 mousePos;
	public float maxSpeed;
	public float acceleration;
	public float minSpeed;
	public float jumpSpeed;
	public Texture temp;
	private float speed;
	private float targetSpeed;

	//Player handling

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI () {
		if (GUI.Button (new Rect(10,30,60,20),"Reset"))
			Application.LoadLevel ("as_testlevel_01");

		GUI.Label (new Rect(10,10,Screen.width,20),"Control with A and D, Jump with SPACE, shoot with MOUSE_1, Zoom with mouse wheel");
	}

	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		angleToMouse = Mathf.Atan2(mousePos.y-transform.position.y, mousePos.x-transform.position.x)*180 / Mathf.PI;
		//I did not come up with that myself, found it on the interwebs. Will find out how it works later.

		if (Input.GetButtonDown ("Jump") && Physics.Raycast (transform.position - new Vector3(0f,-0.25f,0f),(transform.up * -1f),0.5f)) {
			Debug.Log ("You can jump! :D");
			rigidbody.AddForce(transform.up * jumpSpeed);
		}

//		Debug.DrawRay(transform.position,(transform.up * -1f),Color.green,1);

		if (Input.GetAxis ("Horizontal") != 0) {
			targetSpeed = Input.GetAxis ("Horizontal") * maxSpeed;
			speed += targetSpeed * acceleration * Time.deltaTime;
			if (Mathf.Abs (speed) > maxSpeed) {
				speed -= targetSpeed * acceleration * Time.deltaTime;
			}
		}else{
			speed = speed * acceleration * Time.deltaTime;
			targetSpeed = 0;
		}

//		Debug.Log(targetSpeed);

		Vector3 movement = new Vector3(speed * Time.deltaTime,0,0);
		rigidbody.MovePosition(transform.position + movement);
	}
}