using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityPOS : MonoBehaviour
{

    public GameObject Point;

    public void Start()
    {
        //При страте будет загружаться та точка, на координатах которой будет находиться персонаж
        transform.position = Point.transform.position;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Point = Instantiate(Point, new Vector3(collision.transform.position.x * 5f, collision.transform.position.y * 5f), Quaternion.identity);
    }
}
