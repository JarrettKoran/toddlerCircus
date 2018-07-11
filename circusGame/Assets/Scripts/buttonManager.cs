using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;


/*public class DataPoint 
{
	public float level;
	public float timeBetweenBalloons;
	public float timeToOrient;
	public float fixationTime;
	public float played;

	
	public DataPoint(float l, float tb, float tt, float f, float p)
	{
		level = l;
		timeBetweenBalloons = tb;
		timeToOrient = tt;
		fixationTime = f;
		played = f;
	}

	public DataPoint(float l, float p)
	{
		level = l;
		played = p;
	}



}
*/

public class buttonManager : MonoBehaviour {

	public bool gameOver = false;
    public bool restarted = false;

    public GameObject gameOverPanel;
    public GameObject scorePanel;

	public DataLogger data;

    // Use this for initialization
    void Start () {
		//Create a filepath it has not been created
		if(!PlayerPrefs.HasKey("filename"))
		{
			UnityEngine.Debug.Log ("New File");
			string location = "Assets\\Data\\";
			string format = DateTime.Now.ToString();
			format = format.Replace("/", "_");
			format = format.Replace(" ", "_");
			format = format.Replace(":", "_");
			UnityEngine.Debug.Log (format);
			string session = "session_" + format;
			string name = location + session + ".txt";
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
			string csvName = location + session + ".csv";
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
		return "Level,Time Between Balloons,Time To Orient,Fixation Time, Times Played\n";
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

	private string recordData(Dictionary<string, float> averageData)
	{
		string dataLine = "";
		dataLine += addItem (averageData, "Level", true);
		dataLine += addItem (averageData, "Time Between Balloons", true);
		dataLine += addItem (averageData, "Time To Orient", true);
		dataLine += addItem (averageData, "Fixation Time", true);
		dataLine += addItem (averageData, "Times Played", false);
		return dataLine;
	}


    public void NewGameButton(string newGameScene)
    {
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame()
    {
		data.LogAverages();
		string ad = JsonConvert.SerializeObject(data.avgData);
		/*string td = JsonConvert.SerializeObject(data.totalData);
		UnityEngine.Debug.Log(ad);
		UnityEngine.Debug.Log(td);
		*/
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
        scorePanel.SetActive(false);
    	gameOverPanel.SetActive(true);
        
    }
    public void restart() {
        restarted = true;
		data.LogAverages();
		string ad = JsonConvert.SerializeObject(data.avgData);
		File.AppendAllText(PlayerPrefs.GetString("filename"), ad + "\n");
		File.AppendAllText(PlayerPrefs.GetString("CSVName"), recordData(data.avgData) + "\n");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    	gameOverPanel.SetActive(false);
    }


}
