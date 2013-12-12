using UnityEngine;
using System.Collections;

public class BazookaScript : MonoBehaviour {

	public GameObject bulletType;
	public float bulletSpeed;
	public float reloadTime;
	public GameObject muzzle;
	public GameObject fireParticle;
	public bool reloaded = true;
	public float angle;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
/*		if (angle > Mathf.Abs (90)) {
			transform.localScale = new Vector3(-1,1,1);
		}else{
			transform.localScale = new Vector3(1,1,1);
		}
*///		Debug.Log (angle);
	}

	public void Fire () {
		if (reloaded == true) {
			GameObject lastBullet = (GameObject)Instantiate(bulletType,muzzle.transform.position,muzzle.transform.rotation);
			Instantiate(fireParticle,muzzle.transform.position,muzzle.transform.rotation);
			lastBullet.rigidbody.AddForce(lastBullet.transform.forward * bulletSpeed);
			Physics.IgnoreCollision(lastBullet.transform.collider,transform.parent.collider);
			reloaded = false;
			Invoke ("Reload",reloadTime);
			transform.parent.rigidbody.AddForce(transform.forward * (bulletSpeed/5) * -1);
		}
	}
	void Reload () {
		reloaded = true;
	}
}