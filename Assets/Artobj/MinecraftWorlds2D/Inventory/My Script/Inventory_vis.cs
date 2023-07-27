using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_vis : MonoBehaviour
{
    //Это визуальные инвентарь
    public Inventory InventoryGameObj;

    public DataBaseImages DataBase;

    public CraftRecipe_ CraftRecipe;

    public Item[] MassiveCell = new Item[46];

    public Item[] MassiveCraft = new Item[4];

    public Item[] MassiveCraftWorckbench = new Item[9];

    int variable_for_action = 0;

    int id_block1_to_swap = 0;
    int id_block2_to_swap = 0;

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

                        //Если берем из крафтового окошка
                        if(i == 40 && gameObject.name == "Full_Inventory")
                        {
                            if (MassiveCell[36].ChildrenInventory != null)
                            {
                                MassiveCell[36].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[36].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[36].ChildrenInventory.gameObject);
                                    MassiveCell[36].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[36] = null;
                                }
                                else
                                {
                                    MassiveCell[36].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[36].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[37].ChildrenInventory != null)
                            {
                                MassiveCell[37].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[37].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[37].ChildrenInventory.gameObject);
                                    MassiveCell[37].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[37] = null;
                                }
                                else
                                {
                                    MassiveCell[37].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[37].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[38].ChildrenInventory != null)
                            {
                                MassiveCell[38].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[38].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[38].ChildrenInventory.gameObject);
                                    MassiveCell[38].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[38] = null;
                                }
                                else
                                {
                                    MassiveCell[38].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[38].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[39].ChildrenInventory != null)
                            {
                                MassiveCell[39].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[39].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[39].ChildrenInventory.gameObject);
                                    MassiveCell[39].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[39] = null;
                                }
                                else
                                {
                                    MassiveCell[39].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[39].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }
                            CraftCreateVariable = 0;
                            InventoryGameObj.ItemsInventory[40] = MassiveCell[40].ChildrenInventory.GetComponent<Item>();
                        }

                        //Если берем из крафтового окошка верстака
                        if (i == 45 && gameObject.name == "Worckbench_Inventory")
                        {
                            if (MassiveCell[36].ChildrenInventory != null)
                            {
                                MassiveCell[36].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[36].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[36].ChildrenInventory.gameObject);
                                    MassiveCell[36].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[36] = null;
                                }
                                else
                                {
                                    MassiveCell[36].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[36].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[37].ChildrenInventory != null)
                            {
                                MassiveCell[37].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[37].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[37].ChildrenInventory.gameObject);
                                    MassiveCell[37].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[37] = null;
                                }
                                else
                                {
                                    MassiveCell[37].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[37].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[38].ChildrenInventory != null)
                            {
                                MassiveCell[38].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[38].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[38].ChildrenInventory.gameObject);
                                    MassiveCell[38].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[38] = null;
                                }
                                else
                                {
                                    MassiveCell[38].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[38].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[39].ChildrenInventory != null)
                            {
                                MassiveCell[39].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[39].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[39].ChildrenInventory.gameObject);
                                    MassiveCell[39].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[39] = null;
                                }
                                else
                                {
                                    MassiveCell[39].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[39].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[40].ChildrenInventory != null)
                            {
                                MassiveCell[40].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[40].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[40].ChildrenInventory.gameObject);
                                    MassiveCell[40].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[39] = null;
                                }
                                else
                                {
                                    MassiveCell[40].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[40].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[41].ChildrenInventory != null)
                            {
                                MassiveCell[41].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[41].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[41].ChildrenInventory.gameObject);
                                    MassiveCell[41].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[39] = null;
                                }
                                else
                                {
                                    MassiveCell[41].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[41].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[42].ChildrenInventory != null)
                            {
                                MassiveCell[42].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[42].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[42].ChildrenInventory.gameObject);
                                    MassiveCell[42].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[42] = null;
                                }
                                else
                                {
                                    MassiveCell[42].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[42].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[43].ChildrenInventory != null)
                            {
                                MassiveCell[43].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[43].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[43].ChildrenInventory.gameObject);
                                    MassiveCell[43].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[43] = null;
                                }
                                else
                                {
                                    MassiveCell[43].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[43].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }

                            if (MassiveCell[44].ChildrenInventory != null)
                            {
                                MassiveCell[44].ChildrenInventory.GetComponent<Item>().amount--;
                                if (MassiveCell[44].ChildrenInventory.GetComponent<Item>().amount < 1)
                                {
                                    Destroy(MassiveCell[44].ChildrenInventory.gameObject);
                                    MassiveCell[44].ChildrenInventory = null;
                                    InventoryGameObj.ItemsInventory[44] = null;
                                }
                                else
                                {
                                    MassiveCell[44].ChildrenInventory.GetComponent<Item>().Amount_Text.text = Convert.ToString(MassiveCell[44].ChildrenInventory.GetComponent<Item>().amount);
                                }
                            }
                            CraftCreateVariable = 0;
                            InventoryGameObj.ItemsInventory[45] = MassiveCell[45].ChildrenInventory.GetComponent<Item>();
                        }
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

        if (gameObject.name == "Full_Inventory")
        {
            for (int i = 36; i < 41; i++)
            {
                if (i == 36)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraft[0] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 37)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraft[1] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 38)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraft[2] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 39)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraft[3] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                CraftRecipe.Craft(MassiveCraft);
            }
            //Очистка
            for (int i = 0; i < 4; i++) MassiveCraft[i] = null;
        }
        else if(gameObject.name == "Worckbench_Inventory")
        {
            for (int i = 36; i < 46; i++)
            {
                if (i == 36)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[0] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 37)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[1] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 38)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[2] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 39)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[3] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 40)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[4] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 41)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[5] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 42)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[6] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 43)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[7] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                else if (i == 44)
                {
                    if (MassiveCell[i].ChildrenInventory != null)
                    {
                        MassiveCraftWorckbench[8] = MassiveCell[i].ChildrenInventory.GetComponent<Item>();
                    }
                }
                CraftRecipe.Craft(MassiveCraftWorckbench);
            }
            //Очистка
            for (int i = 0; i < 9; i++) MassiveCraftWorckbench[i] = null;
        }
        
        
    }

    public void CraftCreateItem(Item ItemCreate)
    {
        if (gameObject.name == "Full_Inventory")
        {
            if (CraftCreateVariable == 0 && InventoryGameObj.ItemsInventory[40] == null)
            {
                if (ItemCreate.id == 3 || ItemCreate.id == 37 || ItemCreate.id == 40)
                {
                    GameObject NewItem = Instantiate(ItemCreate.gameObject, MassiveCell[40].gameObject.transform.position, Quaternion.identity);
                    NewItem.transform.SetParent(gameObject.transform);
                    NewItem.GetComponent<Item>().amount = 4;
                    NewItem.GetComponent<Item>().Amount_Text.text = Convert.ToString(NewItem.GetComponent<Item>().amount);
                    NewItem.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
                    NewItem.GetComponent<Item>().name = "Item_active";
                    MassiveCell[40].ChildrenInventory = NewItem;
                    CraftCreateVariable = 1;
                }
                else
                {
                    GameObject NewItem = Instantiate(ItemCreate.gameObject, MassiveCell[40].gameObject.transform.position, Quaternion.identity);
                    NewItem.transform.SetParent(gameObject.transform);
                    NewItem.GetComponent<Item>().Amount_Text.text = Convert.ToString(ItemCreate.amount);
                    NewItem.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
                    NewItem.GetComponent<Item>().name = "Item_active";
                    MassiveCell[40].ChildrenInventory = NewItem;
                    CraftCreateVariable = 1;
                }
            }
        }
        else if(gameObject.name == "Worckbench_Inventory")
        {
            if (CraftCreateVariable == 0 && InventoryGameObj.ItemsInventory[45] == null)
            {
                if (ItemCreate.id == 3 || ItemCreate.id == 37 || ItemCreate.id == 40)
                {
                    GameObject NewItem = Instantiate(ItemCreate.gameObject, MassiveCell[45].gameObject.transform.position, Quaternion.identity);
                    NewItem.transform.SetParent(gameObject.transform);
                    NewItem.GetComponent<Item>().amount = 4;
                    NewItem.GetComponent<Item>().Amount_Text.text = Convert.ToString(NewItem.GetComponent<Item>().amount);
                    NewItem.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
                    NewItem.GetComponent<Item>().name = "Item_active";
                    MassiveCell[45].ChildrenInventory = NewItem;
                    CraftCreateVariable = 1;
                }
                else
                {
                    GameObject NewItem = Instantiate(ItemCreate.gameObject, MassiveCell[45].gameObject.transform.position, Quaternion.identity);
                    NewItem.transform.SetParent(gameObject.transform);
                    NewItem.GetComponent<Item>().Amount_Text.text = Convert.ToString(ItemCreate.amount);
                    NewItem.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
                    NewItem.GetComponent<Item>().name = "Item_active";
                    MassiveCell[45].ChildrenInventory = NewItem;
                    CraftCreateVariable = 1;
                }
            }
        }
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

    public void SwapImageIndex40_45(int index1, int index2, int i)
    {
        GameObject Temporary = MassiveCell[index2].ChildrenInventory;
        MassiveCell[index2].ChildrenInventory = MassiveCell[index1].ChildrenInventory;
        MassiveCell[i].ChildrenInventory = Temporary;

        MassiveCell[index1].ChildrenInventory.transform.position = MassiveCell[index2].gameObject.transform.position;
        MassiveCell[i].ChildrenInventory.transform.position = MassiveCell[i].gameObject.transform.position;

        MassiveCell[index1].ChildrenInventory.GetComponent<Item>().variable_for_action = 2;
        MassiveCell[i].ChildrenInventory.GetComponent<Item>().variable_for_action = 2;

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

    public void DeleteCellCraft(int index)
    {
        if (CraftCreateVariable == 1)
        {
            Destroy(MassiveCell[index].ChildrenInventory.gameObject);
            MassiveCell[index].ChildrenInventory = null;

            InventoryGameObj.ItemsInventory[index] = null;

            CraftCreateVariable = 0;
        }
    }

    public void OnDisableOne()
    {
        for(int i = 0; i < MassiveCell.Length; i++)
        {
            Destroy(MassiveCell[i].ChildrenInventory);
            MassiveCell[i].ChildrenInventory = null;
        }
        if(gameObject.name == "Worckbench_Inventory")
        {
            GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().ChangeInventoryVisible();
            GameObject.Find("Inventory_massive").GetComponent<Inventory>().Inventory_Visible = GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().InventoryVisible.GetComponent<Inventory_vis>();
        }
    }
}
