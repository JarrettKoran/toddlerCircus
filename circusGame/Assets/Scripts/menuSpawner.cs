using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSpawner : MonoBehaviour {

	 private float nextActionTime = 1f;
	 public float period = 5f;

	 public Object greenBalloon;
	 public Object redBalloon;
	 public Object yellowBalloon;
     public Object blueBalloon;
     public Object whiteBalloon;

	public float timer;

	// Use this for initialization
	void Start () {

		timer = 0f;
    }

	// Update is called once per frame
	void Update () {

       

		timer += Time.deltaTime;
            if (timer > nextActionTime)
            {
				timer = 0;
                
                int random = Random.Range(0, 5);
                if (random == 0)
                {
                    Instantiate(redBalloon, new Vector3(Random.Range(-11f, 6f),
                    this.transform.position.y, this.transform.position.z), Quaternion.identity);
                }
                else if (random == 1)
                {
                    Instantiate(greenBalloon, new Vector3(Random.Range(-11f, 6f),
                    this.transform.position.y, this.transform.position.z), Quaternion.identity);
                }
                else if (random == 2)
                {
                    Instantiate(whiteBalloon, new Vector3(Random.Range(-11f, 6f),
                    this.transform.position.y, this.transform.position.z), Quaternion.identity);
                }
                else if (random == 3)
                {
                    Instantiate(blueBalloon, new Vector3(Random.Range(-11f, 6f),
                    this.transform.position.y, this.transform.position.z), Quaternion.identity);
                }
                else
                {
                    Instantiate(yellowBalloon, new Vector3(Random.Range(-11f, 6f),
                    this.transform.position.y, this.transform.position.z), Quaternion.identity);
                }
                
                
            }
        


	}
}
