using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_visible_for_furnace : MonoBehaviour
{
    //Это визуальные инвентарь
    public Inventory_Furnace InventoryGameObj;

    public DataBaseImages DataBase;

    public GameObject FurnaceFire;

    public Item[] MassiveCell = new Item[39];

    public Item[] MassiveCraftFurnace = new Item[3];

    int variable_for_action = 0;

    int id_block1_to_swap = 0;
    int id_block2_to_swap = 0;

    int CoalDelete = 0;

    public int CraftCreateVariable = 0;


    private Vector3 MousePosition;

    public void OnEnable()
    {
        //Function Fill Cell Massive
        for (int i = 0; i < MassiveCell.Length; i++)
        {
            if (InventoryGameObj.ItemsInventory[i] != null && InventoryGameObj.ItemsInventory[i].amount != 0)
            {
                GameObject NewItem = Instantiate(InventoryGameObj.ItemsInventory[i].gameObject, MassiveCell[i].gameObject.transform.position, Quaternion.identity);
                NewItem.transform.SetParent(gameObject.transform);
                NewItem.GetComponent<Item>().Amount_Text.text = Convert.ToString(InventoryGameObj.ItemsInventory[i].amount);
                NewItem.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
                NewItem.GetComponent<Item>().name = "Item_active";
                NewItem.SetActive(true);
                MassiveCell[i].ChildrenInventory = NewItem;
            }
        }
    }

    public void EnableFire()
    {
        FurnaceFire.SetActive(true);
    }

    public void DisableFire()
    {
        FurnaceFire.SetActive(false);
    }
    public void ReLoad()
    {
        for(int i = 0; i < MassiveCell.Length; i++)
        {
            Destroy(MassiveCell[i].ChildrenInventory);
            MassiveCell[i].ChildrenInventory = null;
        }

        //Function Fill Cell Massive
        for (int i = 0; i < MassiveCell.Length; i++)
        {
            if (InventoryGameObj.ItemsInventory[i] != null && InventoryGameObj.ItemsInventory[i].amount != 0)
            {
                GameObject NewItem = Instantiate(InventoryGameObj.ItemsInventory[i].gameObject, MassiveCell[i].gameObject.transform.position, Quaternion.identity);
                NewItem.transform.SetParent(gameObject.transform);
                NewItem.GetComponent<Item>().Amount_Text.text = Convert.ToString(InventoryGameObj.ItemsInventory[i].amount);
                NewItem.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
                NewItem.GetComponent<Item>().name = "Item_active";
                NewItem.SetActive(true);
                MassiveCell[i].ChildrenInventory = NewItem;
            }
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < MassiveCell.Length; i++)
            {
                if (variable_for_action == 0)
                {
                    MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (Mathf.Abs(MassiveCell[i].gameObject.transform.position.x - MousePosition.x) < 0.4 && Mathf.Abs(MassiveCell[i].gameObject.transform.position.y - MousePosition.y) < 0.4)
                    {
                        if (MassiveCell[i].ChildrenInventory.GetComponent<Item>().variable_for_action != 2)
                        {
                            MassiveCell[i].ChildrenInventory.GetComponent<Item>().variable_for_action = 1;
                        }
                        variable_for_action = 1;
                        id_block1_to_swap = i;
                    }
                }
                else if (variable_for_action == 1)
                {
                    MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (Mathf.Abs(MassiveCell[i].gameObject.transform.position.x - MousePosition.x) < 0.4 && Mathf.Abs(MassiveCell[i].gameObject.transform.position.y - MousePosition.y) < 0.4 && variable_for_action == 1 && MassiveCell[i].name != "CraftCell")
                    {
                        MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().variable_for_action = 0;
                        id_block2_to_swap = i;
                        InventoryGameObj.SwapElementInventory(id_block1_to_swap, id_block2_to_swap);

                        variable_for_action = 0;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && variable_for_action == 1)
        {
            for (int i = 0; i < MassiveCell.Length; i++)
            {
                MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Mathf.Abs(MassiveCell[i].gameObject.transform.position.x - MousePosition.x) < 0.4 && Mathf.Abs(MassiveCell[i].gameObject.transform.position.y - MousePosition.y) < 0.4 && MassiveCell[i].name != "CraftCell")
                {
                    if (MassiveCell[i].ChildrenInventory == null)
                    {
                        GameObject NewItemInventory = Instantiate(MassiveCell[id_block1_to_swap].ChildrenInventory, MassiveCell[i].gameObject.transform.position, Quaternion.identity);
                        NewItemInventory.transform.SetParent(gameObject.transform);
                        NewItemInventory.GetComponent<Item>().variable_for_action = 0;
                        MassiveCell[i].ChildrenInventory = NewItemInventory;

                        NewItemInventory.GetComponent<Item>().amount = 1;
                        MassiveCell[i].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[i].ChildrenInventory.GetComponent<Item>().amount);

                        InventoryGameObj.ItemsInventory[id_block1_to_swap].amount--;
                        MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().amount = InventoryGameObj.ItemsInventory[id_block1_to_swap].amount;
                        MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(InventoryGameObj.ItemsInventory[id_block1_to_swap].GetComponent<Item>().amount);

                        if (MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().amount < 1)
                        {
                            Destroy(MassiveCell[id_block1_to_swap].ChildrenInventory);
                            variable_for_action = 0;
                            MassiveCell[id_block1_to_swap].ChildrenInventory = null;
                            InventoryGameObj.ItemsInventory[id_block1_to_swap] = null;
                        }
                        InventoryGameObj.CreateNewImageInventory(i, NewItemInventory.GetComponent<Item>());
                    }
                    else if (MassiveCell[i].ChildrenInventory.GetComponent<Item>().amount < 64)
                    {
                        if (i != id_block1_to_swap && (MassiveCell[i].ChildrenInventory.GetComponent<Item>().id == MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().id))
                        {
                            InventoryGameObj.ItemsInventory[id_block1_to_swap].amount--;
                            MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().amount = InventoryGameObj.ItemsInventory[id_block1_to_swap].amount;
                            MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(InventoryGameObj.ItemsInventory[id_block1_to_swap].GetComponent<Item>().amount);
                            if (MassiveCell[id_block1_to_swap].ChildrenInventory.GetComponent<Item>().amount < 1)
                            {
                                Destroy(MassiveCell[id_block1_to_swap].ChildrenInventory);
                                variable_for_action = 0;
                                MassiveCell[id_block1_to_swap].ChildrenInventory = null;
                                InventoryGameObj.ItemsInventory[id_block1_to_swap] = null;
                            }

                            InventoryGameObj.CreateNewImageInventory(i, MassiveCell[i].ChildrenInventory.GetComponent<Item>());

                            MassiveCell[i].ChildrenInventory.GetComponent<Item>().amount = InventoryGameObj.ItemsInventory[i].amount;
                            MassiveCell[i].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[i].ChildrenInventory.GetComponent<Item>().amount);

                        }
                    }
                }
            }
        }
        for (int i = 0; i < MassiveCell.Length; i++)
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Mathf.Abs(MassiveCell[i].gameObject.transform.position.x - MousePosition.x) < 0.45 && Mathf.Abs(MassiveCell[i].gameObject.transform.position.y - MousePosition.y) < 0.45)
            {
                MassiveCell[i].GetComponentInChildren<Image>().color = new Color(0.91f, 0.91f, 0.91f);
            }
            else
            {
                MassiveCell[i].GetComponentInChildren<Image>().color = new Color(0.5686275f, 0.5686275f, 0.5686275f);
            }
        }
        InventoryGameObj.UpdateFurnaceInventory();
    }
    public void SwapImageIndex(int index1, int index2)
    {
        GameObject Temporary = MassiveCell[index1].ChildrenInventory;
        MassiveCell[index1].ChildrenInventory = MassiveCell[index2].ChildrenInventory;
        MassiveCell[index2].ChildrenInventory = Temporary;

        MassiveCell[index1].ChildrenInventory.transform.position = MassiveCell[index1].gameObject.transform.position;
        MassiveCell[index2].ChildrenInventory.transform.position = MassiveCell[index2].gameObject.transform.position;

        MassiveCell[index1].ChildrenInventory.GetComponent<Item>().variable_for_action = 2;
        MassiveCell[index2].ChildrenInventory.GetComponent<Item>().variable_for_action = 2;
    }
    public void SetImageActiveGo(int index)
    {
        MassiveCell[index].ChildrenInventory.GetComponent<Item>().variable_for_action = 1;
    }

    public void ChangeImageChildren(int index1, int index2)
    {
        MassiveCell[index2].ChildrenInventory = MassiveCell[index1].ChildrenInventory;
        MassiveCell[index1].ChildrenInventory = null;

        MassiveCell[index2].ChildrenInventory.transform.position = MassiveCell[index2].gameObject.transform.position;
    }

    public void SetMassiveCell(int index)
    {
        //Т.е. я обновляю текст предмета, чтобы визуально отобразить его новое кол-во (будь-то это 32, 16 или стак = 64)
        MassiveCell[index].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(InventoryGameObj.ItemsInventory[index].GetComponent<Item>().amount);
        MassiveCell[index].ChildrenInventory.GetComponent<Item>().variable_for_action = 0;
    }
    public void DeleteImage(int index)
    {
        Destroy(MassiveCell[index].ChildrenInventory.gameObject);
    }

    public void OnDisableOne()
    {
        for (int i = 0; i < MassiveCell.Length; i++)
        {
            Destroy(MassiveCell[i].ChildrenInventory);
            MassiveCell[i].ChildrenInventory = null;
        }
        GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().ChangeInventoryVisibleFurnace();
        InventoryGameObj.SaveInventoryToFile();
        FurnaceFire.SetActive(false);
    }
}
