using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_shar : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            Transform PlayerPosition = GameObject.Find("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, 0.05f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Vector3 WhereDamage = GameObject.Find("Player").transform.position - transform.position;
            GameObject.Find("Player").GetComponent<Player>().HealthMinus(5);
            GameObject.Find("Player").transform.position += WhereDamage;
        }
        if (collision.gameObject.name != "BigZombie(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
