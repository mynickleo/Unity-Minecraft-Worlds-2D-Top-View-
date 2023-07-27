using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    float SeedWorld;
    public GameObject PigMob;

    public GameObject ChickenMob;

    float Count_MathfPerlin;
    float Zoom = 10f;

    int count_plus = 0;

    int RandomSpawn = 0;
    void Start()
    {
        StartCoroutine("GenerationWorld");
    }

    //Пишем корутину для генерации чанка по частям, иначе - большая нагрузка на компьютер
    IEnumerator GenerationWorld()

    {
        while (count_plus != 4)
        {
            RandomSpawn = UnityEngine.Random.Range(0, 5);
            //Сделаем рандомный спавн, чтобы мобы не спавнились всегда
            if (RandomSpawn == 1)
            {
                yield return new WaitForSeconds(0.25f);
                if (count_plus == 0) GenerationChunks(-20, -20, 0, 0);
                else if (count_plus == 1) GenerationChunks(1, -20, 20, 0);
                else if (count_plus == 2) GenerationChunks(-20, 1, 0, 20);
                else if (count_plus == 3) GenerationChunks(1, 1, 20, 20);
                count_plus += 1;
            }
        }
    }
    public void GenerationChunks(int count_one, int count_two, int count_three, int count_four)
    {
        RandomSpawn = UnityEngine.Random.Range(0, 3);

        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;

        //Сделаем рандомный спавн, чтобы мобы не спавнились всегда
        if (RandomSpawn == 1)
        {
            for (int i = (Convert.ToInt32(gameObject.transform.position.x) + count_one); i <= (Convert.ToInt32(gameObject.transform.position.x) + count_three); i++)
            {
                for (int j = (Convert.ToInt32(gameObject.transform.position.y) + count_two); j <= (Convert.ToInt32(gameObject.transform.position.y) + count_four); j++)
                {
                    Count_MathfPerlin = Mathf.PerlinNoise((i + SeedWorld) / Zoom, (j + SeedWorld) / Zoom);
                    if (Count_MathfPerlin >= 0.54 && Count_MathfPerlin < 0.55 && j % 5 == 0 && i % 2 == 0)
                    {
                        GameObject gameObjectNew = Instantiate(PigMob, new Vector3(i, j), Quaternion.identity);
                        gameObjectNew.transform.SetParent(gameObject.transform);
                    }

                    if (Count_MathfPerlin >= 0.5 && Count_MathfPerlin < 0.52 && j % 5 == 0)
                    {
                        GameObject gameObjectNew = Instantiate(ChickenMob, new Vector3(i, j, -17), Quaternion.identity);
                        gameObjectNew.transform.SetParent(gameObject.transform);
                    }
                }
            }
        }
    }
}
