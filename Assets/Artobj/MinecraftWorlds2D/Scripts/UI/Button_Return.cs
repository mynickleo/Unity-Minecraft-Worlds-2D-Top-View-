using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_Return : MonoBehaviour
{
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;

    private float coordinate_x = 0;
    private float coordinate_y = 0;
    int TriggerOrNot = 0;
    public void ReturnToGame()
    {
        GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().ReturnToGame();
    }

    public void OnClickExitandSaveGame()
    {
        GameObject.Find("Inventory_massive").GetComponent<Inventory>().SaveInventoryToFile();
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats";

        StreamWriter GameStats = new StreamWriter(Folder, false);
        GameStats.WriteLine(GameObject.Find("Player").transform.position.x);
        GameStats.WriteLine(GameObject.Find("Player").transform.position.y);
        if (SceneManager.GetActiveScene().name != "Minecraft_Worlds2D_Boss") GameStats.WriteLine(GameObject.Find("Point Light").transform.position.z);
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

        if (SceneManager.GetActiveScene().name != "Minecraft_Worlds2D_Boss")
        {
            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Cave";
            StreamWriter GameStats_ = new StreamWriter(Folder, false);
            GameStats_.WriteLine(GameObject.Find("Point Light").transform.position.z);
            GameStats_.Close();
        }

        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
        {
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
        for (int i = 0; i < 10; i++) ; // Задержка для проигрывания музыки
        GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().ReturnToGame();
        Application.Quit();
    }

    public void SaveGameOptions()
    {
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\GameOptionsSave";
        StreamWriter SaveStats = new StreamWriter(Folder, false);
        SaveStats.WriteLine(GameObject.Find("Scrollbar_Music").GetComponent<Scrollbar>().value);
        SaveStats.WriteLine(GameObject.Find("Scrollbar_FarDistance").GetComponent<Scrollbar>().value);
        SaveStats.Close();
    }
}
