using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsPlayer : MonoBehaviour {

	public Animator anim;
	public AudioClip shot;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		anim.SetInteger ("animVal", 0);
		if (Input.GetMouseButtonDown (0) && anim.GetInteger ("animVal") != 1) {
			anim.SetInteger ("animVal", 1);
			PlaySound (shot);
		}
	}

	void PlaySound(AudioClip soundName)
	{
		AudioSource audio = GetComponent<AudioSource>();
		if (!audio.isPlaying || audio.clip != soundName)
		{
			audio.clip = soundName;
			audio.Play();
		}
	}
}
