using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameBulletScript : MonoBehaviour {

	public Transform wall;
	public Transform door;

	// Use this for initialization
	void Start () {
		transform.Rotate (0, 0, Random.Range(-30,30));
		Destroy (gameObject, .2f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -3 *Time.deltaTime, 0);
	}
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<alienAI>().HitAlien(0, true);
        }
        else if (other.gameObject.tag == "Wall")
			Destroy(gameObject);
		else if(other.gameObject.tag == "door")
			Destroy(gameObject);
    }
}
