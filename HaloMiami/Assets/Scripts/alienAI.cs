using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class alienAI : MonoBehaviour {

    //Variables that change between aliens
    public float sightRange = 4;
    public int hitDamage = 25;
    public float timeBetweenHits = 1;
    public int alienHealth = 100;
    public bool canShoot = false;
    public Object alienBullet;
	public AudioClip alienNoise;

    //Utility variables
    NavMeshAgent agent;
	Transform goal;
	bool agroed = false;
	public GameObject[] points;
	int pointIndex = 0;
    float flamedTimer = 0;
    bool onFire;
    float hitTimer = 0;
	public bool trackedInitial = false;
    Animator anim;
	float stoppedTimer = 0;


    void Start () {
	    InvokeRepeating("UpdateTarget", 0f, 0.5f);
	    agent = GetComponent<NavMeshAgent>();
        anim = transform.GetChild(0).GetComponent<Animator>();
	}


	void FixedUpdate() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
        hitTimer += Time.fixedDeltaTime;
		stoppedTimer += Time.fixedDeltaTime;
		
        if (goal != null) {
			agent.destination = goal.position;
        	transform.LookAt(new Vector3(goal.position.x,0.6f,goal.position.z));
        }
	//health
        if (onFire)
            alienHealth -= 5;
        if (flamedTimer + 2 >= Time.time)
            onFire = false;
		if (alienHealth <= 0) {
			Destroy (gameObject);
            if (SceneManager.GetActiveScene().name == "Survival")
            {
                GameObject.Find("SpawnPoints").GetComponent<alienSpawning>().aliencount -= 1;
                GameObject.Find("General").GetComponent<survivalGeneral>().points += 1;
            }
        }

	//animations
		if(anim.GetInteger("whichAnim") != 0)
			anim.SetInteger("whichAnim", 0);
			
        if (!canShoot && agroed && Vector3.Distance(transform.position, player.transform.position) < .3f)
        {
            if (hitTimer >= timeBetweenHits)
            {
                player.GetComponent<player>().HitPlayer(hitDamage);
                anim.SetInteger("whichAnim", 1);
                agent.Stop();
                hitTimer = 0;
				stoppedTimer = 0;
            }
        }
        else if(canShoot && agroed)
        {
            if (hitTimer >= timeBetweenHits)
            {
                Instantiate(alienBullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
                anim.SetInteger("whichAnim", 1);
                agent.Stop();
                hitTimer = 0;
				stoppedTimer = 0;
            }
        }
        if (stoppedTimer >= 0.5)
            agent.Resume();
    }


	void UpdateTarget() {
		
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (SceneManager.GetActiveScene().buildIndex == 4){
			agroed = true;
			goal = player.transform;
		}
		else{
	    NavMeshHit hit;
        if (Vector3.Distance (transform.position, player.transform.position) <= sightRange && !agent.Raycast(player.transform.position, out hit)) {
	        goal = player.transform;
	    	agroed = true;
	    }
	    else if(Vector3.Distance (transform.position, player.transform.position) > sightRange)
			agroed = false;

		if (!agroed && trackedInitial) {
	        goal = points[pointIndex].transform;
	        if(Vector3.Distance(transform.position, points[pointIndex].transform.position) <= 1f)
	            pointIndex++;
	        if (pointIndex >= points.Length)
	            pointIndex = 0;
		}
		}    
	}
    public void HitAlien(int damage, bool flameThrower)
    {
		anim.Play("alienDamaged");
		PlaySound (alienNoise);
		agent.Stop();
		stoppedTimer = 0;

        if (!flameThrower)
            alienHealth -= damage;
        else
        {
            onFire = true;
            flamedTimer = Time.time;
        }

        if (alienHealth <= 0 && !flameThrower) {
			
			Destroy (gameObject, 0.49f);


		}
    }
	void PlaySound(AudioClip soundName)
	{
		AudioSource audio = GameObject.Find("AlienNoises").GetComponent<AudioSource>();
		if (!audio.isPlaying || audio.clip != soundName)
		{
			audio.clip = soundName;
			audio.Play();
		}
	}
}