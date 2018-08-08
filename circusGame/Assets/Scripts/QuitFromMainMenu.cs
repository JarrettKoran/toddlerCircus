using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitFromMainMenu : MonoBehaviour {

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
