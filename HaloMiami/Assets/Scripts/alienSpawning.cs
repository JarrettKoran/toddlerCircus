using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class alienSpawning : MonoBehaviour {
    public Transform spawnpoint;
	public Transform spawnpoint2;
	public Transform spawnpoint3;
	public Transform spawnpoint4;
    public Transform alien;
	public Transform boss;
	public Transform brood;
    public float time = 0;
	public float spawnSpeed;
	public float time2;
    public int alienamount;
    public int aliencount;
	public int waveLevel;
	public int alienSpawned;
	public int random;
    
    public bool nextWave;
    public bool spawn;
	public bool waveDisplay;
	public bool bossWave;
	public Text text;


	//public bool kill;
	// Use this for initialization
	void Start () {
		waveDisplay = false;
		//kill = false;
        nextWave = true;
        spawn = false;
        alienamount = 10;
        waveLevel = 0;
        alienSpawned = 0;
		aliencount = alienamount;
        spawnSpeed = 10;
		random = 0;
		bossWave = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        
		print (aliencount);
        time += Time.deltaTime;

        if (spawn == true)
        {
			if (alienSpawned <= alienamount)
            {
                if (time >= spawnSpeed)
                {
					
					alienSpawned += 1;
					randomSpawn ();

					
                    
                    
                }
            }
            else
            {
                spawn = false;
            }
        }
        if (spawn == false)
        {
            if (aliencount <= 0)
            {
				
                nextWave = true;

				alienSpawned = 0;

            }
        }

		if (nextWave == true) {
			//text.text = "Wave  " + GameObject.Find ("SpawnPoints").GetComponent<alienSpawning> ().waveLevel;
			//GameObject.Find ("General").GetComponent<survivalGeneral> ().newWave(true);

			waveLevel += 1;
			GameObject.Find ("General").GetComponent<survivalGeneral> ().newWave(true);
			Wave(waveLevel);
		}
		if (waveLevel == 5) {
			bossWave = true;

		}


        


    }
	void randomSpawn(){
		random = Random.Range (1,4);
        var obj = alien;
        obj = null;

		if (waveLevel != 5 || waveLevel != 10) {
			 obj = alien;
		}
        if (waveLevel % 5 == 0) {
            if (random == 1 || random == 2)
                obj = boss;
            else if (random == 3 || random == 4) { 
                obj = brood;
                
            }
            nextWave = true;
            GameObject.Find("General").GetComponent<survivalGeneral>().points += 25;
        }
        

		if (random == 1) {

			Instantiate(obj, spawnpoint.position, alien.rotation);
		}
		else if (random == 2) {
			Instantiate(obj, spawnpoint2.position, alien.rotation);
		}
		else if (random == 3) {
			Instantiate(obj, spawnpoint3.position, alien.rotation);
		}
		else if (random == 4) {
			Instantiate(obj, spawnpoint4.position, alien.rotation);
		}
		time = 0;

	}




    void Wave(int waveNumb)
    {
        //if (waveNumb == 1)
        //{
        //alienamount = 10;
            alienamount += 3;
            aliencount = alienamount;
			if (spawnSpeed > 1) {
				spawnSpeed -= 1;
			}
            spawn = true;
			nextWave = false;
            //spawnSpeed = 10;
        //}
    }



}
