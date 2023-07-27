using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_damage : MonoBehaviour
{
    public GameObject Zombie;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Vector3 WhereDamage = GameObject.Find("Player").transform.position - Zombie.transform.position;
            GameObject.Find("Player").GetComponent<Player>().HealthMinus(5);
            GameObject.Find("Player").transform.position += WhereDamage;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Cursor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 25) //Деревянный меч дает 12 урона минусом
                {
                    Zombie.GetComponent<Zombie_script>().HealthMinus(12);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 30) //Каменный меч дает 17 урона минусом
                {
                    Zombie.GetComponent<Zombie_script>().HealthMinus(17);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 35) //Железный меч дает 25 урона минусом
                {
                    Zombie.GetComponent<Zombie_script>().HealthMinus(25);
                }
                else
                {
                    Zombie.GetComponent<Zombie_script>().HealthMinus(7);
                }
            }
        }
    }
}
