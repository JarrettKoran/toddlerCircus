using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class ButtonManager : MonoBehaviour {
	public Transform MainMenuButtonManager;
	//Buttons
	public Button NewGame;
    public Button LoadGame;
    public Button Exit;
    public Button save1;
    public Button save2;
    public Button save3;
    //Canvas
    public Canvas loadMenu;
	public Canvas mainMenu;
	public Canvas loadScreen;
	public Canvas instructionsScreen;
		
    void Start (){

		mainMenu.enabled = true;
		loadScreen.enabled = false;
        //ALL UI OBJECTS MUST BE INITIALIZED HERE!
        NewGame = NewGame.GetComponent<Button> ();
        save1 = save1.GetComponent<Button>();
        save2 = save2.GetComponent<Button>();
        save3 = save3.GetComponent<Button>();
        loadMenu = loadMenu.GetComponent<Canvas> ();
		mainMenu = mainMenu.GetComponent<Canvas> ();
		instructionsScreen = instructionsScreen.GetComponent<Canvas> ();
		instructionsScreen.enabled = false;
		loadMenu.enabled = false;
	}
	public void LoadPress() {
        loadMenu.enabled = true;
        mainMenu.enabled = false;
	}
	public void MenuPress(){
        loadMenu.enabled = false;
        mainMenu.enabled = true;
		instructionsScreen.enabled = false;
	}
    public void Save1()
    {
        if (PlayerPrefs.GetInt("save1") != 0)
        {
            loadScreen.enabled = true;
            gameObject.GetComponent<Save>().Load1();
        }
    }
    public void Save2()
    {
        if (PlayerPrefs.GetInt("save2") != 0)
        {
            loadScreen.enabled = true;
            gameObject.GetComponent<Save>().Load2();
        }
    }
    public void Save3()
    {
        if (PlayerPrefs.GetInt("save3") != 0)
        {
            loadScreen.enabled = true;
            gameObject.GetComponent<Save>().Load3();
        }
    }
    public void StartLevel (){ 
		mainMenu.enabled = false;
		loadMenu.enabled = false;
		loadScreen.enabled = true;
		SceneManager.LoadScene ("Level1"); 
	}
	public void survivalStart(){
		loadScreen.enabled = true;
		SceneManager.LoadScene ("Survival"); 
	}
	public void ExitGame()
    { 
		Application.Quit(); 
	}
	public void Instructions(){
		mainMenu.enabled = false;
		loadMenu.enabled = false;
		loadScreen.enabled = false;
		instructionsScreen.enabled = true;
	}


	public void Update(){
		

		//Cursor.lockState = CursorLockMode.Confined;
	}



}