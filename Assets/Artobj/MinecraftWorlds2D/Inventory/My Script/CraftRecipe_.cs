using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe_ : MonoBehaviour
{
    //���� � �������
    public DataBaseImages DataBase;

    public Inventory_vis InventoryVisible;

    int count = 0;
    int FirstTime = 0;
    int countReady = 0;
    public void Craft(Item[] ItemsInCraft)
    {
        if (ItemsInCraft.Length == 4)
        {
            //���� ����� ���������� � ������� ���������
            //������� � �� ���� �������
            if (ItemsInCraft[0] != null && ItemsInCraft[1] != null && ItemsInCraft[2] != null && ItemsInCraft[3] != null)
            {
                if (ItemsInCraft[0].id == 3 && ItemsInCraft[1].id == 3 && ItemsInCraft[2].id == 3 && ItemsInCraft[3].id == 3)
                {
                    //�������� � ������
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[21]);
                }
            }
            //� ������ ������
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null)
            {
                if (ItemsInCraft[0].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //�� ������
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] != null && ItemsInCraft[2] == null && ItemsInCraft[3] == null)
            {
                if (ItemsInCraft[1].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //� �������
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] != null && ItemsInCraft[3] == null)
            {
                if (ItemsInCraft[2].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //� ���������
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] != null)
            {
                if (ItemsInCraft[3].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //� ������ � � �������
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] == null && ItemsInCraft[2] != null && ItemsInCraft[3] == null)
            {
                if (ItemsInCraft[0].id == 38 && ItemsInCraft[2].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
                else if (ItemsInCraft[0].id == 3 && ItemsInCraft[2].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
            }
            //�� ������ � ���������
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] != null && ItemsInCraft[2] == null && ItemsInCraft[3] != null)
            {
                if (ItemsInCraft[1].id == 38 && ItemsInCraft[3].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
                else if (ItemsInCraft[1].id == 3 && ItemsInCraft[3].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
            }
            else if (ItemsInCraft[0] == null || ItemsInCraft[1] == null || ItemsInCraft[2] == null || ItemsInCraft[3] == null)
            {
                InventoryVisible.DeleteCellCraft(40);
            }
        }
        else if (ItemsInCraft.Length == 9)
        {
            //����� � ����� ������ �0
            if (ItemsInCraft[0] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[0].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �1
            else if (ItemsInCraft[1] != null && ItemsInCraft[0] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[1].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �2
            else if (ItemsInCraft[2] != null && ItemsInCraft[1] == null && ItemsInCraft[0] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[2].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �3
            else if (ItemsInCraft[3] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[0] == null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[3].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �4
            else if (ItemsInCraft[4] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[0] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[4].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �5
            else if (ItemsInCraft[5] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[0] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[5].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �6
            else if (ItemsInCraft[6] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[0] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[6].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �7
            else if (ItemsInCraft[7] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[0] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[7].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //����� � ����� ������ �8
            else if (ItemsInCraft[8] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[0] == null)
            {
                if (ItemsInCraft[8].id == 10)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[3]);
                }
            }
            //////////////////////////////////////////////////////////////////
            //����� � ���� ������� �0 � #3
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] != null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[0].id == 3 && ItemsInCraft[3].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
                else if (ItemsInCraft[0].id == 38 && ItemsInCraft[3].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
            }
            //����� � ���� ������� #1 � #4
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] != null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] != null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[1].id == 3 && ItemsInCraft[4].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
                else if (ItemsInCraft[1].id == 38 && ItemsInCraft[4].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
            }
            //����� � ���� ������� #2 � �5
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] != null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] != null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[2].id == 3 && ItemsInCraft[5].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
                else if (ItemsInCraft[2].id == 38 && ItemsInCraft[5].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
            }
            //����� � ���� ������� #3 � #6
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] != null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] != null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[3].id == 3 && ItemsInCraft[6].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
                else if (ItemsInCraft[3].id == 38 && ItemsInCraft[6].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
            }
            //����� � ���� ������� #4 � #7
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] != null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] != null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[4].id == 3 && ItemsInCraft[7].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
                else if (ItemsInCraft[4].id == 38 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
            }
            //����� � ���� ������� #5 � #8
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] != null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] != null)
            {
                if (ItemsInCraft[5].id == 3 && ItemsInCraft[8].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[37]);
                }
                else if (ItemsInCraft[5].id == 38 && ItemsInCraft[8].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[40]);
                }
            }
            ///////////////////����� ������������/////////////////
            //����� �� 5 ������� - #0, #1, #2 � #4, #7 - �����///////////
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] != null && ItemsInCraft[2] != null && ItemsInCraft[3] == null && ItemsInCraft[4] != null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] != null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[0].id == 3 && ItemsInCraft[1].id == 3 && ItemsInCraft[2].id == 3 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[23]);
                }
                else if (ItemsInCraft[0].id == 2 && ItemsInCraft[1].id == 2 && ItemsInCraft[2].id == 2 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[28]);
                }
                else if (ItemsInCraft[0].id == 39 && ItemsInCraft[1].id == 39 && ItemsInCraft[2].id == 39 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[33]);
                }
            }
            //����� �� 5 ������� - #0, #1, #3 � #4, #7 - ����� � ����� �������///////////
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] != null && ItemsInCraft[2] == null && ItemsInCraft[3] != null && ItemsInCraft[4] != null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] != null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[0].id == 3 && ItemsInCraft[1].id == 3 && ItemsInCraft[3].id == 3 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[22]);
                }
                else if (ItemsInCraft[0].id == 2 && ItemsInCraft[1].id == 2 && ItemsInCraft[3].id == 2 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[27]);
                }
                else if (ItemsInCraft[0].id == 39 && ItemsInCraft[1].id == 39 && ItemsInCraft[3].id == 39 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[32]);
                }
            }
            //����� �� 5 ������� - #1, #2, #5 � #4, #7 - ����� � ������ �������///////////
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] != null && ItemsInCraft[2] != null && ItemsInCraft[3] == null && ItemsInCraft[4] != null && ItemsInCraft[5] != null && ItemsInCraft[6] == null && ItemsInCraft[7] != null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[1].id == 3 && ItemsInCraft[2].id == 3 && ItemsInCraft[5].id == 3 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[22]);
                }
                else if (ItemsInCraft[1].id == 2 && ItemsInCraft[2].id == 2 && ItemsInCraft[5].id == 2 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[27]);
                }
                else if (ItemsInCraft[1].id == 39 && ItemsInCraft[2].id == 39 && ItemsInCraft[5].id == 39 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[32]);
                }
            }
            //����� �� 3 ������� - #0, #3, #6 - ��� � ������ �����/////////
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] != null && ItemsInCraft[4] == null && ItemsInCraft[5] == null && ItemsInCraft[6] != null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[0].id == 3 && ItemsInCraft[3].id == 3 && ItemsInCraft[6].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[25]);
                }
                else if (ItemsInCraft[0].id == 3 && ItemsInCraft[3].id == 37 && ItemsInCraft[6].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[24]);
                }
                else if (ItemsInCraft[0].id == 2 && ItemsInCraft[3].id == 2 && ItemsInCraft[6].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[30]);
                }
                else if (ItemsInCraft[0].id == 2 && ItemsInCraft[3].id == 37 && ItemsInCraft[6].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[29]);
                }
                else if (ItemsInCraft[0].id == 39 && ItemsInCraft[3].id == 39 && ItemsInCraft[6].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[35]);
                }
                else if (ItemsInCraft[0].id == 39 && ItemsInCraft[3].id == 37 && ItemsInCraft[6].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[34]);
                }
            }
            //����� �� 3 ������� - #1, #4, #7 - ��� � ������ �� ��������/////////
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] != null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] != null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] != null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[1].id == 3 && ItemsInCraft[4].id == 3 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[25]);
                }
                else if (ItemsInCraft[1].id == 3 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[24]);
                }
                else if (ItemsInCraft[1].id == 2 && ItemsInCraft[4].id == 2 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[30]);
                }
                else if (ItemsInCraft[1].id == 2 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[29]);
                }
                else if (ItemsInCraft[1].id == 39 && ItemsInCraft[4].id == 39 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[35]);
                }
                else if (ItemsInCraft[1].id == 39 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[34]);
                }
            }
            //����� �� 3 ������� - #2, #5, #8 - ��� � ������ ������ //////////
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] != null && ItemsInCraft[3] == null && ItemsInCraft[4] == null && ItemsInCraft[5] != null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] != null)
            {
                if (ItemsInCraft[2].id == 3 && ItemsInCraft[5].id == 3 && ItemsInCraft[8].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[25]);
                }
                else if (ItemsInCraft[2].id == 3 && ItemsInCraft[5].id == 37 && ItemsInCraft[8].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[24]);
                }
                else if (ItemsInCraft[2].id == 2 && ItemsInCraft[5].id == 2 && ItemsInCraft[8].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[30]);
                }
                else if (ItemsInCraft[2].id == 2 && ItemsInCraft[5].id == 37 && ItemsInCraft[8].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[29]);
                }
                else if (ItemsInCraft[2].id == 39 && ItemsInCraft[5].id == 39 && ItemsInCraft[8].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[35]);
                }
                else if (ItemsInCraft[2].id == 39 && ItemsInCraft[5].id == 37 && ItemsInCraft[8].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[34]);
                }
            }
            //����� �� 4 ������� - #0, #1 � #4, #7 - ������ � ����� �������////////////////
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] != null && ItemsInCraft[2] == null && ItemsInCraft[3] == null && ItemsInCraft[4] != null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] != null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[0].id == 3 && ItemsInCraft[1].id == 3 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[26]);
                }
                else if (ItemsInCraft[0].id == 2 && ItemsInCraft[1].id == 2 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[31]);
                }
                else if (ItemsInCraft[0].id == 39 && ItemsInCraft[1].id == 39 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[36]);
                }
            }
            //����� �� 4 ������� - #1, #2 � #4, #7 - ������ � ������ ������� /////////////
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] != null && ItemsInCraft[2] != null && ItemsInCraft[3] == null && ItemsInCraft[4] != null && ItemsInCraft[5] == null && ItemsInCraft[6] == null && ItemsInCraft[7] != null && ItemsInCraft[8] == null)
            {
                if (ItemsInCraft[1].id == 3 && ItemsInCraft[2].id == 3 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[26]);
                }
                else if (ItemsInCraft[1].id == 2 && ItemsInCraft[2].id == 2 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[31]);
                }
                else if (ItemsInCraft[1].id == 39 && ItemsInCraft[2].id == 39 && ItemsInCraft[4].id == 37 && ItemsInCraft[7].id == 37)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[36]);
                }
            }
            //////////////////////////////////////////////////////
            ///
            //����� �� ���� ������, ����� ������ - #4 ������
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] != null && ItemsInCraft[2] != null && ItemsInCraft[3] != null && ItemsInCraft[4] == null && ItemsInCraft[5] != null && ItemsInCraft[6] != null && ItemsInCraft[7] != null && ItemsInCraft[8] != null)
            {
                if (ItemsInCraft[0].id == 2 && ItemsInCraft[1].id == 2 && ItemsInCraft[2].id == 2 && ItemsInCraft[3].id == 2 && ItemsInCraft[5].id == 2 && ItemsInCraft[6].id == 2 && ItemsInCraft[7].id == 2 && ItemsInCraft[8].id == 2)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[42]);
                }
                else if (ItemsInCraft[0].id == 3 && ItemsInCraft[1].id == 3 && ItemsInCraft[2].id == 3 && ItemsInCraft[3].id == 3 && ItemsInCraft[5].id == 3 && ItemsInCraft[6].id == 3 && ItemsInCraft[7].id == 3 && ItemsInCraft[8].id == 3)
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[41]);
                }
            }
            ////////////////////////////////////////////////////
            ///����� �������, � ������� 0, 1, 2, 3, 4, 5
            else if (ItemsInCraft[0] != null && ItemsInCraft[1] != null && ItemsInCraft[2] != null && ItemsInCraft[3] != null && ItemsInCraft[4] != null && ItemsInCraft[5] != null && ItemsInCraft[6] == null && ItemsInCraft[7] == null && ItemsInCraft[8] == null)
            {
                if((ItemsInCraft[0].id == 50 && ItemsInCraft[1].id == 50 && ItemsInCraft[2].id == 50 && ItemsInCraft[3].id == 3 && ItemsInCraft[4].id == 3 && ItemsInCraft[5].id == 3))
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[49]);
                }
            }
            else if (ItemsInCraft[0] == null && ItemsInCraft[1] == null && ItemsInCraft[2] == null && ItemsInCraft[3] != null && ItemsInCraft[4] != null && ItemsInCraft[5] != null && ItemsInCraft[6] != null && ItemsInCraft[7] != null && ItemsInCraft[8] != null)
            {
                if ((ItemsInCraft[6].id == 3 && ItemsInCraft[7].id == 3 && ItemsInCraft[8].id == 3 && ItemsInCraft[3].id == 50 && ItemsInCraft[4].id == 50 && ItemsInCraft[5].id == 50))
                {
                    InventoryVisible.CraftCreateItem(DataBase.DataBaseAllImages[49]);
                }
            }
            //�������
            else if (ItemsInCraft[0] == null || ItemsInCraft[1] == null || ItemsInCraft[2] == null || ItemsInCraft[3] == null || ItemsInCraft[4] == null || ItemsInCraft[5] == null || ItemsInCraft[6] == null || ItemsInCraft[7] == null || ItemsInCraft[8] == null)
            {
                InventoryVisible.DeleteCellCraft(45);
            }
        }
    }

}
