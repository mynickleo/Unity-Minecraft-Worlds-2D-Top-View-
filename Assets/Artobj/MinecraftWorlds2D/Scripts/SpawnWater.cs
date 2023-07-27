using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    //-->Оформляю переменные для создания деревьев с помощью метода Шума Перлина
    public float Zoom = 10f;
    float SeedWorld;
    float Count_MathfPerlin;

    public int count_create = 0;

    public GameObject DataBase; // Все-все блоки, которые есть в игре, помещаются в дату

    int id_gr_block;
    void Start()
    {
        string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
        string NameWorld;

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();

        string WorldSeed = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\Seed";
        StreamReader ReaderWorldSeed = new StreamReader(WorldSeed, false);
        SeedWorld = (float)Convert.ToDouble(ReaderWorldSeed.ReadLine());
        ReaderWorldSeed.Close();
        int rand = UnityEngine.Random.Range(0, 2);
        Vector3 New_Position = new Vector3();

        int test = Convert.ToInt32(gameObject.transform.position.x) - 25;

        for (int i = (Convert.ToInt32(gameObject.transform.position.x) - 25); i <= (Convert.ToInt32(gameObject.transform.position.x) + 25); i++)
        {
            for (int j = (Convert.ToInt32(gameObject.transform.position.y) - 25); j <= (Convert.ToInt32(gameObject.transform.position.y) + 25); j++)
            {
                Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);
                if (Count_MathfPerlin > 0.23 && Count_MathfPerlin < 0.35 && count_create < 8) // Если значение такое, то будут спавниться озеры
                {
                    New_Position = new Vector3(i, j, -1);
                    id_gr_block = 5;

                    GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
                    gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_Sand";
                    gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
                    gameobjectNew.transform.SetParent(gameObject.transform);
                }

            }
            count_create++;
        }
    }

    /*IEnumerator SpawnTrees()

    {
        
        
    }*/
}

