using UnityEngine;
using System.Collections;

public class MiniSentryScript : MonoBehaviour {

	public GameObject target;
	public float range;
	public bool freeLineOfSite;
	public bool mouseHovering;
	public GameObject weaponType;
	public GameObject equip;
	public float distanceToTarget;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
		InvokeRepeating ("Search",2,1);
		SpawnWeapon();
	}
	
	void Search () {
		if (target == null) {
			target = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	// Update is called once per frame
	void Update () {
		float distanceToTarget = Vector3.Distance(transform.position,target.transform.position);
		if (distanceToTarget < range) {
			Vector3 targetPos = target.transform.position;
			float angle = Mathf.Atan2(targetPos.y+1-transform.position.y, targetPos.x-transform.position.x)*180 / Mathf.PI;
			equip.transform.SendMessage("Fire");
			equip.GetComponent<BazookaScript>().angle = angle;
		}
	}
	void SpawnWeapon () {
		equip = (GameObject)Instantiate(weaponType,transform.position,Quaternion.identity);
		equip.transform.parent = transform;
	}
}
