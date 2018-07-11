using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataLogger : MonoBehaviour {

    //Holder for any metadata we may need to record
    public Dictionary<string, float> metadata;
	public Dictionary<string, List<float>> totalData;
    //Holder for all the averages of data recorded over a session
    public Dictionary<string, float> avgData;

	public DataLogger()
	{
        metadata = new Dictionary<string, float>();
        totalData = new Dictionary<string, List<float>>();
        avgData = new Dictionary<string, float>();

	}

    /*Add an entry to the totalData dictionary. If the item has not been recorded
     * before, add that key, then add objects to the corresponding list
     */
    public void LogEntry(string key, float value)
    {
        if (!totalData.ContainsKey(key))
            totalData[key] = new List<float>();
        totalData[key].Add(value);
    }

    /*Calculate the average of each list item. List items should be either an int
     * or a float, if not, the avgdata list will skip said items.
     */
    public void LogAverages()
    {
        //Get list of keys
        List<string> keys = new List<string>(totalData.Keys);
        //Iterate over all data points of total data
        for (int i = 0; i < totalData.Count; i++)
        {
			if(keys[i] == "Level")
			{
				avgData[keys [i]] = totalData[keys[i]][totalData[keys[i]].Count - 1];
				continue;
			}
			//total all data underneath a singular key
            float total = 0.0f;
            for (int j = 0; j < totalData[keys[i]].Count; j++)
            {
                total += totalData[keys[i]][j];
            }
            //calculate the average and add it to avg data
            avgData[keys[i]] = total / (float) totalData[keys[i]].Count;
        }
		avgData ["Times Played"] = PlayerPrefs.GetInt("sessions");
    }

}
