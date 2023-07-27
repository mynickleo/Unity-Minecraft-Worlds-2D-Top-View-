using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    float SeedWorld;

    public GameObject GameBoss;
    void Start()
    {
        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;

        float randomplaceX = UnityEngine.Random.Range(Convert.ToInt32(gameObject.transform.position.x) - 19, Convert.ToInt32(gameObject.transform.position.x) + 19);
        float randomplaceY = UnityEngine.Random.Range(Convert.ToInt32(gameObject.transform.position.y) - 19, Convert.ToInt32(gameObject.transform.position.y) + 19);
        GameObject BossOfGame = Instantiate(GameBoss, new Vector3(randomplaceX, randomplaceY, GameBoss.transform.position.z), Quaternion.identity);
    }

}
