using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus_hit : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Если ударились с Player, тогда
        if(collision.gameObject.name == "Player")
        {
            Hit();
        }
    }

    public void Hit()
    {
        Vector3 WhereDamage = GameObject.Find("Player").transform.position - gameObject.transform.position;
        GameObject.Find("Player").GetComponent<Player>().HealthMinus(5);
        GameObject.Find("Player").transform.position += WhereDamage;
    }
}
