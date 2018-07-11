using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{

    public DataLogger logger;

    // Use this for initialization
    void Start()
    {
        logger = new DataLogger();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public DataLogger GetLogger()
    {
        return logger;
    }

}
