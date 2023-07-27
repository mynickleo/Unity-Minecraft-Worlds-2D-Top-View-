using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization : MonoBehaviour
{
    private Vector3 LookAt = Camera.main.transform.position;

    public void Update()
    {
        Vector3 LookAt = Camera.main.transform.position;
        float p_x = LookAt.x;
        float p_y = LookAt.y;

        float g_x = transform.position.x;
        float g_y = transform.position.y;

        if ((g_x < p_x + 25) && (g_y < p_y + 25) && (g_x > (p_x - 25)) && (g_y > (p_y - 25)))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}
