using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PointChecker : MonoBehaviour
{
    public GameObject[] points;

    public Vector3 LookAt;
void Update()
    {
        if (GameObject.Find("DeletedObject_") == null)
        {
            LookAt = Camera.main.transform.position;
            for(int i = 0; i < points.Length; i++)
            {
                if(points[i].transform.position.x == 0)
                {
                    if (LookAt.x < points[i].transform.position.x + 30 && LookAt.x > points[i].transform.position.x - 30)
                    {
                        if (Mathf.Abs(points[i].transform.position.y - LookAt.y) < 30)
                        {
                            points[i].SetActive(true);
                        }
                        else
                        {
                            points[i].SetActive(false);
                        }
                    }
                    else
                    {
                        points[i].SetActive(false);
                    }
                }
                else if (points[i].transform.position.y == 0)
                {
                    if (LookAt.y < points[i].transform.position.y + 30 && LookAt.y > points[i].transform.position.y - 30)
                    {
                        if (Mathf.Abs(points[i].transform.position.x - LookAt.x) < 30)
                        {
                            points[i].SetActive(true);
                        }
                        else
                        {
                            points[i].SetActive(false);
                        }
                    }
                    else
                    {
                        points[i].SetActive(false);
                    }
                }
                else if(Mathf.Abs(points[i].transform.position.x - LookAt.x) < 30 && Mathf.Abs(points[i].transform.position.y - LookAt.y) < 30)
                {
                    points[i].SetActive(true);
                }
                else
                {
                    points[i].SetActive(false);
                }
            }
        }  
    }
}
