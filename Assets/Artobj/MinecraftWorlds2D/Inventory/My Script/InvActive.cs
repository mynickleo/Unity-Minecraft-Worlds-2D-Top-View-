using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InvActive : MonoBehaviour
{
    private int count = 0;

    private int countTrigger = 1;

    public Image[] imagesInvetory; // массив ячеек инвентаря-быстрого доступа

    public GameObject DataBase; // Все-все блоки, которые есть в игре, помещаются в дату инвентаря

    public Sprite inv_passive;
    public Sprite inv_active;

    private Vector3 cursor_position;

    public int active = 0;

    private int id_Block; //ID определенного блока для нужд


    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt"; //Строки для записи
    string NameWorld;

    string PathToWorld;
    string generation;

    public GameObject PointCreatingBlocks;

    public GameObject CursorObject;

    private int z = 0;

    //переменная которая будет отвечать за проверку изменен ли курсор
    private int variable_for_change_cursor = 0;

    public void Start()
    {
        imagesInvetory[count].sprite = inv_active;

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();

        PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld;
        generation = PathToWorld + @"\CreateBlocks";

        StartCoroutine("ad_timer_First_ToInventory");
    }

    IEnumerator ad_timer_First_ToInventory()
    {
        yield return new WaitForSeconds(3.25f);
        if (imagesInvetory[count].GetComponent<CellsHotbar>().ImageBlock != null)
        {
            ChangeCursorItem(imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().id);
        }
        else
        {
            ChangeCursorItem(0);
        }
    }

    public void Update()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            count++;
            if (count != imagesInvetory.Length)
            {
                imagesInvetory[count].sprite = inv_active;
                active = count;
                if (count != 0)
                {
                    imagesInvetory[count - 1].sprite = inv_passive;
                }
                if (count != imagesInvetory.Length - 1)
                {
                    imagesInvetory[count + 1].sprite = inv_passive;
                }
            }
            else
            {
                imagesInvetory[count - 1].sprite = inv_passive;
                count = 0;
                imagesInvetory[count].sprite = inv_active;
                active = count;
            }
            if (imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock != null)
            {
                ChangeCursorItem(imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().id);
            }
            else
            {
                ChangeCursorItem(0);
            }
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            count--;
            if (count >= 0)
            {
                imagesInvetory[count].sprite = inv_active;
                active = count;
                if (count != imagesInvetory.Length - 1)
                {
                    imagesInvetory[count + 1].sprite = inv_passive;
                }
                if (count != 0)
                {
                    imagesInvetory[count - 1].sprite = inv_passive;
                }
            }
            else
            {
                imagesInvetory[0].sprite = inv_passive;
                count = imagesInvetory.Length - 1;
                imagesInvetory[count].sprite = inv_active;
                active = count;
            }
            if (imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock != null)
            {
                ChangeCursorItem(imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().id);
            }
            else
            {
                ChangeCursorItem(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (countTrigger == 0)
            {
                countTrigger = 1;
                GameObject.Find("TextAboutBlock").GetComponent<Text>().text = "";
            }
            else if (countTrigger == 1)
            {
                countTrigger = 0;
                GameObject.Find("TextAboutBlock").GetComponent<Text>().text = "Твердый блок";
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (imagesInvetory[active].GetComponentInChildren<Image>() != null && CursorObject.GetComponent<Cursor_>().name != "Block_Layer_2")
            {
                CreateBlockOnPosition();
            }
        }
    }

    public void CreateBlockOnPosition()
    {
        id_Block = imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().id;
        if (id_Block < 22 || id_Block > 39)
        {
            if (id_Block < 43 || id_Block > 46)
            {
                StreamWriter GenerationWorld = new StreamWriter(generation, true);

                cursor_position = CursorObject.transform.position;
                float coordinate_x = Mathf.Round(cursor_position.x);
                float coordinate_y = Mathf.Round(cursor_position.y);
                Vector3 coordinate_xy = new Vector3(coordinate_x, coordinate_y);
                id_Block = imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().id;
                imagesInvetory[active].GetComponentInParent<CellScript_>().UpdateONECellHotbar(active);
                if (id_Block == 40) coordinate_xy = new Vector3(coordinate_xy.x, coordinate_xy.y, -3f);
                GameObject gameObjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_Block], coordinate_xy, Quaternion.identity);
                //gameObjectNew.GetComponent<Block_Delete>().SoundSet.Play();
                if (countTrigger == 0) gameObjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
                if (id_Block == 41)
                {
                    int CountChest = GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountChest;
                    CountChest++;
                    gameObjectNew.GetComponent<Block_information>().ChestVariable = CountChest;
                }
                if (id_Block == 42)
                {
                    int CountFurnace = GameObject.Find("SeedWorld").GetComponent<FindSeed>().CountFurnace;
                    CountFurnace++;
                    gameObjectNew.GetComponent<Block_information>().FurnaceVariable = CountFurnace;
                }
                gameObjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_Block].name;
                gameObjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_2";
                gameObjectNew.GetComponent<SpriteRenderer>().material.name = "Sprites-Default";
                gameObjectNew.transform.SetParent(PointCreatingBlocks.transform);

                GenerationWorld.WriteLine(coordinate_x);
                GenerationWorld.WriteLine(coordinate_y);
                GenerationWorld.WriteLine(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_Block].GetComponent<Block_information>().id);
                GenerationWorld.WriteLine(countTrigger);
                GenerationWorld.Close();
            }
            else
            {
                if (GameObject.Find("Player").GetComponent<Player>().health < 100)
                {
                    id_Block = imagesInvetory[active].GetComponent<CellsHotbar>().ImageBlock.GetComponent<Item>().id;
                    imagesInvetory[active].GetComponentInParent<CellScript_>().UpdateONECellHotbar(active);
                    if (GameObject.Find("Player").GetComponent<Player>().health < 100)
                    {
                        if (id_Block == 44)
                        {
                            GameObject.Find("Player").GetComponent<Player>().HealthPlus(20);
                        }
                        else if (id_Block == 46)
                        {
                            GameObject.Find("Player").GetComponent<Player>().HealthPlus(20);
                        }
                        else
                        {
                            GameObject.Find("Player").GetComponent<Player>().HealthPlus(10);
                        }
                    }
                }
            }
        }
    }

    //Метод который будет изменять спрайт курсора, если выбрать определенный предмет
    public void ChangeCursorItem(int id)
    {
        //Дерево
        if (id == 22)
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(id);
            variable_for_change_cursor = 1;
        }
        else if (id == 23)
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(id);
            variable_for_change_cursor = 1;
        }
        else if (id == 24)
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(id);
            variable_for_change_cursor = 1;
        }
        else if (id == 25)
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(id);
            variable_for_change_cursor = 1;
        }
        else if (id == 26)
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(id);
            variable_for_change_cursor = 1;
        }
        //Камень
        else if (id >= 27 && id <= 31)
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(id);
            variable_for_change_cursor = 1;
        }
        //Железо
        else if (id >= 32 && id <= 36)
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(id);
            variable_for_change_cursor = 1;
        }
        else if(variable_for_change_cursor == 1) //Дабы не вызывать смену курсора при отсутствии нужных предметов буду делать возвращение к сатндарту 1 раз
        {
            CursorObject.GetComponent<Cursor_>().ChangeActiveCursor(0);
            variable_for_change_cursor = 0;
        }
    }
}
