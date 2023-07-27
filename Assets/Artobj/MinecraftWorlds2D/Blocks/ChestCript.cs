using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChestCript : MonoBehaviour
{
    public void Start()
    {
        int Count = GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountChest;

        if (Count < 1)
        {
            string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
            string NameWorld;

            StreamReader ReaderWorld = new StreamReader(World, false);
            NameWorld = ReaderWorld.ReadLine();
            ReaderWorld.Close();

            string CounterChest = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CountChest";
            StreamWriter WriterCountChest = new StreamWriter(CounterChest, false);
            Count++;
            WriterCountChest.WriteLine(Count);
            WriterCountChest.Close();

            GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountChest = Count;
        }
        else if(gameObject.GetComponent<Block_information>().ChestVariable > Count)
        {
            string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
            string NameWorld;

            StreamReader ReaderWorld = new StreamReader(World, false);
            NameWorld = ReaderWorld.ReadLine();
            ReaderWorld.Close();

            string CounterChest = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CountChest";
            StreamWriter WriterCountChest = new StreamWriter(CounterChest, false);
            Count++;
            WriterCountChest.WriteLine(Count);
            WriterCountChest.Close();

            GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountChest = Count;
        }
    }
}
