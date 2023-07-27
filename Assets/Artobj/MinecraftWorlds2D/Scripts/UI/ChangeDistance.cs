using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDistance : MonoBehaviour
{
    int distance = 5;
    public GameObject ScrollBar_Distance;
    void Update()
    {
        if (ScrollBar_Distance.GetComponent<Scrollbar>().value < 0.3)
        {
            Camera.main.GetComponent<Camera>().orthographicSize = 4;
            distance = 4;
        }
        if(ScrollBar_Distance.GetComponent<Scrollbar>().value > 0.3 && ScrollBar_Distance.GetComponent<Scrollbar>().value < 0.7)
        {
            Camera.main.GetComponent<Camera>().orthographicSize = 5;
            distance = 5;
        }
        if (ScrollBar_Distance.GetComponent<Scrollbar>().value > 0.7)
        {
            Camera.main.GetComponent<Camera>().orthographicSize = 7;
            distance = 7;
        }
        GameObject.Find("TextDistance").GetComponent<Text>().text = Convert.ToString(distance);
    }
}
