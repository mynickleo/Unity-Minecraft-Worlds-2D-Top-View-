using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Inventory : MonoBehaviour
{
    public Image[] inImages;
    public Sprite[] sprites;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            inImages[0].sprite = sprites[0];
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            inImages[0].sprite = sprites[1];
        }
    }
}
