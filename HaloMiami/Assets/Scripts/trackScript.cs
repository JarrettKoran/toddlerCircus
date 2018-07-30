using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackScript : MonoBehaviour {
	GameObject[] points;
    public Object alienOnTrack;
    // Use this for initialization
    void Start () {

        GameObject[] points = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			points [i] = transform.GetChild (i).gameObject;
		}
		GameObject alien = Instantiate (alienOnTrack, points[0].transform.position, transform.rotation) as GameObject;
        alien.GetComponent<alienAI>().points = points;
		alien.GetComponent<alienAI> ().trackedInitial = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
