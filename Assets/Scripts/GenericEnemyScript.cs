using UnityEngine;
using System.Collections;

public class GenericEnemyScript : MonoBehaviour {

	public GameObject target;
	public float speed;
	public float maxSpeed;
	public float range;
	public float weaponRange;
	public float distanceToTarget;
	public GameObject newEquip;
	public GameObject currentEquip;
	public Vector3 weaponPos;
	public float angle;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
		SpawnWeapon();
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

	// Update is called once per frame
	void Update () {

		angle = Mathf.Atan2((target.transform.position.y + 1.75f - weaponPos.y)-transform.position.y, target.transform.position.x-transform.position.x)*180 / Mathf.PI;

		distanceToTarget = Vector3.Distance(target.transform.position,transform.position);

		currentEquip.GetComponent<BazookaScript>().angle = angle;
		if (distanceToTarget < range) {
			if (target.transform.position.x < transform.position.x && distanceToTarget > weaponRange - 1) {
				speed = -(maxSpeed * Time.deltaTime);
			}
			if (target.transform.position.x > transform.position.x && distanceToTarget > weaponRange - 1) {
				speed = (maxSpeed * Time.deltaTime);
			}
			if (distanceToTarget < weaponRange) {
				speed = 0;
			}
//			Debug.Log (speed);
		}

		if (Physics.Raycast (transform.position - new Vector3(0f,-0.25f,0f),(transform.up * -1f),0.5f) || Physics.Raycast (transform.position - new Vector3(0.5f,-0.25f,0f),(transform.up * -1f),0.5f) || Physics.Raycast (transform.position - new Vector3(-0.5f,-0.25f,0f),(transform.up * -1f),0.5f)) {
			Vector3 movement = new Vector3(speed,0,0);
			if (Mathf.Abs (rigidbody.velocity.x) < maxSpeed) {
				rigidbody.velocity += movement * 5;
			}
//			Debug.Log (rigidbody.velocity);
		}

		if (distanceToTarget < weaponRange) {
			currentEquip.transform.SendMessage("Fire");
		}

		if (currentEquip == null) {
			SpawnWeapon();
		}
	}
}
