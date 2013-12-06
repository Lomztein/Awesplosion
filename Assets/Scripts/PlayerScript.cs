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
	public Texture crosshairTexture;

	//Player handling

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI () {
		if (GUI.Button (new Rect(10,30,60,20),"Reset"))
			Application.LoadLevel ("as_testlevel_01");

		GUI.Label (new Rect(10,10,Screen.width,20),"Control with A and D, Jump with SPACE, shoot with MOUSE_1, Zoom with mouse wheel");
		GUI.DrawTexture (new Rect(Input.mousePosition.x-10,(-Input.mousePosition.y-10) + Screen.height,20,20),crosshairTexture);
	}

	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		angleToMouse = Mathf.Atan2(mousePos.y-transform.position.y, mousePos.x-transform.position.x)*180 / Mathf.PI;
		//I did not come up with that myself, found it on the interwebs. Will find out how it works later.

		if (Physics.Raycast (transform.position - new Vector3(0f,-0.25f,0f),(transform.up * -1f),0.5f) || Physics.Raycast (transform.position - new Vector3(0.5f,-0.25f,0f),(transform.up * -1f),0.5f) || Physics.Raycast (transform.position - new Vector3(-0.5f,-0.25f,0f),(transform.up * -1f),0.5f)) {
			if (Input.GetButton ("Jump")) {
				rigidbody.AddForce(transform.up * jumpSpeed);
			}
			speed = Input.GetAxis("Horizontal") * maxSpeed;
		}else{
			speed = Input.GetAxis("Horizontal") * maxSpeed/3;
		}

		Debug.DrawRay (transform.position - new Vector3(0f,-0.25f,0f),(transform.up * -1f),Color.green);
		Debug.DrawRay (transform.position - new Vector3(0.5f,-0.25f,0f),(transform.up * -1f),Color.green);
		Debug.DrawRay (transform.position - new Vector3(-0.5f,-0.25f,0f),(transform.up * -1f),Color.green);

		Debug.Log (speed);

		Mathf.Clamp(rigidbody.velocity.x,-maxSpeed,maxSpeed);

		Vector3 movement = new Vector3(speed * Time.deltaTime,0,0);
		rigidbody.velocity += movement * 5;
	}
}