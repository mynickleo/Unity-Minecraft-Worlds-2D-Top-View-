using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadDistance : MonoBehaviour
{
    void Start()
    {
        string Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\GameOptionsSave";
        if (File.Exists(Folder))
        {
                    StreamReader LoadStats = new StreamReader(Folder, false);
                        LoadStats.ReadLine();
                        gameObject.GetComponent<Scrollbar>().value = (float)Convert.ToDouble(LoadStats.ReadLine());
                    LoadStats.Close();
        }
    }
}
