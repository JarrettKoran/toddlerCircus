using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class survivalGeneral : MonoBehaviour {
    public Transform general;
    public int points;
	public Font font1;
	public Text text;
    public AudioClip music;
    //public bool nextWave;
    public float time;
	public bool check;
    public bool play;
	// Use this for initialization
	void Start () {
        points = 0;
		time = 0;
        

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time < 3) {
		} else if (check == false && time > 3){
			print ("check");
			text.text = " ";
			time = 0;
		}
        AudioSource audio = GetComponent<AudioSource>();
        if(!audio.isPlaying)
        PlaySound(music);

    }
	void OnGUI()
	{
		GUIStyle Style = new GUIStyle();
		Style.font = font1;
		Style.normal.textColor = Color.white;
        Style.fontSize = 20;

        GUI.skin.font = font1;

		if (GameObject.Find ("SpawnPoints").GetComponent<alienSpawning> ().nextWave == false){
		GUI.Label(new Rect(10, 10, 100, 100), "Wave " + GameObject.Find ("SpawnPoints").GetComponent<alienSpawning> ().waveLevel , Style);
        GUI.Label(new Rect(10, 30, 100, 500), "Points: " + points, Style);
        }

	}

	public void newWave(bool nextWave){
		
		if (nextWave == true) {
			check = nextWave;
			time += Time.deltaTime;
			if (time < 3) {
				
				text.text = "Wave  " + GameObject.Find ("SpawnPoints").GetComponent<alienSpawning> ().waveLevel;
				check = false;
			} 
		} else if (time > 3) {
			
			text.text = " ";
			nextWave = false;
			time = 0;
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
