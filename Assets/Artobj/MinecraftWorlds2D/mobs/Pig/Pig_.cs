using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig_ : MonoBehaviour
{
    public GameObject Pig_left_right;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Block_Oak_str" || collision.gameObject.name == "Block_Oak_Leaves")
        {
            gameObject.SetActive(false);
            Pig_left_right.SetActive(true);
        }
    }
}
