using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {

	public bool infiniteHealth;
	public bool infiniteTimeCharge;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	void OnGUI () {
		if (Application.loadedLevelName == "as_options_menu") {
			if (infiniteHealth == true) {
				if (GUI.Button(new Rect(10,10,Screen.width/3,40),"Infinite health = true"))
					infiniteHealth = false;
			}else{
				if (GUI.Button(new Rect(10,10,Screen.width/3,40),"Infinite health = false"))
					infiniteHealth = true;
			}
			if (infiniteTimeCharge == true) {
				if (GUI.Button(new Rect(10,50,Screen.width/3,40),"Infinite time charge = true"))
					infiniteTimeCharge = false;
			}else{
				if (GUI.Button(new Rect(10,50,Screen.width/3,40),"Infinite time charge = false"))
					infiniteTimeCharge = true;
			}
			if (GUI.Button(new Rect(10,90,Screen.width/3,40),"Back to menu"))
				Application.LoadLevel ("as_mainmenu");
		}
	}
}