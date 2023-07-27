using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Chest : MonoBehaviour
{
    public Item[] ItemsInventory = new Item[27];

    public DataBaseImages DataBase;

    //Переменные необходимые для загрузки из файла//
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;
    int some_action = 0;
    //////////////////////////////////////////////////

    public void Start()
    {
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\" + gameObject.GetComponent<Block_information>().ChestVariable + @"Chest";
        if (File.Exists(Folder))
        {
            string stroka = "";
            int id_inv = 0;
            string name_inv; //Имя объекта
            string description_inv; //описание объекта
            int amount_inv;
            int i_variable = 0;
            double endurance_inv = 100;
            int j = 0;

            string some_variable_check_null = "nenull";
            StreamReader OpenInventory = new StreamReader(Folder, false);
            while (!OpenInventory.EndOfStream)
            {
                if (i_variable == 0)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        id_inv = Convert.ToInt32(some_variable_check_null);
                        GameObject gameObjectNew = Instantiate(DataBase.DataBaseAllImages[id_inv].gameObject, gameObject.transform.position, Quaternion.identity);
                        gameObjectNew.transform.SetParent(gameObject.transform);
                        ItemsInventory[j] = gameObjectNew.GetComponent<Item>();
                        gameObjectNew.SetActive(false);

                        ItemsInventory[j].id = id_inv;
                    }
                    i_variable++;
                }
                else if (i_variable == 1)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        name_inv = some_variable_check_null;
                        ItemsInventory[j].name = name_inv;
                    }
                    i_variable++;
                }
                else if (i_variable == 2)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        description_inv = some_variable_check_null;
                        ItemsInventory[j].description = description_inv;
                    }
                    i_variable++;
                }
                else if (i_variable == 3)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        amount_inv = Convert.ToInt32(some_variable_check_null);
                        ItemsInventory[j].amount = amount_inv;
                    }
                    i_variable = 4;
                    some_variable_check_null = "nenull";
                }
                else if (i_variable == 4)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        endurance_inv = Convert.ToInt32(some_variable_check_null);
                        ItemsInventory[j].endurance = endurance_inv;
                    }
                    i_variable = 0;
                    some_variable_check_null = "nenull";
                    j++;
                }
            }
            OpenInventory.Close();
        }
        SaveInventoryToFile();
    }

    public void LoadAllInventory()
    {
        for (int i = 0; i < ItemsInventory.Length; i++)
        {
            ItemsInventory[i] = null;
        }
        foreach (Transform child in gameObject.transform)
        {
            if (child.name != "Chest_delete")
            {
                Destroy(child.gameObject);
            }
        }

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\" + gameObject.GetComponent<Block_information>().ChestVariable + @"Chest";
        if (File.Exists(Folder))
        {
            string stroka = "";
            int id_inv = 0;
            string name_inv; //Имя объекта
            string description_inv; //описание объекта
            int amount_inv;
            double endurance_inv = 100;
            int i_variable = 0;
            int j = 0;

            string some_variable_check_null = "nenull";
            StreamReader OpenInventory = new StreamReader(Folder, false);
            while (!OpenInventory.EndOfStream)
            {
                if (i_variable == 0)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        id_inv = Convert.ToInt32(some_variable_check_null);
                        GameObject gameObjectNew = Instantiate(DataBase.DataBaseAllImages[id_inv].gameObject, gameObject.transform.position, Quaternion.identity);
                        gameObjectNew.transform.SetParent(gameObject.transform);
                        ItemsInventory[j] = gameObjectNew.GetComponent<Item>();
                        gameObjectNew.SetActive(false);

                        ItemsInventory[j].id = id_inv;
                    }
                    i_variable++;
                }
                else if (i_variable == 1)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        name_inv = some_variable_check_null;
                        ItemsInventory[j].name = name_inv;
                    }
                    i_variable++;
                }
                else if (i_variable == 2)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        description_inv = some_variable_check_null;
                        ItemsInventory[j].description = description_inv;
                    }
                    i_variable++;
                }
                else if (i_variable == 3)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        amount_inv = Convert.ToInt32(some_variable_check_null);
                        ItemsInventory[j].amount = amount_inv;
                    }
                    i_variable = 4;
                    some_variable_check_null = "nenull";
                }
                else if(i_variable == 4)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        endurance_inv = Convert.ToInt32(some_variable_check_null);
                        ItemsInventory[j].endurance = endurance_inv;
                    }
                    i_variable = 0;
                    some_variable_check_null = "nenull";
                    j++;
                }
            }
            OpenInventory.Close();
        }
    }

    public void SaveInventoryToFile()
    {
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\" + gameObject.GetComponent<Block_information>().ChestVariable + @"Chest";
        StreamWriter SaveInv = new StreamWriter(Folder, false);
        for (int i = 0; i < ItemsInventory.Length; i++)
        {
            if (ItemsInventory[i] != null)
            {
                SaveInv.WriteLine(ItemsInventory[i].id);
                SaveInv.WriteLine(ItemsInventory[i].name);
                SaveInv.WriteLine(ItemsInventory[i].description);
                SaveInv.WriteLine(ItemsInventory[i].amount);
                SaveInv.WriteLine(ItemsInventory[i].endurance);
            }
            else
            {
                SaveInv.WriteLine("null");
                SaveInv.WriteLine("null");
                SaveInv.WriteLine("null");
                SaveInv.WriteLine("null");
                SaveInv.WriteLine("null");
            }
        }
        SaveInv.Close();
    }
}
