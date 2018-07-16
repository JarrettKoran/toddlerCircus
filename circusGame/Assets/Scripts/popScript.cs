using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popScript : MonoBehaviour {

	public AudioClip popSound;

	private AudioSource source;
	private float volLow = .4f;
	private float volHigh = .9f;
	private float pitchLow = .65f;
	private float pitchHigh = 1.5f;

	void Awake ()
	{
		source = GetComponent<AudioSource>();
		popSound = source.clip;
		source.pitch = Random.Range(pitchLow, pitchHigh);
		source.PlayOneShot(popSound, Random.Range(volLow, volHigh));
	}

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject,1.0f);
	}

	// Update is called once per frame
	void Update () {

	}
}
