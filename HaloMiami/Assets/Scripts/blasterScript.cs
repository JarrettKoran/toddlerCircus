using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blasterScript : MonoBehaviour {
	public Transform player;
	public Object bullet;
	public bool startWaiting;
	public int ammoInClip = 25;
	public int totalAmmo = 50;
	int ammoRemaining;
	public float addedUpTime;
    public int damage = 20;

	public AudioClip shot;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		startWaiting = false;
		ammoRemaining = ammoInClip;
	}

	// Update is called once per frame
	void Update () {

		StopSound (shot);
        if (GameObject.Find("PauseMenu").GetComponent<LevelsButtonmanager>().paused == false)
        {
            if (ammoRemaining != 0)
            {
                if (Input.GetMouseButtonDown(0) && transform.parent != null)
                {
                    PlaySound(shot);
                    Instantiate(bullet, transform.GetChild(0).position, transform.parent.rotation);
                    ammoRemaining--;
                }
            }
            if (totalAmmo > 0 && Input.GetKeyDown("r"))
            {
                if ((ammoInClip - ammoRemaining) > totalAmmo)
                {
                    ammoRemaining += totalAmmo;
                    totalAmmo = 0;
                }
                else
                {
                    totalAmmo -= (ammoInClip - ammoRemaining);
                    ammoRemaining = ammoInClip;
                }
            }
            if (startWaiting && Input.GetKeyDown(KeyCode.Space))
            {
                GameObject[] guns = GameObject.FindGameObjectsWithTag("weapon");
                for (int i = 0; i < guns.Length; i++)
                {
                    if (guns[i].transform.parent != null && guns[i].transform.parent.tag == "Player")
                    {
                        guns[i].transform.parent = null;
                        guns[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
                    }
                }
                transform.parent = player;
                transform.position = player.position;
                transform.localPosition = transform.GetChild(1).localPosition;
                transform.eulerAngles = new Vector3(-player.eulerAngles.x, player.eulerAngles.y, player.eulerAngles.z);
                player.gameObject.GetComponent<player>().currentWeapon = gameObject.transform;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                startWaiting = false;
            }
        }
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && transform.parent == null)
		{
			startWaiting = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && transform.parent == null)
		{
			startWaiting = false;
		}
	}
    void OnGUI()
    {
        if (transform.parent != null)
			GameObject.Find("AmmoText").GetComponent<Text>().text = ammoRemaining + " / " + totalAmmo;
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
		if (audio.isPlaying && Input.GetMouseButtonDown(0))
		{
			audio.Stop ();
		}
	}
}
