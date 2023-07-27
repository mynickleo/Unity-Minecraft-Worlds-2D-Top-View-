using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_First : MonoBehaviour
{

    public GameObject object_bedrock;

    public int ForGame = 0;
    void Start()
    {
        Vector3 New_Position = new Vector3();
        for (int i = (Convert.ToInt32(gameObject.transform.position.x) - 25); i <= (Convert.ToInt32(gameObject.transform.position.x) + 25); i++)
        {
            for (int j = (Convert.ToInt32(gameObject.transform.position.y) - 25); j <= (Convert.ToInt32(gameObject.transform.position.y) + 25); j++)
            {
                New_Position = new Vector3(i, j, 6);
                GameObject gameObjectNew = Instantiate(object_bedrock, New_Position, Quaternion.identity);
                gameObjectNew.name = object_bedrock.name;
                gameObjectNew.transform.SetParent(gameObject.transform);
            }
        }
        ForGame = 1;
    }


}
