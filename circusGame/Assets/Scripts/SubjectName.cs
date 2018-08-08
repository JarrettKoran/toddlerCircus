using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubjectName : MonoBehaviour {

    public InputField name;

    public void ButtonPushed()
    {
        if(name.text != "")
        {
            PlayerPrefs.SetString("subjectName", name.text);
        }
        Debug.Log(name.text);
        Debug.Log(PlayerPrefs.GetString("subjectName"));
    }
}
