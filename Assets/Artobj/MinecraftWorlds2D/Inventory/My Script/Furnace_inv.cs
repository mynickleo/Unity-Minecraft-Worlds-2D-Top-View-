using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Furnace_inv : MonoBehaviour
{
    public Item[] ItemsInventory = new Item[3];

    public DataBaseImages DataBase;

    public Sprite FurnaceFire;
    public Sprite FurnaceNotFire;

    public CraftRecipeForFurnace CraftRecipe;

    //Переменные необходимые для загрузки из файла//
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;
    int some_action = 0;

    public int CoalDelete = 0;
    //////////////////////////////////////////////////

    public void Start()
    {
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\" + gameObject.GetComponent<Block_information>().FurnaceVariable + @"Furnace";
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
        StartCoroutine("UpdateFurnaceCraftRecipe");
    }

    //Я решил засунуть не в Update, а в корутину, чтобы не было овер много апдейтов
    IEnumerator UpdateFurnaceCraftRecipe()
    {
        yield return new WaitForSeconds(1);
        CraftRecipe.Craft(ItemsInventory);
        StartCoroutine("UpdateFurnaceCraftRecipe");
    }

    public void FurnaceFire_()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = FurnaceFire;
    }

    public void FurnaceNotFire_()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = FurnaceNotFire;
    }

    public void CraftCreateItem(Item ItemCreate)
    {
        CoalDelete++;
        if (ItemsInventory[2] == null)
        {
            GameObject NewItem = Instantiate(ItemCreate.gameObject, gameObject.transform.position, Quaternion.identity);
            NewItem.transform.SetParent(gameObject.transform);
            NewItem.GetComponent<Item>().amount = 1;
            NewItem.GetComponent<Item>().Amount_Text.text = Convert.ToString(NewItem.GetComponent<Item>().amount);
            NewItem.GetComponent<Item>().Amount_Text.gameObject.SetActive(false);
            NewItem.GetComponent<Item>().name = "Item_active";
            NewItem.SetActive(false);
            ItemsInventory[2] = NewItem.GetComponent<Item>();

            ItemsInventory[0].amount--;
            if (ItemsInventory[0].amount < 1)
            {
                Destroy(ItemsInventory[0].gameObject);
                ItemsInventory[0] = null;
            }
            else
            {
                ItemsInventory[0].Amount_Text.text = Convert.ToString(ItemsInventory[0].amount);
            }

            if (CoalDelete > 3)
            {
                ItemsInventory[1].amount--;
                if (ItemsInventory[1].amount < 1)
                {
                    Destroy(ItemsInventory[1].gameObject);
                    ItemsInventory[1] = null;
                }
                else
                {
                    ItemsInventory[1].Amount_Text.text = Convert.ToString(ItemsInventory[1].amount);
                }
                CoalDelete = 0;
            }
            SaveInventoryToFile();

            //Если объект включен, релодим, чтобы было отображение
            if (GameObject.Find("Furnace_Inventory") == true)
            {
                GameObject.Find("InventoryGameAndFurnace").GetComponent<Inventory_Furnace>().SaveGameInventory();
                GameObject.Find("InventoryGameAndFurnace").GetComponent<Inventory_Furnace>().LoadAllInventory();
                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().ReLoad();
            }
        }
        else if (ItemsInventory[2].amount < 64)
        {
            if (ItemsInventory[2].id == ItemCreate.id)
            {
                ItemsInventory[2].amount++;
                ItemsInventory[2].Amount_Text.text = Convert.ToString(ItemsInventory[2].amount);

                ItemsInventory[0].amount--;
                if (ItemsInventory[0].amount < 1)
                {
                    Destroy(ItemsInventory[0].gameObject);
                    ItemsInventory[0] = null;
                }
                else
                {
                    ItemsInventory[0].Amount_Text.text = Convert.ToString(ItemsInventory[0].amount);
                }

                if (CoalDelete > 3)
                {
                    ItemsInventory[1].amount--;
                    if (ItemsInventory[1].amount < 1)
                    {
                        Destroy(ItemsInventory[1].gameObject);
                        ItemsInventory[1] = null;
                    }
                    else
                    {
                        ItemsInventory[1].Amount_Text.text = Convert.ToString(ItemsInventory[1].amount);
                    }
                    CoalDelete = 0;
                }
                SaveInventoryToFile();

                //Если объект включен, релодим, чтобы было отображение
                if (GameObject.Find("Furnace_Inventory") == true)
                {
                    GameObject.Find("InventoryGameAndFurnace").GetComponent<Inventory_Furnace>().SaveGameInventory();
                    GameObject.Find("InventoryGameAndFurnace").GetComponent<Inventory_Furnace>().LoadAllInventory();
                    GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().ReLoad();
                }
            }
        }

    }

    public void LoadAllInventory()
    {
        for (int i = 0; i < ItemsInventory.Length; i++)
        {
            ItemsInventory[i] = null;
        }
        foreach (Transform child in gameObject.transform)
        {
            if (child.name != "Furnace_delete")
            {
                Destroy(child.gameObject);
            }
        }

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\" + gameObject.GetComponent<Block_information>().FurnaceVariable + @"Furnace";
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
    }

    public void SaveInventoryToFile()
    {
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\" + gameObject.GetComponent<Block_information>().FurnaceVariable + @"Furnace";
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
