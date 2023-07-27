using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CavePoint : Collectable
{
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;

    private float coordinate_x = 0;
    private float coordinate_y = 0;
    int TriggerOrNot = 0;

    public GameObject Text;

    public int BossTrue = 0;
    //Это скрипт точки входа в пещеру
    protected override void OnCollide(Collider2D Coll)
    {
        if (Coll.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
                {
                    if (BossTrue == 0)
                    {
                        LoadSceneCave();
                    }
                    else
                    {
                        LoadSceneBossCave();
                    }
                    Text.SetActive(false);
                }
                if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
                {
                    LoadSceneWorlds2D();
                    Text.SetActive(false);
                }
                if(SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Boss" && GameObject.Find("BigZombie(Clone)") == false)
                {
                    SaveGameStats();
                    SceneManager.LoadScene("GameEnd");
                    Text.SetActive(false);
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Text.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Text.SetActive(true);
        }
    }
    public void LoadSceneCave()
    {
        SaveGameStats();
        SceneManager.LoadScene("Minecraft_Worlds2D_Cave");
    }

    public void LoadSceneBossCave()
    {
        SaveGameStats();
        SceneManager.LoadScene("Minecraft_Worlds2D_Boss");
    }

    public void LoadSceneWorlds2D()
    {
        SaveGameStats();
        SceneManager.LoadScene("Minecraft_Worlds2D");
    }

    public void SaveGameStats()
    {
        GameObject.Find("Inventory_massive").GetComponent<Inventory>().SaveInventoryToFile();
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();

        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
        {
            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats";

            StreamWriter GameStats = new StreamWriter(Folder, false);
            GameStats.WriteLine(GameObject.Find("Player").transform.position.x);
            GameStats.WriteLine(GameObject.Find("Player").transform.position.y);
            GameStats.WriteLine(GameObject.Find("Point Light").transform.position.z);
            foreach (Transform child in GameObject.Find("ChunkLoader").GetComponentInChildren<Transform>())
            {
                GameStats.WriteLine(child.position.x);
                GameStats.WriteLine(child.position.y);
            }
            GameStats.Close();

            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Player";
            StreamWriter GameStatsPlayer = new StreamWriter(Folder, false);
            GameStatsPlayer.WriteLine(GameObject.Find("Player").GetComponent<Player>().health); //здоровье записать нужно
            GameStatsPlayer.Close();

            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Cave";

            StreamWriter GameStats_ = new StreamWriter(Folder, false);
            GameStats_.WriteLine(GameObject.Find("Point Light").transform.position.z);
            GameStats_.Close();

            string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CreateBlocks";

            StreamWriter GenerationWorld = new StreamWriter(PathToWorld, false);
            foreach (Transform children in GameObject.Find("BuildCreatedBlocks").GetComponentInChildren<Transform>())
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
        }
        else if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave" || SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Boss")
        {
            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Player";
            StreamWriter GameStatsPlayer = new StreamWriter(Folder, false);
            GameStatsPlayer.WriteLine(GameObject.Find("Player").GetComponent<Player>().health); //здоровье записать нужно
            GameStatsPlayer.Close();

            if (SceneManager.GetActiveScene().name != "Minecraft_Worlds2D_Boss")
            {
                Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Cave";
                StreamWriter GameStats = new StreamWriter(Folder, false);
                GameStats.WriteLine(GameObject.Find("GameObjectPoint").transform.position.z);
                GameStats.Close();
            }

            string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CreateBlocks_Cave";

            if (SceneManager.GetActiveScene().name != "Minecraft_Worlds2D_Boss")
            {
                StreamWriter GenerationWorld = new StreamWriter(PathToWorld, false);
                foreach (Transform children in GameObject.Find("BuildCreatedBlocks").GetComponentInChildren<Transform>())
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
            }
        }
    }
}
