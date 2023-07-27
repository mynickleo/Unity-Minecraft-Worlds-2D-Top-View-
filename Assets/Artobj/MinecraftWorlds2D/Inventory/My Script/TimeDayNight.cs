using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeDayNight : MonoBehaviour
{
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;

    public void Start()
    {
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats";
        if (File.Exists(Folder))
        {
            StreamReader TransformPosition = new StreamReader(Folder, false);
            for (int i = 0; i < 3; i++)
            {
                if (i == 2) gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, (float)Convert.ToDouble(TransformPosition.ReadLine()));
                TransformPosition.ReadLine();
            }
            TransformPosition.Close();
        }

        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Cave";
        if (File.Exists(Folder))
        {
            StreamReader TransformPosition = new StreamReader(Folder, false);
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, (float)Convert.ToDouble(TransformPosition.ReadLine()));
            TransformPosition.Close();
        }

        StartCoroutine("DayToNight");
    }

    public void SkipNightPoint()
    {
        if (transform.position.z < -35)
        {
            for (float i = gameObject.transform.position.z; i <= -12; i++)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, i);
            }
            StartCoroutine("DayToNight");
        }
    }
    IEnumerator DayToNight()

    {
        yield return new WaitForSeconds(30);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        if (transform.position.z < -59)
        {
            StartCoroutine("NightToDay");
        }
        else StartCoroutine("DayToNight");
    }

    IEnumerator NightToDay()

    {
        yield return new WaitForSeconds(8);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        if (transform.position.z > -10)
        {
            StartCoroutine("DayToNight");
        }
        else StartCoroutine("NightToDay");
    }

}
