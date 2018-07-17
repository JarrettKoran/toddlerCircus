using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour {

    public Slider slider;
    public AudioSource bgm;
	
	// Update is called once per frame
	void Update () {
        bgm.volume = slider.value/10;
        PlayerPrefs.SetFloat("volume", bgm.volume);
    }
}
