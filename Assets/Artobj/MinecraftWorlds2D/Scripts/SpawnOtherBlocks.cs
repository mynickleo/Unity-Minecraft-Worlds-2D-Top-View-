using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnOtherBlocks : Generator_First
{
    int Trigger = 0;

    private int count = 1;

    public GameObject DataBase; // ¬се-все блоки, которые есть в игре, помещаютс€ в дату

    private float coordinate_x = 0;
    private float coordinate_y = 0;
    int TriggerOrNot = 0;

    void Start()
    {
        StartCoroutine("CheckDeletedObjects_");
    }

    IEnumerator CheckDeletedObjects_()

    {
        yield return new WaitForSeconds(2);
        if (GameObject.Find("DeletedObject_") == null)
        {
            string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
            string NameWorld;

            StreamReader ReaderWorld = new StreamReader(World, false);
            NameWorld = ReaderWorld.ReadLine();
            ReaderWorld.Close();

            string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld;
            if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
            {
                string WorldExist = PathToWorld + @"\CreateBlocks";
                if (File.Exists(WorldExist))
                {
                    string stroka;
                    int x = 0;
                    int y = 0;
                    int IdBlock = 0;
                    int count = 0;
                    int ChestVariable = 0;
                    int FurnaceVariable = 0;
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
                            count++;
                            continue;
                        }
                        else if (count == 2)
                        {
                            IdBlock = int.Parse(stroka);
                            count++;
                            continue;
                        }
                        else if (count == 3)
                        {
                            Trigger = int.Parse(stroka);
                            count++;
                            continue;
                        }
                        else if(count == 4)
                        {
                            ChestVariable = int.Parse(stroka);
                            count++;
                            continue;
                        }
                        else if(count == 5)
                        {
                            FurnaceVariable = int.Parse(stroka);
                            count = 0;
                        }
                        Vector3 New_Position = new Vector3(x, y);
                        if (IdBlock == 40) New_Position = new Vector3(x, y, -3);
                        GameObject gameObjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[IdBlock], transform.position + New_Position, Quaternion.identity);
                        if (Trigger == 0) gameObjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
                        gameObjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[IdBlock].name;
                        gameObjectNew.transform.SetParent(gameObject.transform);
                        gameObjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_2";
                        gameObjectNew.GetComponent<Block_information>().ChestVariable = ChestVariable;
                        gameObjectNew.GetComponent<Block_information>().FurnaceVariable = FurnaceVariable;
                    }
                    GenerationWorld.Close();
                }
                StartCoroutine("RecordBlocks");
            }
            else if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
            {
                string WorldExist = PathToWorld + @"\CreateBlocks_Cave";
                if (File.Exists(WorldExist))
                {
                    string stroka;
                    int x = 0;
                    int y = 0;
                    int IdBlock = 0;
                    int count = 0;
                    int ChestVariable = 0;
                    int FurnaceVariable = 0;
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
                            count++;
                            continue;
                        }
                        else if (count == 2)
                        {
                            IdBlock = int.Parse(stroka);
                            count++;
                            continue;
                        }
                        else if (count == 3)
                        {
                            Trigger = int.Parse(stroka);
                            count++;
                            continue;
                        }
                        else if (count == 4)
                        {
                            ChestVariable = int.Parse(stroka);
                            count++;
                            continue;
                        }
                        else if (count == 5)
                        {
                            FurnaceVariable = int.Parse(stroka);
                            count = 0;
                        }
                        Vector3 New_Position = new Vector3(x, y);
                        GameObject gameObjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[IdBlock], transform.position + New_Position, Quaternion.identity);
                        if (Trigger == 0) gameObjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
                        gameObjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[IdBlock].name;
                        gameObjectNew.transform.SetParent(gameObject.transform);
                        gameObjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_2";
                        gameObjectNew.GetComponent<Block_information>().ChestVariable = ChestVariable;
                        gameObjectNew.GetComponent<Block_information>().FurnaceVariable = FurnaceVariable;
                    }
                    GenerationWorld.Close();
                }
                StartCoroutine("RecordBlocks");
            }
        }
        else
        {
            StartCoroutine("CheckDeletedObjects_");
        }
    }

    IEnumerator RecordBlocks()

    {
            yield return new WaitForSeconds(60);
            RecordBlocks_();
    }

    public void RecordBlocks_()
    {
        string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
        string NameWorld;

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();

        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
        {
            string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CreateBlocks";

            StreamWriter GenerationWorld = new StreamWriter(PathToWorld, false);
            foreach (Transform children in gameObject.GetComponentInChildren<Transform>())
            {
                coordinate_x = children.position.x;
                coordinate_y = children.position.y;
                if (children.gameObject.GetComponent<BoxCollider2D>().isTrigger == true)
                {
                    TriggerOrNot = 1;
                }
                else
                {
                    TriggerOrNot = 0;
                }
                GenerationWorld.WriteLine(coordinate_x);
                GenerationWorld.WriteLine(coordinate_y);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().id);
                GenerationWorld.WriteLine(TriggerOrNot);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().ChestVariable);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().FurnaceVariable);
            }
            GenerationWorld.Close();
            StartCoroutine("RecordBlocks");
        }
        else if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
        {
            string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CreateBlocks_Cave";

            StreamWriter GenerationWorld = new StreamWriter(PathToWorld, false);
            foreach (Transform children in gameObject.GetComponentInChildren<Transform>())
            {
                coordinate_x = children.position.x;
                coordinate_y = children.position.y;
                if (children.gameObject.GetComponent<BoxCollider2D>().isTrigger == true)
                {
                    TriggerOrNot = 1;
                }
                else
                {
                    TriggerOrNot = 0;
                }
                GenerationWorld.WriteLine(coordinate_x);
                GenerationWorld.WriteLine(coordinate_y);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().id);
                GenerationWorld.WriteLine(TriggerOrNot);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().ChestVariable);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().FurnaceVariable);
            }
            GenerationWorld.Close();
            StartCoroutine("RecordBlocks");
        }
    }
}
