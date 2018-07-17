using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {

    public AudioSource bgm;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            bgm.volume = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            bgm.volume = .8;
        }

    }
}
