using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour {
	public bool openDoor;
	public float speed;
	public float moveDistance;
	public Transform door;
	public Vector3 pos = new Vector3();
//	public Vector3 moveDirection = new Vector3(0.1f, 0,0);
	public Vector3 targetPosition = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
		openDoor = false;
        //door.transform.localPosition = Vector3.zero;
        speed = 1.0f;
		moveDistance = .5f;
		pos = transform.position;
        if(transform.parent.eulerAngles.y == 0)
            targetPosition = transform.localPosition + transform.TransformDirection(Vector3.forward) * moveDistance;
        else
            targetPosition = transform.localPosition + transform.TransformDirection(Vector3.left) * moveDistance;

    }
	
	// Update is called once per frame
	void Update () {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.parent.GetChild(0).GetComponent<doorScript>().openDoor || transform.parent.GetChild(1).GetComponent<doorScript>().openDoor)
            openDoor = true;
        else if (Vector3.Distance(transform.position, player.position) <= .7f)
        {
            openDoor = true;
            PlaySound();
        }
		if (openDoor == true) {
			transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
		}
        if (Vector3.Distance(transform.localPosition, targetPosition) <= .15f && Vector3.Distance(transform.localPosition, targetPosition) >= .1f)
            StopSound();
	}
    void PlaySound()
    {
        AudioSource audio = GameObject.Find("DoorNoise").GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.Play();
        }

    }
    void StopSound()
    {
        AudioSource audio = GameObject.Find("DoorNoise").GetComponent<AudioSource>();
        if (audio.isPlaying)
        {
            audio.Stop();
        }

    }
}