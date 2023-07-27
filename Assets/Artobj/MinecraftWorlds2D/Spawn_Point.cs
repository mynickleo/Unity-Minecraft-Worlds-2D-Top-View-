using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn_Point : Generator_First
{
    //9.03.2022 --> Старт разработки
    //24.03.2022 --> Пришло время переписать всю генерацию
    public GameObject DataBase; // Все-все блоки, которые есть в игре, помещаются в дату

    public GameObject LocationPoint;

    //-->Оформляю переменные для генерации методом Шума Перлина
    public float Zoom = 10f;
    float SeedWorld;
    float Count_MathfPerlin;

    int Count_variable = 0;

    int id_gr_block;
    //<--

    //Переменная для генерации
    int count_plus = 0;

    int spawn_cave = 0;

    public string Biome = "Classic";

    //Переменная для отслеживания того, что чанк сгенерировался полностью
    public int Generated = 0;

    void Start()
    {
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
            else if (count_plus == 3)
            {
                GenerationChunks(1, 1, 12, 12);
                Generated = 1;
            }
            count_plus += 1;
        }
    }

    //Функция генерации
    public void GenerationChunks(int count_one, int count_two, int count_three, int count_four)
    {

        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;
        int i = Convert.ToInt32(gameObject.transform.position.x);
        int j = Convert.ToInt32(gameObject.transform.position.y);
        Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);
        if (Count_MathfPerlin > 0.4)
        {
            ClassicBiome(count_one, count_two, count_three, count_four);
        }
        else if (Count_MathfPerlin > 0.3)
        {
            WinterBiome(count_one, count_two, count_three, count_four);
        }
        else
        {
            Desert(count_one, count_two, count_three, count_four);
            Biome = "Desert";
        }
    }

    public void ClassicBiome(int count_one, int count_two, int count_three, int count_four)
    {
        Vector3 New_Position = new Vector3();
        String Layer = "";

        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;

        for (int i = (Convert.ToInt32(gameObject.transform.position.x) + count_one); i <= (Convert.ToInt32(gameObject.transform.position.x) + count_three); i++)
        {
            for (int j = (Convert.ToInt32(gameObject.transform.position.y) + count_two); j <= (Convert.ToInt32(gameObject.transform.position.y) + count_four); j++)
            {
                Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);

                if (Count_MathfPerlin < 0.20) // Если значение меньше 0.3, тогда это будет камень
                {
                    if (Count_variable < 8)
                    {
                        New_Position = new Vector3(i, j, 6);
                        id_gr_block = 5;
                        Layer = "Block_Layer_1";

                        CreationBlocks(New_Position, id_gr_block, Layer);

                        New_Position = new Vector3(i, j, 4);
                        id_gr_block = 12;
                        Layer = "Block_Layer_Water";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }
                    else
                    {
                        New_Position = new Vector3(i, j, 4);
                        id_gr_block = 6;
                        Layer = "Block_Layer_1";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                        if (Count_MathfPerlin > 0.1 && Count_MathfPerlin < 0.11 && spawn_cave == 0)
                        {
                            GameObject PointCave = Instantiate(LocationPoint, new Vector3(i, j), Quaternion.identity);
                            int RandomGoToBoss = UnityEngine.Random.Range(0, 11);
                            if (RandomGoToBoss == 10) PointCave.GetComponent<CavePoint>().BossTrue = 1;
                            PointCave.transform.SetParent(gameObject.transform);
                            spawn_cave = 1;
                        }
                    }
                }

                else if (Count_MathfPerlin > 0.20 && Count_MathfPerlin < 0.35) // Если значение такое, то это будет земля
                {
                    if (Count_MathfPerlin > 0.2 && Count_variable < 10) // Если значение такое, то будут спавниться озеры
                    {
                        New_Position = new Vector3(i, j, 2);
                        id_gr_block = 5;
                        Layer = "Block_Layer_1";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }
                    else
                    {
                        New_Position = new Vector3(i, j, 2);
                        id_gr_block = 1;
                        Layer = "Block_Layer_1";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }
                }

                else if (Count_MathfPerlin > 0.35) // Если значение такое, то это будет трава
                {
                    New_Position = new Vector3(i, j, 0);
                    id_gr_block = 0;
                    Layer = "Block_Layer_1";

                    CreationBlocks(New_Position, id_gr_block, Layer);

                    if (Count_MathfPerlin >= 0.48 && Count_MathfPerlin <= 0.5 && j % 2 == 0 && i % 2 == 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 14;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }

                    if (Count_MathfPerlin >= 0.56 && Count_MathfPerlin <= 0.57 && j % 2 == 0 && i % 2 == 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 15;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }

                    if (Count_MathfPerlin >= 0.45 && Count_MathfPerlin <= 0.47 && j % 2 != 0 && i % 4 == 0 || Count_MathfPerlin > 0.5 && Count_MathfPerlin <= 0.55 && j % 4 == 0 && i % 2 != 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 13;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }
                }
            }
            Count_variable++;
        }
    }

    public void WinterBiome(int count_one, int count_two, int count_three, int count_four)
    {
        int spawnGift = 0;
        Vector3 New_Position = new Vector3();
        String Layer = "";

        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;

        for (int i = (Convert.ToInt32(gameObject.transform.position.x) + count_one); i <= (Convert.ToInt32(gameObject.transform.position.x) + count_three); i++)
        {
            for (int j = (Convert.ToInt32(gameObject.transform.position.y) + count_two); j <= (Convert.ToInt32(gameObject.transform.position.y) + count_four); j++)
            {
                Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);

                if (Count_MathfPerlin < 0.20) // Если значение меньше 0.3, тогда это будет лед
                {
                    New_Position = new Vector3(i, j, 4);
                    id_gr_block = 53;
                    Layer = "Block_Layer_1";

                    CreationBlocks(New_Position, id_gr_block, Layer);
                }

                else if (Count_MathfPerlin > 0.20 && Count_MathfPerlin < 0.35) // Если значение такое, то это будет снег
                {
                    New_Position = new Vector3(i, j, 2);
                    id_gr_block = 52;
                    Layer = "Block_Layer_1";

                    CreationBlocks(New_Position, id_gr_block, Layer);
                }

                else if (Count_MathfPerlin > 0.35) // Если значение такое, то это будет тоже снег :)
                {
                    New_Position = new Vector3(i, j, 0);
                    id_gr_block = 52;
                    Layer = "Block_Layer_1";

                    CreationBlocks(New_Position, id_gr_block, Layer);

                    if (Count_MathfPerlin >= 0.48 && Count_MathfPerlin <= 0.5 && j % 2 == 0 && i % 2 == 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 14;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }

                    if (Count_MathfPerlin >= 0.56 && Count_MathfPerlin <= 0.57 && j % 2 == 0 && i % 2 == 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 15;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }

                    if (Count_MathfPerlin >= 0.45 && Count_MathfPerlin <= 0.47 && j % 2 != 0 && i % 4 == 0 || Count_MathfPerlin > 0.5 && Count_MathfPerlin <= 0.55 && j % 4 == 0 && i % 2 != 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 13;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }
                }
            }
            Count_variable++;
        }
    }

    public void Desert(int count_one, int count_two, int count_three, int count_four)
    {
        Vector3 New_Position = new Vector3();
        String Layer = "";

        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;
        int SpawnShrub = 0;
        for (int i = (Convert.ToInt32(gameObject.transform.position.x) + count_one); i <= (Convert.ToInt32(gameObject.transform.position.x) + count_three); i++)
        {
            for (int j = (Convert.ToInt32(gameObject.transform.position.y) + count_two); j <= (Convert.ToInt32(gameObject.transform.position.y) + count_four); j++)
            {
                Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);

                if (Count_MathfPerlin >= 0.25)
                {
                    New_Position = new Vector3(i, j, 0);
                    id_gr_block = 5;

                    Layer = "Block_Layer_1";

                    CreationBlocks(New_Position, id_gr_block, Layer);

                    if (Count_MathfPerlin >= 0.55 && Count_MathfPerlin <= 0.6 && SpawnShrub == 0 && j % 2 != 0 && i % 4 == 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 47;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                        SpawnShrub = 1;
                    }
                    else if (Count_MathfPerlin > 0.6 && j % 5 == 0 && i % 5 == 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 48;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }
                    if (SpawnShrub > 0)
                    {
                        SpawnShrub++;
                        if (SpawnShrub == 15)
                        {
                            SpawnShrub = 0;
                        }
                    }
                }
                else
                {
                    New_Position = new Vector3(i, j, 0);
                    id_gr_block = 0;
                    Layer = "Block_Layer_1";

                    CreationBlocks(New_Position, id_gr_block, Layer);

                    if (Count_MathfPerlin <= 0.2 && j % 2 != 0 && i % 4 == 0)
                    {
                        New_Position = new Vector3(i, j, 0);
                        id_gr_block = 13;
                        Layer = "Block_Layer_Decor";

                        CreationBlocks(New_Position, id_gr_block, Layer);
                    }
                }
            }
        }
    }

    private void CreationBlocks(Vector3 New_Position, int id_gr_block, string Layer)
    {
        GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
        gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = Layer;
        gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
        gameobjectNew.transform.SetParent(gameObject.transform);
    }

    private void CreationGiftBlock(Vector3 New_Position, int id_gr_block, string Layer)
    {
        GameObject gameobjectNew = Instantiate(DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block], New_Position, Quaternion.identity);
        gameobjectNew.GetComponent<SpriteRenderer>().sortingLayerName = Layer;
        gameobjectNew.GetComponent<BoxCollider2D>().isTrigger = false;
        gameobjectNew.name = DataBase.GetComponent<DataBaseAllBlocks>().AllBlocks[id_gr_block].name;
        gameobjectNew.transform.SetParent(gameObject.transform);
    }
}
