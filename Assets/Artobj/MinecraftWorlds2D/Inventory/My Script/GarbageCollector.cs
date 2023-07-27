using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    public Inventory InventoryMassive;

    public Inventory_Chest Inventory_Chest;

    public Furnace_inv Inventory_Furnace;

    public void Start()
    {
        StartCoroutine("DeleteImageBlock");
    }

    IEnumerator DeleteImageBlock()
    {
        //������ ��� ������ ����� ����������� ������� ������
        yield return new WaitForSeconds(180);
        DeleteAllImageBlock();
        StartCoroutine("DeleteImageBlock");
    }

    public void DeleteAllImageBlock()
    {
        //��������� ��������� ����� ���������
        InventoryMassive.SaveInventoryToFile();
        InventoryMassive.LoadAllInventory();
        //�������� �� ���� ��������
        foreach(Transform child in GameObject.Find("BuildCreatedBlocks").transform)
        {
            if(child.name == "Chest_Block")
            {
                Inventory_Chest = child.gameObject.GetComponent<Inventory_Chest>();
                Inventory_Chest.SaveInventoryToFile();
                Inventory_Chest.LoadAllInventory();
            }
        }
        //
        //�������� �� ���� ������
        foreach (Transform child in GameObject.Find("BuildCreatedBlocks").transform)
        {
            if (child.name == "Furnace_Block")
            {
                Inventory_Furnace = child.gameObject.GetComponent<Furnace_inv>();
                Inventory_Furnace.SaveInventoryToFile();
                Inventory_Furnace.LoadAllInventory();
            }
        }
        //

        foreach (Transform children in gameObject.transform)
        {
            Destroy(children.gameObject);
        }
    }
}
