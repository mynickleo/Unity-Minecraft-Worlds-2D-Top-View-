using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadMusic : MonoBehaviour
{
    void Start()
    {
        string Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\GameOptionsSave";
        if (File.Exists(Folder))
        {
            StreamReader LoadStats = new StreamReader(Folder, false);
            gameObject.GetComponent<Scrollbar>().value = (float)Convert.ToDouble(LoadStats.ReadLine());
            LoadStats.Close();
        }
    }

}
