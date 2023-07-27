using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Block : MonoBehaviour
{
    //Скрипт для выделения блока
    public Transform lookAt; // За кем следует

    float deltaX;
    float deltaY;

    public void Update()
    {

        deltaX = Mathf.Round(lookAt.position.x);

        deltaY = Mathf.Round(lookAt.position.y);
        transform.position = new Vector3(deltaX, deltaY, 0);
    }
}
