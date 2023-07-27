using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldFreeOrNot_ENG : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        string Firstfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D";
        if (Directory.Exists(Firstfolder))
        {
            string pathToOtherFile = Firstfolder + @"\Save";
            if (Directory.Exists(pathToOtherFile))
            {
                pathToOtherFile = pathToOtherFile + @"\" + gameObject.name;
                if (Directory.Exists(pathToOtherFile))
                {

                    GetComponentInChildren<Text>().text = gameObject.name;
                }
                else
                {
                    GetComponentInChildren<Text>().text = "Free space";
                }
            }
            else
            {
                Directory.CreateDirectory(pathToOtherFile);
                GetComponentInChildren<Text>().text = "Free space";
            }
        }
        else
        {
            Directory.CreateDirectory(Firstfolder);
            string pathToOtherFile = Firstfolder + @"\Save";
            Directory.CreateDirectory(pathToOtherFile);
            GetComponentInChildren<Text>().text = "Free space";
        }
    }

    public void OnClick()
    {
        string Firstfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D";
        string pathToOtherFile = Firstfolder + @"\Save\" + gameObject.name;
        string path = Firstfolder + @"\World_Name.txt";
        if (Directory.Exists(pathToOtherFile))
        {
            StreamWriter writer = new StreamWriter(path, false); //Если директория существовала, тогда в файл сохранится, что мир существует
            writer.WriteLine(gameObject.name);
            writer.Close();
            SceneManager.LoadScene("Main");
        }
        else
        {
            StreamWriter writer = new StreamWriter(path, false); //Если нет, тогда он создаст мир, но значения оттуда браться не будут
            writer.WriteLine(gameObject.name);
            writer.Close();
            SceneManager.LoadScene("Main");
            Directory.CreateDirectory(pathToOtherFile);
        }
    }
}
