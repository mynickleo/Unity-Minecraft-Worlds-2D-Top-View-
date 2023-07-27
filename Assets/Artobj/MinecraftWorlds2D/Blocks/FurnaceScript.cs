using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FurnaceScript : MonoBehaviour
{
    public void Start()
    {
        int Count = GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountFurnace;

        if (Count < 1)
        {
            string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
            string NameWorld;

            StreamReader ReaderWorld = new StreamReader(World, false);
            NameWorld = ReaderWorld.ReadLine();
            ReaderWorld.Close();

            string CounterFurnace = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CountFurnace";
            StreamWriter WriterCountFurnace = new StreamWriter(CounterFurnace, false);
            Count++;
            WriterCountFurnace.WriteLine(Count);
            WriterCountFurnace.Close();

            GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountFurnace = Count;
        }
        else if (gameObject.GetComponent<Block_information>().FurnaceVariable > Count)
        {
            string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
            string NameWorld;

            StreamReader ReaderWorld = new StreamReader(World, false);
            NameWorld = ReaderWorld.ReadLine();
            ReaderWorld.Close();

            string CounterFurnace = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CountFurnace";
            StreamWriter WriterCountFurnace = new StreamWriter(CounterFurnace, false);
            Count++;
            WriterCountFurnace.WriteLine(Count);
            WriterCountFurnace.Close();

            GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountFurnace = Count;
        }
    }
}
