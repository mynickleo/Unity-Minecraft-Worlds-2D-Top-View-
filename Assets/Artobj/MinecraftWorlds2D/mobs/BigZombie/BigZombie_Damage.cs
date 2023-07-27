using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombie_Damage : MonoBehaviour
{
    public GameObject Zombie;

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cursor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 25) //Деревянный меч дает 12 урона минусом
                {
                    Zombie.GetComponent<BigZombie>().HealthMinus(12);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 30) //Каменный меч дает 17 урона минусом
                {
                    Zombie.GetComponent<BigZombie>().HealthMinus(17);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 35) //Железный меч дает 25 урона минусом
                {
                    Zombie.GetComponent<BigZombie>().HealthMinus(25);
                }
                else
                {
                    Zombie.GetComponent<BigZombie>().HealthMinus(7);
                }
            }
        }
    }
}
