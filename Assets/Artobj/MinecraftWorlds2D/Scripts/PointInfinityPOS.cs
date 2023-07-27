using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInfinityPOS : MonoBehaviour
{
    public GameObject PointCreate;

    public void Start()
    {
        transform.position = GameObject.Find("Player").transform.position;
        PointCreate.transform.position = gameObject.transform.position;


        PointCreate.transform.position = gameObject.transform.position;
        PointCreate.transform.SetParent(gameObject.transform);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(PointCreate);
        Destroy(gameObject);
    }
}
