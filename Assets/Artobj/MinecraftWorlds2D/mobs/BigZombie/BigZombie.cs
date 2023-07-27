using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombie : MonoBehaviour
{
    private float ZombieMoveSpeed = 0.1f;

    private int actionTrigger = 0;

    public int health = 50;

    public Zombie_change_sprite BigZombie_body;

    public Zombie_change_sprite BigZombie_head;

    public GameObject Damage_shar;

    public GameObject MobsAttack;

    public void Start()
    {
        StartCoroutine("SpawnZombie");
        StartCoroutine("StartDamageShar");
    }

    public void Update()
    {

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
        BigZombie_body.ChangeSpriteDamage();
        BigZombie_head.ChangeSpriteDamage();
        Vector3 WhereDamage = GameObject.Find("Player").transform.position - transform.position;
        health = health - health_minus;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(15);
        Vector3 WherePlayer = GameObject.Find("Player").transform.position - transform.position;
        WherePlayer = new Vector3(WherePlayer.x / 3, WherePlayer.y / 3);
        GameObject gameObjectZombie = Instantiate(MobsAttack, transform.position + WherePlayer, Quaternion.identity);
        WherePlayer = new Vector3(WherePlayer.x / 2, WherePlayer.y / 2);
        gameObjectZombie = Instantiate(MobsAttack, transform.position + WherePlayer, Quaternion.identity);
        StartCoroutine("SpawnZombie");
    }

    IEnumerator StartDamageShar()
    {
        //Каждые n секунд пуляет шар
        yield return new WaitForSeconds(3);
        if (actionTrigger == 1)
        {
            Vector3 WherePlayer =  GameObject.Find("Player").transform.position - transform.position;
            WherePlayer = new Vector3(WherePlayer.x / 1.5f, WherePlayer.y / 1.5f);
            GameObject gameObjectDamageShar = Instantiate(Damage_shar, transform.position + WherePlayer, Quaternion.identity);
        }
        StartCoroutine("StartDamageShar");
    }
}
