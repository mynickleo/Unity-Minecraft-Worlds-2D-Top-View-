using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_script : MonoBehaviour
{
    private float ZombieMoveSpeed = 0.1f;

    private int actionTrigger = 0;

    public int health = 50;

    public Zombie_change_sprite Zombie_body;

    public void Start()
    {
        GetComponent<Animation>().Play();

        StartCoroutine("CheckLightPosition");
    }

    public void Update()
    {
        if (actionTrigger == 1 && Time.timeScale > 0)
        {
            Transform PlayerPosition = GameObject.Find("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, 0.01f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            actionTrigger = 1;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            actionTrigger = 0;
        }
    }

    public void HealthMinus(int health_minus)
    {
        Zombie_body.ChangeSpriteDamage();
        Vector3 WhereDamage = GameObject.Find("Player").transform.position - transform.position;
        transform.position -= WhereDamage;
        health = health - health_minus;
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }

    public void HealthMinusForLight(int health_minus)
    {
        Zombie_body.ChangeSpriteDamage();
        health = health - health_minus;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator CheckLightPosition()
    {
        yield return new WaitForSeconds(1);
        if(GameObject.Find("Point Light").transform.position.z > -40)
        {
            HealthMinusForLight(15);
        }
        StartCoroutine("CheckLightPosition");
    }
}
