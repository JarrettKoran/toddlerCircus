using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Transform mousePos;
    public Animator anim;
    bool notMoving;
	public AudioClip footSteps;
	public AudioClip hit;
	public bool getHealth = false;
    public Transform currentWeapon;
	public int playerHealth = 100;
    public AudioClip playerNoise;

    // Use this for initialization
    void Start()
    {
        playerHealth = 100;
        notMoving = true;

    }

    // Update is called once per frame
    void Update()
    {
		if (playerHealth == 0) {
            GameObject.Find("PauseMenu").GetComponent<LevelsButtonmanager>().gameOver = true;
            print("player dead");
		}

        //healthbar
        float newSize = playerHealth / 100f;
        GameObject.Find("Health").transform.localScale = new Vector3(newSize, 1, 1);

		if (GameObject.Find("PauseMenu").GetComponent<LevelsButtonmanager>().paused == false) {
			//movement
			if (Input.GetKey (KeyCode.W)) {
				GetComponent<CharacterController> ().Move (Vector3.forward * Time.deltaTime);
				notMoving = false;
			}
			if (Input.GetKey (KeyCode.A)) {
				GetComponent<CharacterController> ().Move (Vector3.left * Time.deltaTime);
				notMoving = false;
			}
			if (Input.GetKey (KeyCode.S)) {
				GetComponent<CharacterController> ().Move (Vector3.back * Time.deltaTime);
				notMoving = false;
			}
			if (Input.GetKey (KeyCode.D)) {
				GetComponent<CharacterController> ().Move (Vector3.right * Time.deltaTime);
				notMoving = false;
			}
			if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.D))
				notMoving = true;

			if (notMoving) {
				anim.SetInteger ("whichAnim", 0);
				StopSound (footSteps);
			} else if (!notMoving) {
				anim.SetInteger ("whichAnim", 1);
				PlaySound (footSteps);
			}

			transform.LookAt (new Vector3(mousePos.position.x,0.6f,mousePos.position.z));
			transform.eulerAngles = new Vector3 (-90, transform.eulerAngles.y, 0);
			transform.position = new Vector3 (transform.position.x, 0.6f, transform.position.z);

            if(currentWeapon == null)
                anim.SetBool("holdingWeapon", false);
            else
                anim.SetBool("holdingWeapon", true);
        }
    }
    public void AmmoReplenish()
    {
        if (currentWeapon != null)
        {
            if (currentWeapon.GetChild(0).CompareTag("repeater"))
            {
                currentWeapon.GetComponent<repeaterScript>().totalAmmo = 100;
            }
            else if (currentWeapon.GetChild(0).CompareTag("blaster"))
            {
                currentWeapon.GetComponent<blasterScript>().totalAmmo = 40;
            }
            else if (currentWeapon.GetChild(0).CompareTag("phaser"))
            {
                currentWeapon.GetComponent<phaserScript>().totalAmmo = 15;
            }
            else if (currentWeapon.GetChild(0).CompareTag("flamethrower"))
            {
                currentWeapon.GetComponent<flameTScript>().totalAmmo = 400;
            }
        }

    }
	void PlaySound(AudioClip soundName)
	{
        AudioSource audio;
        if (soundName == playerNoise)
            audio = GameObject.Find("PlayerNoise").GetComponent<AudioSource>();
        else
            audio = GetComponent<AudioSource>();
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
			audio.Stop ();
		}
	}
    public void HitPlayer(int damage)
	{
        PlaySound(playerNoise);
		anim.Play ("playerDamaged");
        playerHealth -= damage;
		StopSound (footSteps);
		PlaySound (hit);
        if (playerHealth < 0)
            playerHealth = 0;
	}
}
