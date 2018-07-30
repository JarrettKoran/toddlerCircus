using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class boom2Script : MonoBehaviour {

	public Transform player;
	public Transform playerHitBox;

	NavMeshAgent agent;
	Transform goal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").transform;
		playerHitBox = GameObject.FindWithTag ("fpsHit").transform;
		Destroy (gameObject, 2f);
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 look = new Vector3 (player.position.x, transform.position.y, player.position.z);
		transform.LookAt (look);
		goal = player.transform;
		agent.destination = goal.position;

	}
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			playerHitBox.GetComponent<shootFPS> ().playerHealth -= 25;
			Destroy (gameObject);
		}
	}
}
