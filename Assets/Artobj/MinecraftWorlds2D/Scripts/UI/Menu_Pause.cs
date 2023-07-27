using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Pause : MonoBehaviour
{
    public GameObject GamePause;
    public GameObject Inventory;

    public GameObject Inventory_massive;

    public GameObject InventoryVisible;

    //верстак
    public GameObject Worckbench;

    public GameObject ChestInventory;

    public GameObject FurnaceInventory;

    //Для нужд изменения
    private GameObject Temporary;
    private int ChangeInventory = 0;

    public GameObject[] OtherGameObject;

    public GameObject HotBar;

    private int count = 0;

    private int countInv = 0;

    public void Start()
    {
        StartCoroutine("InventoryVisibleTrue");
    }

    public void ChangeInventoryVisible()
    {
        if (ChangeInventory == 0)
        {
            Temporary = InventoryVisible;
            InventoryVisible = Worckbench;
            ChangeInventory = 1;
        }
        else
        {
            InventoryVisible = Temporary;
            ChangeInventory = 0;

            Inventory_massive.GetComponent<Inventory>().SaveInventoryToFile();
            Inventory_massive.GetComponent<Inventory>().LoadAllInventory();

            Worckbench.SetActive(false);

            for (int i = 0; i < OtherGameObject.Length; i++)
            {
                OtherGameObject[i].SetActive(true);
            }

            HotBar.GetComponent<CellScript_>().UpdateCellsHotbar();
            countInv = 0;
        }
    }

    public void ChangeInventoryVisibleChest()
    {
        if (ChangeInventory == 0)
        {
            Temporary = InventoryVisible;
            InventoryVisible = ChestInventory;
            ChangeInventory = 1;
        }
        else
        {
            InventoryVisible = Temporary;
            ChangeInventory = 0;

            ChestInventory.SetActive(false);

            for (int i = 0; i < OtherGameObject.Length; i++)
            {
                OtherGameObject[i].SetActive(true);
            }

            HotBar.GetComponent<CellScript_>().UpdateCellsHotbar();
            countInv = 0;
        }
    }

    public void ChangeInventoryVisibleFurnace()
    {
        if (ChangeInventory == 0)
        {
            Temporary = InventoryVisible;
            InventoryVisible = FurnaceInventory;
            ChangeInventory = 1;
        }
        else
        {
            InventoryVisible.SetActive(false);
            InventoryVisible = Temporary;
            ChangeInventory = 0;

            ChestInventory.SetActive(false);

            for (int i = 0; i < OtherGameObject.Length; i++)
            {
                OtherGameObject[i].SetActive(true);
            }

            HotBar.GetComponent<CellScript_>().UpdateCellsHotbar();
            countInv = 0;
        }
    }

    IEnumerator InventoryVisibleTrue()

    {
        yield return new WaitForSeconds(3);
        HotBar.SetActive(true);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (countInv == 1)
            {
                CloseInventory();
            }
            else
            {
                if (count == 0)
                {
                    Pause();
                }
                else if (count == 1)
                {
                    ReturnToGame();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (countInv == 0)
            {
                OpenInventory();
            }
            else if (countInv == 1)
            {
                CloseInventory();
            }
        }
    }

    public void OpenInventory()
    {
        InventoryVisible.SetActive(true);

        for (int i = 0; i < OtherGameObject.Length; i++)
        {
            OtherGameObject[i].SetActive(false);
        }

        countInv = 1;
    }

    public void CloseInventory()
    {
        if (InventoryVisible.gameObject.name == "Chest_Inventory")
        {
            InventoryVisible.GetComponent<Inventory_visible_for_chest>().OnDisableOne();
            InventoryVisible.SetActive(false);
        }
        else if(InventoryVisible.gameObject.name == "Furnace_Inventory")
        {
            InventoryVisible.GetComponent<Inventory_visible_for_furnace>().OnDisableOne();
            InventoryVisible.SetActive(false);
        }
        else
        {
            InventoryVisible.GetComponent<Inventory_vis>().OnDisableOne();
            InventoryVisible.SetActive(false);
        }

        Inventory_massive.GetComponent<Inventory>().SaveInventoryToFile();
        Inventory_massive.GetComponent<Inventory>().LoadAllInventory();

        for (int i = 0; i < OtherGameObject.Length; i++)
        {
            OtherGameObject[i].SetActive(true);
        }

        HotBar.GetComponent<CellScript_>().UpdateCellsHotbar();
        countInv = 0;
    }

    public void Pause()
    {
        GamePause.SetActive(true);
        Inventory_massive.GetComponent<Inventory>().SaveInventoryToFile();
        Inventory_massive.GetComponent<Inventory>().LoadAllInventory();

        InventoryVisible.GetComponent<Inventory_vis>().OnDisableOne();
        InventoryVisible.SetActive(false);

        countInv = 0;

        HotBar.GetComponent<CellScript_>().UpdateCellsHotbar();

        for (int i = 0; i < OtherGameObject.Length; i++)
        {
            OtherGameObject[i].SetActive(false);
        }
        count = 1;
        Time.timeScale = 0f;
    }
    public void ReturnToGame()
    {
        GamePause.SetActive(false);
        for (int i = 0; i < OtherGameObject.Length; i++)
        {
            OtherGameObject[i].SetActive(true);
        }
        count = 0;
        Time.timeScale = 1f;
    }
}
