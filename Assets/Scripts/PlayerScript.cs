using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float angleToMouse;
	public float maxSpeed;
	public float acceleration;
	private Vector3 mousePos;
	public float minSpeed;
	public float jumpSpeed;
	public Texture temp;
	private float speed;
	public Texture crosshairTexture;
	public GameObject currentEquip;
	public GameObject newEquip;
	public Vector3 weaponPos;
	public float timeManipulatorCharge;
	private bool canManipulateTime;
	public float angle;
	BazookaScript equipScript;

	//Player handling

	// Use this for initialization
	void Start () {
		if (newEquip) {
			SpawnWeapon();
		}
	}

	void SpawnWeapon () {
		if (currentEquip == null) {
			currentEquip = (GameObject)Instantiate(newEquip,transform.position + weaponPos,transform.rotation);
			currentEquip.transform.parent = transform;
		}
		if (newEquip.name != currentEquip.name) {
			Destroy (currentEquip);
			currentEquip = (GameObject)Instantiate(newEquip,transform.position + weaponPos,transform.rotation);
			currentEquip.transform.parent = transform;
		}
		newEquip = null;
	}

	void OnGUI () {
		if (GUI.Button (new Rect(10,30,60,20),"Reset"))
			Application.LoadLevel ("as_testlevel_01");

		GUI.Label (new Rect(10,10,Screen.width,20),"Control with A and D, Jump with SPACE, shoot with MOUSE_1, Zoom with mouse wheel");
		GUI.DrawTexture (new Rect(Input.mousePosition.x-10,(-Input.mousePosition.y-10) + Screen.height,20,20),crosshairTexture);
		GUI.Box (new Rect(10,80,(Screen.width/2) * (timeManipulatorCharge/100),20),"Time Manipulator");
	}

	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		angle = Mathf.Atan2((mousePos.y - weaponPos.y)-transform.position.y, mousePos.x-transform.position.x)*180 / Mathf.PI;
		//I did not come up with that myself, found it on the interwebs. Will find out how it works later.

		if (Physics.Raycast (transform.position - new Vector3(0f,-0.25f,0f),(transform.up * -1f),0.5f) || Physics.Raycast (transform.position - new Vector3(0.5f,-0.25f,0f),(transform.up * -1f),0.5f) || Physics.Raycast (transform.position - new Vector3(-0.5f,-0.25f,0f),(transform.up * -1f),0.5f)) {
			if (Input.GetButtonDown ("Jump")) {
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

		if (newEquip) {
			SpawnWeapon();
		}

		if (canManipulateTime == false && timeManipulatorCharge > 30) {
			canManipulateTime = true;
		}

		if (Input.GetButton ("Special1") && canManipulateTime == true) {
			timeManipulatorCharge -= 25 / Time.timeScale * Time.deltaTime;
			Time.timeScale = 0.25f;
			if (timeManipulatorCharge <= 0) {
				canManipulateTime = false;
			}
		}else{
			Time.timeScale = 1;
			timeManipulatorCharge += 2.5f * Time.deltaTime;
		}

		if (timeManipulatorCharge >= 100) {
			timeManipulatorCharge = 100;
		}

		currentEquip.GetComponent<BazookaScript>().angle = angle;

		if (Input.GetButton ("Fire1")) {
			currentEquip.transform.SendMessage("Fire");
		}
	}
}