using UnityEngine;
using System.Collections;

public class BazookaScript : MonoBehaviour {

	public GameObject parant;
	public GameObject bulletType;
	public float bulletSpeed;
	public float reloadTime;
	public GameObject muzzle;
	public bool reloaded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 10f;
		float angle = Mathf.Atan2(mousePos.y-transform.position.y, mousePos.x-transform.position.x)*180 / Mathf.PI;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (Input.GetButtonDown("Fire1") && reloaded == true) {
			GameObject lastBullet = (GameObject)Instantiate(bulletType,muzzle.transform.position,muzzle.transform.rotation);
			lastBullet.rigidbody.AddForce(lastBullet.transform.forward * bulletSpeed);
			Physics.IgnoreCollision(lastBullet.transform.collider,parant.collider);
			reloaded = false;
			Invoke ("Reload",reloadTime);
		}
	}
	void Reload () {
		reloaded = true;
	}
}