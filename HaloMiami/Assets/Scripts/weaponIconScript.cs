using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponIconScript : MonoBehaviour {
	string currentWeapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<player> ().currentWeapon == null)
			currentWeapon = "Flashlight";
		else
			currentWeapon = GameObject.FindGameObjectWithTag ("Player").GetComponent<player> ().currentWeapon.GetChild (0).tag;

		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive (false);
		}
		transform.Find (currentWeapon+"Icon").gameObject.SetActive (true);

	}
}
