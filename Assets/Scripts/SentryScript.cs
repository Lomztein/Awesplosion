using UnityEngine;
using System.Collections;

public class SentryScript : MonoBehaviour {

	public GameObject target;
	public GameObject bulletType;
	public GameObject muzzle;
	public GameObject fireParticle;
	public bool reloaded = true;
	public float reloadTime;
	public float range;
	public float bulletSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float distanceToTarget = Vector3.Distance(transform.position,target.transform.position);
		if (distanceToTarget < range) {
			Vector3 targetPos = target.transform.position;
			float angle = Mathf.Atan2(targetPos.y+1-transform.position.y, targetPos.x-transform.position.x)*180 / Mathf.PI;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			if (reloaded == true) {
				GameObject lastBullet = (GameObject)Instantiate(bulletType,muzzle.transform.position,muzzle.transform.rotation);
				lastBullet.rigidbody.AddForce(lastBullet.transform.forward * bulletSpeed);
				Physics.IgnoreCollision(lastBullet.transform.collider,transform.collider);
				reloaded = false;
				Invoke ("Reload",reloadTime);
			}
		}
	}

	void Reload () {
		reloaded = true;
	}
}
