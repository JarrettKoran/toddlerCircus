using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class FPSEnemy : MonoBehaviour {

	public Animator anim;
	public Transform player;
	NavMeshAgent agent;
	Transform goal;
	int bossHealth;
	public bool alienHit;
	public float timeBetweenHits = 1.5f;
	bool inRange;
    public AudioClip stompSound;
    public AudioClip spitSound;
    public AudioClip breatheSound;

	public Transform stompAttack;
	public Transform spitAttack;

	public Animation spitAnim;
	public Animation stompAnim;

	//Attacks
	public bool stomp;
	public bool spit;

	float hitTimer = 0;

	// Use this for initialization
	void Start () {
		bossHealth = 2000;
		alienHit = false;
		agent = GetComponent<NavMeshAgent>();
		anim = this.GetComponent<Animator>();
		anim.SetInteger ("animVal", 0);

	}
	
	// Update is called once per frame
	void Update () {
		if (bossHealth <= 0) {
			Destroy (gameObject);
			SceneManager.LoadScene(0);
		}

		hitTimer += Time.deltaTime;

        float newSize = bossHealth / 2000f;
        GameObject.Find("EnemyHealth").transform.localScale = new Vector3(newSize, 1, 1);

        goal = player.transform;
		transform.LookAt (new Vector3(player.position.x, transform.position.y, player.position.z));
		agent.destination = goal.position;

			if (hitTimer >= timeBetweenHits) {
				float attack = Random.Range (0,2);
				if (attack >= 0 && attack < 1)
					stomp = true;
				else if (attack >= 1 && attack < 2)
					spit = true;
                hitTimer = 0;
			}
		//if(!spitAnim.isPlaying){
		//	anim.SetInteger ("animVal", 0);
		//}
		if (stomp) {
			anim.SetInteger ("animVal", 1);
			Instantiate (stompAttack, transform.position, transform.rotation);
			PlaySound(stompSound);
			stomp = false;
		} else if (spit) {
			anim.SetInteger ("animVal", 1);
			Instantiate (spitAttack, transform.position, transform.rotation);
            PlaySound(spitSound);
			spit = false;
		} 

		if (alienHit) {
			print ("alien damaged");
			bossHealth -= 10;
			alienHit = false;
            PlaySound(breatheSound);
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

