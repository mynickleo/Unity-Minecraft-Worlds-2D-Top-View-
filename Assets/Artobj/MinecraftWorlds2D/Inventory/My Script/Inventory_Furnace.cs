using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Inventory_Furnace : MonoBehaviour
{
    public Item[] ItemsInventory = new Item[39];

    public Inventory_visible_for_furnace Inventory_Visible;

    public DataBaseImages DataBase;

    public GameObject InventoryGame;
    public GameObject InventoryFurnace;

    public CellScript_ HotBar;

    public Text Amount_Text__;

    //Переменные необходимые для загрузки из файла//
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;
    int some_action = 0;
    //////////////////////////////////////////////////
    ///

    public void LoadAllInventory()
    {
        for (int i = 0; i < 36; i++)
        {
            ItemsInventory[i] = InventoryGame.GetComponent<Inventory>().ItemsInventory[i];
        }
        int j = 0;
        for (int i = 36; i < 39; i++)
        {
            ItemsInventory[i] = InventoryFurnace.GetComponent<Furnace_inv>().ItemsInventory[j];
            j++;
        }
    }

    public void SaveGameInventory()
    {
        for (int i = 0; i < 36; i++)
        {
            InventoryGame.GetComponent<Inventory>().ItemsInventory[i] = ItemsInventory[i];
        }
        InventoryGame.GetComponent<Inventory>().SaveInventoryToFile();
        InventoryGame.GetComponent<Inventory>().LoadAllInventory();
    }
    public void SaveInventoryToFile()
    {
        int j = 0;
        for (int i = 36; i < 39; i++)
        {
            InventoryFurnace.GetComponent<Furnace_inv>().ItemsInventory[j] = ItemsInventory[i];
            j++;
        }
        for (int i = 0; i < 36; i++)
        {
            InventoryGame.GetComponent<Inventory>().ItemsInventory[i] = ItemsInventory[i];
        }
        InventoryFurnace.GetComponent<Furnace_inv>().SaveInventoryToFile();
        InventoryFurnace.GetComponent<Furnace_inv>().LoadAllInventory();
        InventoryGame.GetComponent<Inventory>().SaveInventoryToFile();
        InventoryGame.GetComponent<Inventory>().LoadAllInventory();
    }

    public void UpdateFurnaceInventory()
    {
        int j = 0;
        for (int i = 36; i < 39; i++)
        {
            InventoryFurnace.GetComponent<Furnace_inv>().ItemsInventory[j] = ItemsInventory[i];
            j++;
        }
    }

    //Function Put in Inventory some item
    public void PutInInventory(Item NewItem)
    {
        int Put_Or_Not = 0;

        int Inventory_variable = 0;

        for (int i = 0; i < ItemsInventory.Length; i++)
        {
            if (ItemsInventory[i] != null && ItemsInventory[i].amount < 64)
            {
                if (ItemsInventory[i].id == NewItem.id)
                {
                    ItemsInventory[i].amount += NewItem.amount;
                    HotBar.UpdateCellsHotbar();
                    Put_Or_Not = 1;
                    Inventory_variable = 1;
                }
            }
            if (Put_Or_Not == 1)
            {
                break;
            }
        }
        if (Inventory_variable == 0)
        {
            for (int i = 0; i < ItemsInventory.Length; i++)
            {
                if (ItemsInventory[27] == null)
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
                else if (ItemsInventory[i] == null)
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

                    if (ItemsInventory[index_1] != null)
                    {
                        Inventory_Visible.SwapImageIndex(index_1, index_2);
                    }
                }
                else
                {
                    Item TemporaryElement = ItemsInventory[index_1];
                    ItemsInventory[index_1] = ItemsInventory[index_2];
                    ItemsInventory[index_2] = TemporaryElement;

                    Inventory_Visible.SwapImageIndex(index_1, index_2);
                }
            }
            else if (ItemsInventory[index_2] == null)
            {
                Inventory_Visible.ChangeImageChildren(index_1, index_2);
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
