using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("EscapePressed");
            gamePaused = !gamePaused;
          
        }
        if (!gamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
        public void Resume ()
        {
            if (!GameObject.Find("ButtonManager").GetComponent<buttonManager>().gameOver)
                Cursor.visible = false;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1.0f;
            gamePaused = false;
        }
        public void Pause ()
        {
            Cursor.visible = true;
            //Debug.Log("Paused");
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0.0f;
            gamePaused = true;
        }

	
}
