using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        string Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\GameOptionsSave";
        if (File.Exists(Folder))
        {
            StreamReader LoadStats = new StreamReader(Folder, false);
            LoadStats.ReadLine();
            float distance = (float)Convert.ToDouble(LoadStats.ReadLine());
            if (distance < 0.3)
            {
                gameObject.GetComponent<Camera>().orthographicSize = 4;
            }
            else if (distance > 0.3 && distance < 0.7)
            {
                gameObject.GetComponent<Camera>().orthographicSize = 5;
            }
            else if(distance > 0.7)
            {
                gameObject.GetComponent<Camera>().orthographicSize = 7;
            }
            LoadStats.Close();
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F11))
        {
            if (count == 0)
            {
                Screen.SetResolution(1920, 1080, true);
                count = 1;
            }
            else if (count == 1)
            {
                Screen.SetResolution(1920, 1080, false);
                count = 0;
            }
        }
    }
}
