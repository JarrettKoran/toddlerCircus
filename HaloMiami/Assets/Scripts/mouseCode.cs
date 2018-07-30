using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mouseCode : MonoBehaviour {
	
	public Vector3 mousePos;
	public float moveSpeed = .1f;
    public Transform player;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
       
	}
	
	// Update is called once per frame
	void Update () {


        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
			Camera.main.transform.position.y - player.transform.position.y));
        mousePos = new Vector3(mousePos.x, 3, mousePos.z);
        transform.position = mousePos;

	}
}
