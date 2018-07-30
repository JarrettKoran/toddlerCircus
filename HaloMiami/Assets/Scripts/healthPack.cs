using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && other.GetComponent<player>().playerHealth != 100)
		{
			other.GetComponent<player>().playerHealth = 100;
			Destroy(gameObject);
		}
	}
}
