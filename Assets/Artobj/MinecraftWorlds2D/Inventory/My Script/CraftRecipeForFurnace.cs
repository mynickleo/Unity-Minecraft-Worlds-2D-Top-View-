using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftRecipeForFurnace : MonoBehaviour
{
    //Файл с крафтом
    public DataBaseImages DataBase;

    public Furnace_inv Furnace;

    int count = 0;
    int FirstTime = 0;
    int countReady = 0;
    public void Craft(Item[] ItemsInCraft)
    {
        //Крафт для печки
        if (ItemsInCraft.Length == 3)
        {
            //Если окошко печки пустое и хотим что-то расплавить
            if (ItemsInCraft[0] != null && ItemsInCraft[1] != null)
            {
                if (ItemsInCraft[1].id == 38 || ItemsInCraft[1].id == 3)
                {
                    //Крафт жареной свинины
                    if (ItemsInCraft[0].id == 45 && (ItemsInCraft[2] == null || ItemsInCraft[2].id == 46))
                    {
                        if (FirstTime == 0 && count == 0)
                        {
                            FirstTime = 1;
                            count = 5;
                            StartCoroutine("StartMelting");
                            if (GameObject.Find("Furnace_Inventory") == true)
                            {
                                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().EnableFire();
                            }
                            Furnace.FurnaceFire_();
                        }
                        else if (countReady == 1)
                        {
                            Furnace.CraftCreateItem(DataBase.DataBaseAllImages[46]);
                            countReady = 0;
                            FirstTime = 0;
                            count = 0;
                            StopAllCoroutines();
                            if (GameObject.Find("Furnace_Inventory") == true)
                            {
                                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().DisableFire();
                            }
                            Furnace.FurnaceNotFire_();
                        }
                    }
                    //Крафт жареной свинины
                    else if (ItemsInCraft[0].id == 43 && (ItemsInCraft[2] == null || ItemsInCraft[2].id == 44))
                    {
                        if (FirstTime == 0 && count == 0)
                        {
                            FirstTime = 1;
                            count = 5;
                            StartCoroutine("StartMelting");
                            if (GameObject.Find("Furnace_Inventory") == true)
                            {
                                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().EnableFire();
                            }
                            Furnace.FurnaceFire_();
                        }
                        else if (countReady == 1)
                        {
                            Furnace.CraftCreateItem(DataBase.DataBaseAllImages[44]);
                            countReady = 0;
                            FirstTime = 0;
                            count = 0;
                            StopAllCoroutines();
                            if (GameObject.Find("Furnace_Inventory") == true)
                            {
                                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().DisableFire();
                            }
                            Furnace.FurnaceNotFire_();
                        }
                    }
                    else if (ItemsInCraft[0].id == 20 && (ItemsInCraft[2] == null || ItemsInCraft[2].id == 39))
                    {
                        if (FirstTime == 0 && count == 0)
                        { 
                            FirstTime = 1;
                            count = 10;
                            StartCoroutine("StartMelting");
                            if (GameObject.Find("Furnace_Inventory") == true)
                            {
                                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().EnableFire();
                            }
                            Furnace.FurnaceFire_();
                        }
                        else if (countReady == 1)
                        {
                            //Добавить железо
                            Furnace.CraftCreateItem(DataBase.DataBaseAllImages[39]);
                            countReady = 0;
                            FirstTime = 0;
                            count = 0;
                            StopAllCoroutines();
                            if (GameObject.Find("Furnace_Inventory") == true)
                            {
                                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().DisableFire();
                            }
                            Furnace.FurnaceNotFire_();
                        }
                    }
                }
            }
            else
            {
                StopAllCoroutines();
                countReady = 0;
                FirstTime = 0;
                count = 0;
                if (GameObject.Find("Furnace_Inventory") == true)
                {
                    GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().DisableFire();
                }
                Furnace.FurnaceNotFire_();
            }
        }
    }
    IEnumerator StartMelting()
    {
        while (count > 0)
        {
            if (GameObject.Find("Furnace_Inventory") == true)
            {
                GameObject.Find("Furnace_Inventory").GetComponent<Inventory_visible_for_furnace>().EnableFire();
            }
            Furnace.FurnaceFire_();
            count--;
            if (count == 0) countReady = 1;
            yield return new WaitForSeconds(1);
        }
    }
}
