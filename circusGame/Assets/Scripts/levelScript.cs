using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelScript : MonoBehaviour
{

    private int level;

    private float nextActionTime = 0.0f;
    public float period = 2f;

    public GameObject levelMenuUI;

    //private float startTime = 0;
    public Text lvlT;

    public DataLogger data;

    // Use this for initialization
    void Start()
    {
        level = 0;
    }

	// Update is called once per frame
	void Update()
    {
        if (level == 11)
        {
            lvlT.text = "You Win!";
        }
        else if (GameObject.Find("balloonSpawn").GetComponent<BalloonSpawn>().currLevel > level)
        {
            levelUp();
            level = GameObject.Find("balloonSpawn").GetComponent<BalloonSpawn>().currLevel;
            lvlT.text = "Level " + level.ToString();
            levelMenuUI.SetActive(true);
            if (level == 1)
            {
                data.LogEntry("Level", 1.0f);
            }
            else
            {
                data.totalData["Level"][data.totalData["Level"].Count - 1] = data.totalData["Level"][data.totalData["Level"].Count - 1] + 1;
            }
            //Debug.Log("Current Level is: " + data.totalData["Level"][data.totalData["Level"].Count - 1]);
            //startTime = Time.time;
            //GameObject.Find("carnieBoi").GetComponent<Animator>().PlayInFixedTime("Carnie", -1, 3.0f);

        } 

        if (levelMenuUI.activeSelf == true)
        {
            Invoke("LevelOff", 2f);
        }

    }

    void levelUp()
    {
        GameObject.Find("carnieBoi").GetComponent<Animator>().SetTrigger("LevelUp");
    }

    void LevelOff()
    {
        levelMenuUI.SetActive(false);
    }


}
