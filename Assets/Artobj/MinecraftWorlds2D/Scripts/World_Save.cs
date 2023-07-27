using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class World_Save : MonoBehaviour
{
    public void Start()
    {
        string Firstfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D";
        if (Directory.Exists(Firstfolder))
        {
            string pathToOtherFile = Firstfolder + @"\Save";
            if (Directory.Exists(pathToOtherFile))
            {

            }
            else
            {
                Directory.CreateDirectory(pathToOtherFile);
            }
        }
        else
        {
            Directory.CreateDirectory(Firstfolder);
        }
        
    
        string path = @"C:\Users\Admin\AppData\Roaming\minecraftworld2D\test.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();
    }
}