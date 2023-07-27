using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FindSeed : MonoBehaviour
{
    public float SeedWorld_ = 0;

    ///ѕропишу переменную дл€ нахождени€ количества сундуков и печек
    public int CountChest = 0;
    public int CountFurnace = 0;
    void Start()
    {
        string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
        string NameWorld;

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();

        string WorldSeed = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\Seed";
        StreamReader ReaderWorldSeed = new StreamReader(WorldSeed, false);
        SeedWorld_ = (float)Convert.ToDouble(ReaderWorldSeed.ReadLine());
        ReaderWorldSeed.Close();

        ///ѕоиск количества сундука и печки
        string CounterChest = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CountChest";
        if (File.Exists(CounterChest))
        {
            StreamReader ReaderCountChest = new StreamReader(CounterChest, false);
            CountChest = Convert.ToInt32(ReaderCountChest.ReadLine());
            ReaderCountChest.Close();
        }

        string CounterFurnace = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CountFurnace";
        if (File.Exists(CounterFurnace))
        {
            StreamReader ReaderCountFurnace = new StreamReader(CounterFurnace, false);
            CountFurnace = Convert.ToInt32(ReaderCountFurnace.ReadLine());
            ReaderCountFurnace.Close();
        }
    }

}
