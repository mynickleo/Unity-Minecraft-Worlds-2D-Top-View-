using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point0OnOrOff : MonoBehaviour
{
    public GameObject point;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            point.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            point.SetActive(false);
        }
    }
}
