using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] ItemsInventory = new Item[46];

    public Inventory_vis Inventory_Visible;

    public DataBaseImages DataBase;

    public CellScript_ HotBar;

    public Text Amount_Text__;

    //Переменные необходимые для загрузки из файла//
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;
    int some_action = 0;
    //////////////////////////////////////////////////
    ///

    //element 26-36 -> "Fast Inventory" = hotbar

    public void Start()
    {
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\Inventory";
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
                if(i_variable == 0)
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
                else if(i_variable == 1){
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        name_inv = some_variable_check_null;
                        ItemsInventory[j].name = name_inv;
                    }
                    i_variable++;
                }
                else if(i_variable == 2)
                {
                    some_variable_check_null = OpenInventory.ReadLine();
                    if (some_variable_check_null != "null")
                    {
                        description_inv = some_variable_check_null;
                        ItemsInventory[j].description = description_inv;
                    }
                    i_variable++;
                }
                else if(i_variable == 3)
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
        StartCoroutine("SaveInventory");
    }

    IEnumerator SaveInventory()
    {
        yield return new WaitForSeconds(60);
        SaveInventoryToFile();
        StartCoroutine("SaveInventory");
    }

    public void LoadAllInventory()
    {
        for (int i = 0; i < ItemsInventory.Length; i++)
        {
            ItemsInventory[i] = null;
        }
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\Inventory";
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
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\Inventory";
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

    //Function Put in Inventory some item
    public void PutInInventory(Item NewItem)
    {
        int Put_Or_Not = 0;

        int Inventory_variable = 0;

        for (int i = 0; i < ItemsInventory.Length; i++)
        {
            if (ItemsInventory[i] != null && ItemsInventory[i].amount < 64 && i < 36)
            {
                if (ItemsInventory[i].id == NewItem.id)
                {
                    ItemsInventory[i].amount += NewItem.amount;
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                    Inventory_variable = 1;
                }
            }
            if(Put_Or_Not == 1)
            {
                break;
            }
        }
        if(Inventory_variable == 0)
        {
            for(int i = 0; i < ItemsInventory.Length; i++)
            {
                if(ItemsInventory[27] == null)
                {
                    ItemsInventory[27] = NewItem;
                    ItemsInventory[27].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[28] == null)
                {
                    ItemsInventory[28] = NewItem;
                    ItemsInventory[28].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[29] == null)
                {
                    ItemsInventory[29] = NewItem;
                    ItemsInventory[29].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[30] == null)
                {
                    ItemsInventory[30] = NewItem;
                    ItemsInventory[30].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[31] == null)
                {
                    ItemsInventory[31] = NewItem;
                    ItemsInventory[31].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[32] == null)
                {
                    ItemsInventory[32] = NewItem;
                    ItemsInventory[32].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[33] == null)
                {
                    ItemsInventory[33] = NewItem;
                    ItemsInventory[33].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[34] == null)
                {
                    ItemsInventory[34] = NewItem;
                    ItemsInventory[34].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[35] == null)
                {
                    ItemsInventory[35] = NewItem;
                    ItemsInventory[35].name = "";
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                }
                else if (ItemsInventory[i] == null && i != 40)
                {
                    ItemsInventory[i] = NewItem;
                    ItemsInventory[i].name = "";

                    Put_Or_Not = 1;
                }
                if (Put_Or_Not == 1)
                {
                    break;
                }
            }
        }
    }

    //Реализация правой кнопки мыши для инвентаря
    public void CreateNewImageInventory(int index, Item NewItem)
    {
        //Если я кладу в пустую ячейку
        if (ItemsInventory[index] == null)
        {
            ItemsInventory[index] = NewItem;
        }
        else
        {
            if (ItemsInventory[index].id == NewItem.id)
            {
                if (ItemsInventory[index].amount < 64)
                {
                    ItemsInventory[index].amount++;
                }
            }
        }
    }

    //Function Swap 2 Element Inventory
    public void SwapElementInventory(int index_1, int index_2)
    {
        if (index_1 != index_2)
        {
            if (ItemsInventory[index_2] != null)
            {
                if (ItemsInventory[index_1].id == ItemsInventory[index_2].id && ((ItemsInventory[index_1].id < 22 && ItemsInventory[index_2].id < 22) || (ItemsInventory[index_1].id > 36 || ItemsInventory[index_2].id > 36)))
                {
                    while (ItemsInventory[index_2].amount < 64)
                    {
                        if (ItemsInventory[index_1].amount > 0)
                        {
                            ItemsInventory[index_2].amount++;
                            Inventory_Visible.MassiveCell[index_2].ChildrenInventory.GetComponent<Item>().amount = ItemsInventory[index_2].amount;
                            ItemsInventory[index_1].amount--;
                            Inventory_Visible.MassiveCell[index_1].ChildrenInventory.GetComponent<Item>().amount = ItemsInventory[index_1].amount;
                        }
                        else
                        {
                            ItemsInventory[index_1] = null;
                            Inventory_Visible.DeleteImage(index_1);
                            break;
                        }
                    }
                    //Т.е. я помещаю индекс предмета, куда складывали, и его новое кол-во
                    Inventory_Visible.SetMassiveCell(index_2);

                    if(ItemsInventory[index_1] != null)
                    {
                        Inventory_Visible.SwapImageIndex(index_1, index_2);
                    }
                }
                else
                {
                    if (index_1 != 40 && Inventory_Visible.gameObject.name == "Full_Inventory")
                    {
                        Item TemporaryElement = ItemsInventory[index_1];
                        ItemsInventory[index_1] = ItemsInventory[index_2];
                        ItemsInventory[index_2] = TemporaryElement;

                        Inventory_Visible.SwapImageIndex(index_1, index_2);
                    }
                    else if(index_1 != 45 && Inventory_Visible.gameObject.name == "Worckbench_Inventory")
                    {
                        Item TemporaryElement = ItemsInventory[index_1];
                        ItemsInventory[index_1] = ItemsInventory[index_2];
                        ItemsInventory[index_2] = TemporaryElement;

                        Inventory_Visible.SwapImageIndex(index_1, index_2);
                    }
                    else
                    {
                        /*Item TemporaryElement = ItemsInventory[index_1];
                        ItemsInventory[index_1] = ItemsInventory[index_2];
                        for(int i = 0; i < ItemsInventory.Length; i++)
                        {
                            if (ItemsInventory[i] == null)
                            {
                                ItemsInventory[index_2] = TemporaryElement;
                                TemporaryElement = null;
                                break;
                            }
                            else if (i == ItemsInventory.Length-1 && TemporaryElement != null)
                            {
                                //Здесь необходимо реализовать функцию выброса лишнего элемента, пока буду дестроить
                                Destroy(ItemsInventory[index_2]);
                                Inventory_Visible.DeleteImage(index_2);
                            }
                        }*/
                        int variable_swap = 0;
                        for (int i = 0; i < ItemsInventory.Length; i++)
                        {
                            if (i == 40 && Inventory_Visible.gameObject.name == "Full_Inventory")
                            {

                            }
                            if(i == 45 && Inventory_Visible.gameObject.name == "Worckbench_Inventory")
                            {

                            }
                            else if (ItemsInventory[i] == null)
                            {
                                Inventory_Visible.SwapImageIndex40_45(index_1, index_2, i);

                                Item TemporaryElement = ItemsInventory[index_2];
                                ItemsInventory[index_2] = ItemsInventory[index_1];
                                ItemsInventory[i] = TemporaryElement;
                                ItemsInventory[index_1] = null;

                                Inventory_Visible.CraftCreateVariable = 0;

                                variable_swap = 1;
                            }

                            if (variable_swap == 1) break;
                        }
                    }
                }
            }
            else if (ItemsInventory[index_2] == null)
            {
                Inventory_Visible.ChangeImageChildren(index_1, index_2);
                if(index_1 == 40 && Inventory_Visible.gameObject.name == "Full_Inventory")
                {
                    Inventory_Visible.MassiveCell[index_1].ChildrenInventory = null;
                }
                else if(index_1 == 45 && Inventory_Visible.gameObject.name == "Worckbench_Inventory")
                {
                    Inventory_Visible.MassiveCell[index_1].ChildrenInventory = null;
                }
                ItemsInventory[index_2] = ItemsInventory[index_1];
                ItemsInventory[index_1] = null;
            }
        }
        else
        {
            Inventory_Visible.MassiveCell[index_1].ChildrenInventory.transform.position = Inventory_Visible.MassiveCell[index_1].gameObject.transform.position;
        }
    }
}
