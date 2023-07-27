using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perlin : MonoBehaviour
{
    // Тестирую алгоритм Перлина

    float sidWorld;
    float zoom = 10f;
    float n;
    int i, j;
    void Start()
    {
        sidWorld = Random.Range(1, 99999);
        Debug.Log(sidWorld);
        for (i = 0; i < 10; i++)
        {
            for (j = 0; j < 10; j++)
            {
                n = Mathf.PerlinNoise((i + sidWorld) / zoom, (j+sidWorld) / zoom);
                Debug.Log(n);

                }
        }
    }

}
