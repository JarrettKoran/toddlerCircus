using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Save : MonoBehaviour {

	public int save1 = 0;
	public int save2 = 0;
	public int save3 = 0;

    // Use this for initialization
    
	void Start () {
    }
    public void Save1()
    {
            PlayerPrefs.SetInt("save1", SceneManager.GetActiveScene ().buildIndex);
			PlayerPrefs.Save();
    }
    public void Save2()
    {
            PlayerPrefs.SetInt("save2", SceneManager.GetActiveScene().buildIndex);
			PlayerPrefs.Save();
    }
    public void Save3()
    { 
            PlayerPrefs.SetInt("save3", SceneManager.GetActiveScene().buildIndex);
			PlayerPrefs.Save();
    }
    public void Load1()
    {
        if(PlayerPrefs.GetInt("save1") != 0)
		    SceneManager.LoadScene(PlayerPrefs.GetInt("save1"));
    }
    public void Load2()
    {
        if (PlayerPrefs.GetInt("save2") != 0)
            SceneManager.LoadScene(PlayerPrefs.GetInt("save2"));
    }
    public void Load3()
    {
        if (PlayerPrefs.GetInt("save3") != 0)
            SceneManager.LoadScene(PlayerPrefs.GetInt("save3"));
    }
    // Update is called once per frame
    void Update () {
    }
}
