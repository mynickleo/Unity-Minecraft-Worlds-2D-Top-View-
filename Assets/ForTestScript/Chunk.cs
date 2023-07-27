using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int countChunk = 0;
    public int meshEnd = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            countChunk = 1;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            countChunk = 0;
        }
    }

}
