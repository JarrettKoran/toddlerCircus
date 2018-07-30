using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	public Transform player;
	public float smoothTimeX = 0.6F;
	public float smoothTimeY = 0.15F;
	private float xVelocity = 0.0F;
	private float zVelocity = 0.0F;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float newPositionX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref xVelocity, smoothTimeX);
		float newPositionZ = Mathf.SmoothDamp(transform.position.z, player.position.z, ref zVelocity, smoothTimeY);

		transform.position = new Vector3 (newPositionX,
			transform.position.y, newPositionZ);
	}
}
