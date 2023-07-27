using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class DestroyDeletedObjects : MonoBehaviour
{
    public GameObject test;
    void Start()
    {

        string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
        string NameWorld;

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();

        string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld;
        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
        {
            string WorldExist = PathToWorld + @"\DestroyedBlocks";
            if (File.Exists(WorldExist))
            {
                string stroka;
                int x = 0;
                int y = 0;
                int count = 0;
                StreamReader GenerationWorld = new StreamReader(WorldExist, false);
                while ((stroka = GenerationWorld.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        x = int.Parse(stroka);
                        count++;
                        continue;
                    }
                    else if (count == 1)
                    {
                        y = int.Parse(stroka);
                        count = 0;
                    }
                    Vector3 New_Position = new Vector3(x, y);
                    GameObject gameObjectNew = gameObjectNew = Instantiate(test, New_Position, Quaternion.identity);
                    gameObjectNew.transform.SetParent(gameObject.transform);
                    gameObjectNew.name = "DeletedObject";
                }

            }
        }
        else if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
        {
            string WorldExist = PathToWorld + @"\DestroyedBlocks_Cave";
            if (File.Exists(WorldExist))
            {
                string stroka;
                int x = 0;
                int y = 0;
                int count = 0;
                StreamReader GenerationWorld = new StreamReader(WorldExist, false);
                while ((stroka = GenerationWorld.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        x = int.Parse(stroka);
                        count++;
                        continue;
                    }
                    else if (count == 1)
                    {
                        y = int.Parse(stroka);
                        count = 0;
                    }
                    Vector3 New_Position = new Vector3(x, y);
                    GameObject gameObjectNew = gameObjectNew = Instantiate(test, New_Position, Quaternion.identity);
                    gameObjectNew.transform.SetParent(gameObject.transform);
                    gameObjectNew.name = "DeletedObject";
                }

            }
        }
        StartCoroutine("ad_timer_First");
    }

    IEnumerator ad_timer_First()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
