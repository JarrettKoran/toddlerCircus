using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class shootFPS : MonoBehaviour {

	public Vector3 forward = Vector3.zero;
	public float range;
	public float shotTime = .5f;
	public float animUpdate = 0;

	public int playerHealth = 100;
	public float time;
	public AudioClip gotHit;

	public AudioClip missionFailed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (playerHealth <= 0 ) {

			PlaySound (missionFailed);

			time += Time.deltaTime;

			if (time >= 4) {
				Application.Quit(); 
			}
			print("player dead");
		}

        float newSize = playerHealth / 100f;
        GameObject.Find("Health").transform.localScale = new Vector3(newSize, 1, 1);

        animUpdate += Time.deltaTime;

		forward = transform.TransformDirection (Vector3.forward)*range;

		Debug.DrawRay (transform.position, forward, Color.cyan);

		if (animUpdate >= shotTime) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				if (Physics.Raycast (transform.position, forward, out hit)) {
					if (hit.transform.tag == "Enemy") {
						hit.transform.GetComponent<FPSEnemy> ().alienHit = true;
					}
				}
				animUpdate = 0;
			}
		}
	}
    public void HitPlayer(int damage)
    {
        playerHealth -= damage;
		PlaySound (gotHit);
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
