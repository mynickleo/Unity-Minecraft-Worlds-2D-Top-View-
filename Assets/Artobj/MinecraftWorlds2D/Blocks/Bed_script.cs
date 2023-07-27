using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_script : MonoBehaviour
{
    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Cursor")
        {
            if (Input.GetMouseButtonDown(1))
            {
                GameObject.Find("Point Light").GetComponent<TimeDayNight>().SkipNightPoint();
            }
        }
    }
}
