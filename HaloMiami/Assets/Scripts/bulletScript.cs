using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	public Transform wall;
	public Transform door;
    public int damageDone;
    public bool fromAlien = false;

	// Use this for initialization
	void Start () {
        if (!fromAlien)
        {
            Transform currentWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().currentWeapon;
            if (currentWeapon != null)
            {
                if (currentWeapon.GetChild(0).CompareTag("repeater"))
                {
                    damageDone = currentWeapon.GetComponent<repeaterScript>().damage;
                }
                else if (currentWeapon.GetChild(0).CompareTag("blaster"))
                {
                    damageDone = currentWeapon.GetComponent<blasterScript>().damage;
                }
                else if (currentWeapon.GetChild(0).CompareTag("phaser"))
                {
                    damageDone = currentWeapon.GetComponent<phaserScript>().damage;
                }
            }
        }
        else
            damageDone = 25;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z);
		if(!fromAlien)
            transform.Translate(0, -3 *Time.deltaTime, 0);
        if (fromAlien)
            transform.Translate(0, 1 * Time.deltaTime, 0);
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy" && !fromAlien)
        {
            other.GetComponent<alienAI>().HitAlien(damageDone, false);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player" && fromAlien)
        {
            other.GetComponent<player>().HitPlayer(damageDone);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Wall" || other.gameObject.tag == "door")
            Destroy(gameObject);
    }
}
