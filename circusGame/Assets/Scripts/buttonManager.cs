﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;




public class buttonManager : MonoBehaviour {

	public bool gameOver = false;
    public bool restarted = false;

    public GameObject gameOverPanel;
    public GameObject scorePanel;

	public DataLogger data;
    private List<string> headerNames = new List<string>();
    SceneChanger sc;

    // Use this for initialization
    void Start () {
        //"Level,Time Between Balloons,Time To Orient,Fixation Time, Fixation Loss, Times Played"
        headerNames.Add("Level");
        headerNames.Add("Time Between Balloons");
        headerNames.Add("Time To Orient");
        headerNames.Add("Fixation Time");
        headerNames.Add("Fixation Loss");
        headerNames.Add("Times Played");
        //Create a filepath it has not been created
        if (!PlayerPrefs.HasKey("filename"))
		{
			UnityEngine.Debug.Log ("New File");
			string location = "Assets\\Data\\";
			string format = DateTime.Now.ToString();
			format = format.Replace("/", "_");
			format = format.Replace(" ", "_");
			format = format.Replace(":", "_");
			UnityEngine.Debug.Log (format);
			string session = "session_" + format;
            string subjectName = PlayerPrefs.GetString("subjectName", "");
            UnityEngine.Debug.Log("subjectName: " + subjectName);
            string name = location + subjectName + session + ".txt";
            UnityEngine.Debug.Log(name);
            PlayerPrefs.SetString("filename", name);
		}
		if(!PlayerPrefs.HasKey("CSVName"))
		{
			string location = "Assets\\CSVLogs\\";
			string format = DateTime.Now.ToString();
			format = format.Replace("/", "_");
			format = format.Replace(" ", "_");
			format = format.Replace(":", "_");
			UnityEngine.Debug.Log (format);
			string session = "session_" + format;
            string subjectName = PlayerPrefs.GetString("subjectName", "");
            string csvName = location + subjectName + session + ".csv";
			UnityEngine.Debug.Log ("csvname: " + csvName);
			PlayerPrefs.SetString("CSVName", csvName);
			File.AppendAllText(PlayerPrefs.GetString("CSVName"), header());
		}

		if (!PlayerPrefs.HasKey("sessions"))
			PlayerPrefs.SetInt("sessions", 1);
		else
			PlayerPrefs.SetInt("sessions", PlayerPrefs.GetInt("sessions") + 1);
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver){
			GameOver();
		}
	}


	private string header()
	{
		return "Level,Time Between Balloons,Time To Orient,Fixation Time, Fixation Loss, Times Played\n";
	}
	 
	private string addItem(Dictionary<string,float> dic, string find, bool addComma)
	{
		string dataPoint = "";
		if(dic.ContainsKey(find))
		{
			dataPoint += dic[find].ToString();
		}
		if(addComma)
		{
			dataPoint += ",";
		}
		return dataPoint;
	}

    private int getHighest(Dictionary<string, List<float>> dic)
    {
        int high = 0;
        for(int i = 0; i < headerNames.Count; i++)
        {
            if (dic.ContainsKey(headerNames[i]))
            {
                if(dic[headerNames[i]].Count > high)
                {
                    high = dic[headerNames[i]].Count;
                }
            }
        }
        return high;
    }

    private string addAllItems(Dictionary<string,List<float>> dic)
    {
        string dataLines = "";
        int count = getHighest(dic);
        for(int i = 0; i < count; i++)
        {
            for (int j = 0; j < headerNames.Count; j++)
            {
                if(dic.ContainsKey(headerNames[j]) && dic[headerNames[j]].Count > i)
                {
                    dataLines += dic[headerNames[j]][i].ToString();
                }
                if(j < headerNames.Count - 1)
                {
                    dataLines += ",";
                }
            }
            dataLines += "\n";
        }
        return dataLines;
    }

	private string recordData(Dictionary<string, float> averageData)
	{
		string dataLine = "";
        /*dataLine += addItem (averageData, "Level", true);
		dataLine += addItem (averageData, "Time Between Balloons", true);
		dataLine += addItem (averageData, "Time To Orient", true);
		dataLine += addItem (averageData, "Fixation Time", true);
        dataLine += addItem(averageData, "Fixation Loss", true);
		dataLine += addItem (averageData, "Times Played", false);
        */
        dataLine = addAllItems(data.totalData);
		return dataLine;
	}


    public void NewGameButton(string newGameScene)
    {
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame()
    {
		data.LogAverages();
        data.LogEntry("Times Played", data.avgData["Times Played"]);
        string td = JsonConvert.SerializeObject(data.totalData);
        string ad = JsonConvert.SerializeObject(data.avgData);
        /*string td = JsonConvert.SerializeObject(data.totalData);
		UnityEngine.Debug.Log(ad);
		UnityEngine.Debug.Log(td);
		*/
        File.AppendAllText(PlayerPrefs.GetString("filename"), td + "\n");
        File.AppendAllText(PlayerPrefs.GetString("filename"), ad + "\n");
		File.AppendAllText(PlayerPrefs.GetString("CSVName"), recordData(data.avgData) + "\n");
		//Done writing to file, destroy all keys
		PlayerPrefs.DeleteAll();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
    public void GameOver() {
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        scorePanel.SetActive(false);
    	gameOverPanel.SetActive(true);
        
    }
    public void restart() {
        restarted = true;
		data.LogAverages();
        Cursor.visible = false;
        data.LogEntry("Times Played", data.avgData["Times Played"]);
        string td = JsonConvert.SerializeObject(data.totalData);
        string ad = JsonConvert.SerializeObject(data.avgData);
        File.AppendAllText(PlayerPrefs.GetString("filename"), td + "\n");
        File.AppendAllText(PlayerPrefs.GetString("filename"), ad + "\n");
		File.AppendAllText(PlayerPrefs.GetString("CSVName"), recordData(data.avgData) + "\n");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    	gameOverPanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        data.LogAverages();
        data.LogEntry("Times Played", data.avgData["Times Played"]);
        string td = JsonConvert.SerializeObject(data.totalData);
        string ad = JsonConvert.SerializeObject(data.avgData);
        /*string td = JsonConvert.SerializeObject(data.totalData);
		UnityEngine.Debug.Log(ad);
		UnityEngine.Debug.Log(td);
		*/
        File.AppendAllText(PlayerPrefs.GetString("filename"), td + "\n");
        File.AppendAllText(PlayerPrefs.GetString("filename"), ad + "\n");
        File.AppendAllText(PlayerPrefs.GetString("CSVName"), recordData(data.avgData) + "\n");
        SceneManager.LoadScene(0);
    }

}
