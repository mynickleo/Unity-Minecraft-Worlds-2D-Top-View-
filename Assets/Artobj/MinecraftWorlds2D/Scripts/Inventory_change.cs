using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_change : MonoBehaviour
{
    public Sprite[] sprites;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
    }
}
