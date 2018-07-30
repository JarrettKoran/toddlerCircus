using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBreath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Rotate (Random.Range(-30,30), Random.Range(-30,30), Random.Range(-30,30));
		Destroy (gameObject, .2f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, -3 *Time.deltaTime, 0);
	}
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player")
			other.GetComponent<shootFPS> ().playerHealth -= 25;
	}
}
