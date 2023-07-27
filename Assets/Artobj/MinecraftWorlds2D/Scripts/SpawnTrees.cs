using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
    //-->Оформляю переменные для создания деревьев с помощью метода Шума Перлина
    public float Zoom = 10f;
    float SeedWorld;
    float Count_MathfPerlin;

    public int count_create = 0;

    public GameObject DataBase; // Все-все блоки, которые есть в игре, помещаются в дату

    int id_gr_block;
    //Переменная для генерации
    int count_plus = 0;

    string Layer = "";

    int randomParam = 0;
    void Start()
    {
        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;
        StartCoroutine("GenerationWorld");
    }

    //Пишем корутину для генерации чанка по частям, иначе - большая нагрузка на компьютер
    IEnumerator GenerationWorld()

    {
        while (count_plus != 4)
        {
            yield return new WaitForSeconds(0.25f);
            if (count_plus == 0) GenerationChunks(-12, -12, 0, 0);
            else if (count_plus == 1) GenerationChunks(1, -12, 12, 0);
            else if (count_plus == 2) GenerationChunks(-12, 1, 0, 12);
            else if (count_plus == 3) GenerationChunks(1, 1, 12, 12);
            count_plus += 1;
        }
    }

    public void GenerationChunks(int count_one, int count_two, int count_three, int count_four)
    {
        if(gameObject.GetComponent<Spawn_Point>().Biome != "Desert") { 
        Vector3 New_Position = new Vector3();

            for (int i = (Convert.ToInt32(gameObject.transform.position.x) + count_one); i <= (Convert.ToInt32(gameObject.transform.position.x) + count_three); i++)
            {
                for (int j = (Convert.ToInt32(gameObject.transform.position.y) + count_two); j <= (Convert.ToInt32(gameObject.transform.position.y) + count_four); j++)
                {
                    Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);
                    if (Count_MathfPerlin > 0.55)
                    {
                        if (i + SeedWorld % 2 == 0 && count_create == 0) count_create = 1;

                        if (count_create == 1)
                        {
                            if (Count_MathfPerlin < 0.8)
                            {
                                New_Position = new Vector3(i, j, 0);
                                id_gr_block = 10;
                                Layer = "Block_Layer_Trees";
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 1, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                id_gr_block = 9;
                                New_Position = new Vector3(i - 1, j + 2, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j + 2, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 2, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 3, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i - 1, j + 3, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j + 3, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 4, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);
                            }
                            else
                            {
                                ///Ствол дерева
                                New_Position = new Vector3(i, j, 0);
                                id_gr_block = 10;
                                Layer = "Block_Layer_Trees";
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 1, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 2, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j + 1, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j + 2, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);
                                ///
                                ///Листья дерева
                                id_gr_block = 9;

                                New_Position = new Vector3(i - 1, j + 3, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 3, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j + 3, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 2, j + 3, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i - 1, j + 4, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 4, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j + 4, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 2, j + 4, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i, j + 5, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);

                                New_Position = new Vector3(i + 1, j + 5, 0);
                                CreationBlocks(New_Position, id_gr_block, Layer);
                                ///Листья дерева
                            }

                        }
                        if (count_create < 45)
                        {
                            count_create++;
                        }
                        else
                        {
                            count_create = 0;
                        }
                    }
                }
            }
        }

    }

    private void CreationBlocks(Vector3 New_Position, int id_gr_block, string Layer)
    {
        GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
        gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = Layer;
        gameobjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
        gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
        gameobjectNew.transform.SetParent(gameObject.transform);
    }
}

