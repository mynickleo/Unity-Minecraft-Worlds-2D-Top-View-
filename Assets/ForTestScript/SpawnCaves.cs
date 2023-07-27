using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCaves : MonoBehaviour
{
    public GameObject DataBase; // Все-все блоки, которые есть в игре, помещаются в дату

    //-->Оформляю переменные для генерации методом Шума Перлина
    public float Zoom = 10f;
    float SeedWorld;
    float Count_MathfPerlin;

    int Count_variable = 0;

    int id_gr_block;
    //<--

    //Переменная для генерации
    int count_plus = 0;

    void Start()
    {
        StartCoroutine("GenerationWorld");
        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;
    }

    //Пишем корутину для генерации чанка по частям, иначе - большая нагрузка на компьютер
    IEnumerator GenerationWorld()

    {
        while (count_plus != 4)
        {
            yield return new WaitForSeconds(0.25f);
            if (count_plus == 0) GenerationChunks(-20, -20, 0, 0);
            else if (count_plus == 1) GenerationChunks(1, -20, 20, 0);
            else if (count_plus == 2) GenerationChunks(-20, 1, 0, 20);
            else if (count_plus == 3) GenerationChunks(1, 1, 20, 20);
            count_plus += 1;
        }
    }

    public void GenerationChunks(int count_one, int count_two, int count_three, int count_four)
    {
        Vector3 New_Position = new Vector3();

        for (int i = (Convert.ToInt32(gameObject.transform.position.x) + count_one); i <= (Convert.ToInt32(gameObject.transform.position.x) + count_three); i++)
        {
            for (int j = (Convert.ToInt32(gameObject.transform.position.y) + count_two); j <= (Convert.ToInt32(gameObject.transform.position.y) + count_four); j++)
            {
                Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);
                if(Count_MathfPerlin > 0.208 && Count_MathfPerlin < 0.21) //Спавн грибов в пещере
                {
                    New_Position = new Vector3(i, j);
                    if (j % 2 != 0)
                    {
                        id_gr_block = 17;
                    }
                    else
                    {
                        id_gr_block = 18;
                    }

                    GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
                    gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_1";
                    gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
                    gameobjectNew.transform.SetParent(gameObject.transform);
                }
                if (Count_MathfPerlin > 0.35 && Count_MathfPerlin < 0.65) // Если значение такое, то это будет камень
                {
                    if (Count_MathfPerlin > 0.53 && Count_MathfPerlin < 0.54) 
                    {
                        New_Position = new Vector3(i, j);
                        id_gr_block = 19;

                        GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
                        gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_1";
                        gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
                        gameobjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
                        gameobjectNew.transform.SetParent(gameObject.transform);
                    }
                    else if (Count_MathfPerlin > 0.62 && Count_MathfPerlin < 0.63)
                    {
                        New_Position = new Vector3(i, j);
                        id_gr_block = 20;

                        GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
                        gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_1";
                        gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
                        gameobjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
                        gameobjectNew.transform.SetParent(gameObject.transform);
                    }
                    else
                    {
                        New_Position = new Vector3(i, j);
                        id_gr_block = 6;

                        GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
                        gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = "Block_Layer_1";
                        gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
                        gameobjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
                        gameobjectNew.transform.SetParent(gameObject.transform);
                    }
                }
            }
        }

    }
}
