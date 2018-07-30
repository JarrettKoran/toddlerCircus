using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backMusic : MonoBehaviour {

	public AudioClip menu;
	public AudioClip dualOfFates;
	public AudioClip alien1;
	public AudioClip alien2;
    public AudioClip alien3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (SceneManager.GetActiveScene().name == "startMenuV2")
			PlaySound(menu);
        else if (SceneManager.GetActiveScene().name == "Level1")
			PlaySound(alien1);
        else if (SceneManager.GetActiveScene().name == "Level2")
            PlaySound(alien2);
        else if (SceneManager.GetActiveScene().name == "Survival")
            PlaySound(alien3);
        else if (SceneManager.GetActiveScene().name == "bossBattle")
			PlaySound(dualOfFates);
        
            
        
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
