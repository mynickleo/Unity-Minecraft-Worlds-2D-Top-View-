using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript_ : MonoBehaviour
{
    public GameObject[] Cells;

    public Inventory InventoryAll;

    public InvActive InventoryActive;

    public void Start()
    {
        StartCoroutine("ad_timer_First_");
    }

    IEnumerator ad_timer_First_()
    {
        yield return new WaitForSeconds(0.1f);
        StartHotBar();
    }

    public void StartHotBar()
    {
        int j = 0;
        for (int i = 27; i <= 35; i++)
        {
            if (InventoryAll.ItemsInventory[i] != null)
            {
                GameObject NewGameObj = Instantiate(InventoryAll.ItemsInventory[i].gameObject, Cells[j].gameObject.transform.position, Quaternion.identity);
                NewGameObj.GetComponent<Item>().Amount_Text.text = Convert.ToString(NewGameObj.GetComponent<Item>().amount);
                NewGameObj.transform.SetParent(gameObject.transform);
                NewGameObj.SetActive(true);
                Cells[j].GetComponent<CellsHotbar>().ImageBlock = NewGameObj.GetComponent<Image>();
                NewGameObj.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
            }

            j++;
        }
    }

    public void UpdateCellsHotbar()
    {
        int j = 27;
        for(int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].GetComponent<CellsHotbar>().ImageBlock != null)
            {
                Destroy(Cells[i].GetComponent<CellsHotbar>().ImageBlock.gameObject);
                Cells[i].GetComponent<CellsHotbar>().ImageBlock = null;
            }

            if (InventoryAll.ItemsInventory[j] != null)
            {
                GameObject NewGameObj = Instantiate(InventoryAll.ItemsInventory[j].gameObject, Cells[i].gameObject.transform.position, Quaternion.identity);
                NewGameObj.GetComponent<Item>().Amount_Text.text = Convert.ToString(NewGameObj.GetComponent<Item>().amount);
                NewGameObj.transform.SetParent(gameObject.transform);
                NewGameObj.SetActive(true);
                Cells[i].GetComponent<CellsHotbar>().ImageBlock = NewGameObj.GetComponent<Image>();
                NewGameObj.GetComponent<Item>().Amount_Text.gameObject.SetActive(true);
            }

            j++;
        }
    }

    public void UpdateONECellHotbar(int index)
    {
        int amount_cells = 0;
        Cells[index].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().amount--;
        amount_cells = Cells[index].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().amount;
        Cells[index].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().Amount_Text.text = Convert.ToString(amount_cells);
        if(amount_cells < 1)
        {
            Destroy(Cells[index].GetComponent<CellsHotbar>().ImageBlock.gameObject);
            Cells[index].GetComponent<CellsHotbar>().ImageBlock = null;
            if (index == 0) InventoryAll.ItemsInventory[27] = null;
            else if (index == 1) InventoryAll.ItemsInventory[28] = null;
            else if (index == 2) InventoryAll.ItemsInventory[29] = null;
            else if (index == 3) InventoryAll.ItemsInventory[30] = null;
            else if (index == 4) InventoryAll.ItemsInventory[31] = null;
            else if (index == 5) InventoryAll.ItemsInventory[32] = null;
            else if (index == 6) InventoryAll.ItemsInventory[33] = null;
            else if (index == 7) InventoryAll.ItemsInventory[34] = null;
            else if (index == 8) InventoryAll.ItemsInventory[27] = null;
        }
        else
        {
            if (index == 0) InventoryAll.ItemsInventory[27].amount--;
            else if (index == 1) InventoryAll.ItemsInventory[28].amount--;
            else if (index == 2) InventoryAll.ItemsInventory[29].amount--;
            else if (index == 3) InventoryAll.ItemsInventory[30].amount--;
            else if (index == 4) InventoryAll.ItemsInventory[31].amount--;
            else if (index == 5) InventoryAll.ItemsInventory[32].amount--;
            else if (index == 6) InventoryAll.ItemsInventory[33].amount--;
            else if (index == 7) InventoryAll.ItemsInventory[34].amount--;
            else if (index == 8) InventoryAll.ItemsInventory[27].amount--;
        }
        InventoryAll.SaveInventoryToFile();
    }

    public void UpdateONECellHotbarEndurance(int index)
    {
        if (index == 0)
        {
            if (InventoryAll.ItemsInventory[27].id > 22 && InventoryAll.ItemsInventory[27].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[27].endurance = InventoryAll.ItemsInventory[27].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[27].id > 26 && InventoryAll.ItemsInventory[27].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[27].endurance = InventoryAll.ItemsInventory[27].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[27].id > 31 && InventoryAll.ItemsInventory[27].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[27].endurance = InventoryAll.ItemsInventory[27].endurance - 1;
            }

            if(InventoryAll.ItemsInventory[27].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[27].gameObject);
                InventoryAll.ItemsInventory[27] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 1 && InventoryAll.ItemsInventory[28] != null)
        {
            if (InventoryAll.ItemsInventory[28].id > 22 && InventoryAll.ItemsInventory[28].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[28].endurance = InventoryAll.ItemsInventory[28].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[28].id > 26 && InventoryAll.ItemsInventory[28].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[28].endurance = InventoryAll.ItemsInventory[28].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[28].id > 31 && InventoryAll.ItemsInventory[28].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[28].endurance = InventoryAll.ItemsInventory[28].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[28].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[28].gameObject);
                InventoryAll.ItemsInventory[28] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 2 && InventoryAll.ItemsInventory[29] != null)
        {
            if (InventoryAll.ItemsInventory[29].id > 22 && InventoryAll.ItemsInventory[29].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[29].endurance = InventoryAll.ItemsInventory[29].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[29].id > 26 && InventoryAll.ItemsInventory[29].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[29].endurance = InventoryAll.ItemsInventory[29].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[29].id > 31 && InventoryAll.ItemsInventory[29].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[29].endurance = InventoryAll.ItemsInventory[29].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[29].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[29].gameObject);
                InventoryAll.ItemsInventory[29] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 3 && InventoryAll.ItemsInventory[30] != null)
        {
            if (InventoryAll.ItemsInventory[30].id > 22 && InventoryAll.ItemsInventory[30].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[30].endurance = InventoryAll.ItemsInventory[30].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[30].id > 26 && InventoryAll.ItemsInventory[30].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[30].endurance = InventoryAll.ItemsInventory[30].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[30].id > 31 && InventoryAll.ItemsInventory[30].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[30].endurance = InventoryAll.ItemsInventory[30].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[30].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[30].gameObject);
                InventoryAll.ItemsInventory[30] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 4 && InventoryAll.ItemsInventory[31] != null)
        {
            if (InventoryAll.ItemsInventory[31].id > 22 && InventoryAll.ItemsInventory[31].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[31].endurance = InventoryAll.ItemsInventory[31].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[31].id > 26 && InventoryAll.ItemsInventory[31].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[31].endurance = InventoryAll.ItemsInventory[31].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[31].id > 31 && InventoryAll.ItemsInventory[31].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[31].endurance = InventoryAll.ItemsInventory[31].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[31].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[31].gameObject);
                InventoryAll.ItemsInventory[31] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 5 && InventoryAll.ItemsInventory[32] != null)
        {
            if (InventoryAll.ItemsInventory[32].id > 22 && InventoryAll.ItemsInventory[32].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[32].endurance = InventoryAll.ItemsInventory[32].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[32].id > 26 && InventoryAll.ItemsInventory[32].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[32].endurance = InventoryAll.ItemsInventory[32].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[32].id > 31 && InventoryAll.ItemsInventory[32].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[32].endurance = InventoryAll.ItemsInventory[32].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[32].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[32].gameObject);
                InventoryAll.ItemsInventory[32] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 6 && InventoryAll.ItemsInventory[33] != null)
        {
            if (InventoryAll.ItemsInventory[33].id > 22 && InventoryAll.ItemsInventory[33].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[33].endurance = InventoryAll.ItemsInventory[33].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[33].id > 26 && InventoryAll.ItemsInventory[33].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[33].endurance = InventoryAll.ItemsInventory[33].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[33].id > 31 && InventoryAll.ItemsInventory[33].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[33].endurance = InventoryAll.ItemsInventory[33].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[33].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[33].gameObject);
                InventoryAll.ItemsInventory[33] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 7 && InventoryAll.ItemsInventory[34] != null)
        {
            if (InventoryAll.ItemsInventory[34].id > 22 && InventoryAll.ItemsInventory[34].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[34].endurance = InventoryAll.ItemsInventory[34].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[34].id > 26 && InventoryAll.ItemsInventory[34].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[34].endurance = InventoryAll.ItemsInventory[34].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[34].id > 31 && InventoryAll.ItemsInventory[34].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[34].endurance = InventoryAll.ItemsInventory[34].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[34].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[34].gameObject);
                InventoryAll.ItemsInventory[34] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
        else if (index == 8 && InventoryAll.ItemsInventory[35] != null)
        {
            if (InventoryAll.ItemsInventory[35].id > 22 && InventoryAll.ItemsInventory[35].id < 27)
            {
                //Деревянный предмет хватит на 10 использований
                InventoryAll.ItemsInventory[35].endurance = InventoryAll.ItemsInventory[35].endurance - 10;
            }
            else if (InventoryAll.ItemsInventory[35].id > 26 && InventoryAll.ItemsInventory[35].id < 32)
            {
                //Каменный предмет хватит на 34 использований
                InventoryAll.ItemsInventory[35].endurance = InventoryAll.ItemsInventory[35].endurance - 3;
            }
            else if (InventoryAll.ItemsInventory[35].id > 31 && InventoryAll.ItemsInventory[35].id < 37)
            {
                //Железный предмет хватит на 100 использований
                InventoryAll.ItemsInventory[35].endurance = InventoryAll.ItemsInventory[35].endurance - 1;
            }

            if (InventoryAll.ItemsInventory[35].endurance < 1)
            {
                Destroy(InventoryAll.ItemsInventory[35].gameObject);
                InventoryAll.ItemsInventory[35] = null;
                InventoryAll.SaveInventoryToFile();
                GameObject.Find("Cursor").GetComponent<Cursor_>().ChangeActiveCursor(0);
            }
        }
    }
}

