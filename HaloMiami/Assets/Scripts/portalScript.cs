using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class portalScript : MonoBehaviour {
	public Transform player;
	public float beamTime;
	public string nextLevel;
	float time;
	bool beamVerify;
	Animator anim;
    public Font spaceFont;
    public AudioClip portalNoise;

	// Use this for initialization
	void Start () {
		beamVerify = false;
		time = 0;
		beamTime = 3;
		anim = GetComponent<Animator> ();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (beamVerify == true) {
			time += Time.deltaTime;
			anim.SetBool ("Beaming", true);
			if (time >= beamTime) {
				SceneManager.LoadScene (nextLevel);
				time = 0;
				beamVerify = false;
				anim.SetBool ("Beaming", false);
			}
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			beamVerify = true;
            PlaySound(portalNoise);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			beamVerify = false;
			time = 0;
			anim.SetBool ("Beaming", false);
            StopSound(portalNoise);
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
    void StopSound(AudioClip soundName)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio.isPlaying)
        {
            audio.Stop();
        }
    }
    void OnGUI(){
        GUIStyle Style = new GUIStyle();
        Style.font = spaceFont;
        Style.normal.textColor = Color.white;
        GUI.skin.font = spaceFont;
        Style.fontSize = 20;

            if (beamVerify == true) {
             if (time >= 0 && time < 1)
                 GUI.Label(new Rect(Screen.width  /2 - 100, Screen.height / 2 - 50, 100, 60), "teleport in... 3", Style);
             else if (time >= 1 && time < 2)
                 GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 100, 60), "teleport in... 2", Style);
             else if (time >= 2 && time <= 3)
                 GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 100, 60), "teleport in... 1", Style);
		}
	}
}