using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelsButtonmanager : MonoBehaviour {
	public Transform PauseButtonManager;
    //Bools
    public bool paused;
    public bool gameOver;
    //Canvas
    public Canvas pauseMenu;
    public Canvas saveMenu;
    public Canvas overMenu;
    //Buttons
    public Button save1;
    public Button save2;
    public Button save3;
    public Button exit;
    public Button save;
    public Button Quit;
    public Button ExitDesktop;
	public Button back;

    void Start () {

        overMenu.enabled = false;
        pauseMenu.enabled = false;
        saveMenu.enabled = false;
		Time.timeScale = 1;

        //ALL UI OBJECTS MUST BE INITIALIZED HERE!
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        saveMenu = saveMenu.GetComponent<Canvas>();
		overMenu = overMenu.GetComponent<Canvas> ();
        save1 = save1.GetComponent<Button>();
        save2 = save2.GetComponent<Button>();
        save3 = save3.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        save = save.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();
        ExitDesktop = ExitDesktop.GetComponent<Button>();
		back = back.GetComponent<Button> ();
    }
    public void Save()
    {
        saveMenu.enabled = true;
        pauseMenu.enabled = false;
    }
    public void Save1()
    {
		gameObject.GetComponent<Save>().Save1();
		save1.GetComponent<Image> ().color = Color.green;
        saveMenu.enabled = false;
        Time.timeScale = 1;
        paused = false;
    }
    public void Save2()
    {
		gameObject.GetComponent<Save>().Save2();
		save2.GetComponent<Image> ().color = Color.green;
        saveMenu.enabled = false;
        Time.timeScale = 1;
        paused = false;
    }
    public void Save3()
    {
		gameObject.GetComponent<Save>().Save3();
		save3.GetComponent<Image> ().color = Color.green;
        saveMenu.enabled = false;
        Time.timeScale = 1;
        paused = false;
    }
    public void Pause()
    {
        pauseMenu.enabled = true;
        saveMenu.enabled = false;
        paused = true;
    }
    public void Back() {
        saveMenu.enabled = false;
        pauseMenu.enabled = true;
        paused = true;
    }
    public void UnPause()
    {
        pauseMenu.enabled = false;
		saveMenu.enabled = false;
    }
    public void MenuPress()
    {
        SceneManager.LoadScene(0);
		Cursor.visible = true;
		Time.timeScale = 1;
        gameOver = false;
        paused = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void restart()
    {
        gameOver = false;
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update () {
        if (gameOver)
        {
            overMenu.enabled = true;
            Time.timeScale = 0;
            paused = true;

        }
        if (PlayerPrefs.GetInt("save1") != 0)
        {
            save1.GetComponent<Image>().color = Color.green;
            
        }
        if (PlayerPrefs.GetInt("save2") != 0)
        {
            save2.GetComponent<Image>().color = Color.green;
            
        }
        if (PlayerPrefs.GetInt("save3") != 0)
        {
            save3.GetComponent<Image>().color = Color.green;
        }
        //escape
		if (Input.GetKeyDown("escape") && SceneManager.GetActiveScene().name != "bossBattle") {
            if (!paused && !gameOver)
            {
                Pause();
				Time.timeScale = 0;
                paused = true;
            }
            else if(paused && !gameOver)
            {
                UnPause();
                Time.timeScale = 1;
                paused = false;
            }

        }
    }
}
