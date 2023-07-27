using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig_Script_ : MonoBehaviour
{
    int count = 0;

    int go = 1;

    float action = 0;

    int count_First = 0;

    int countAbs = 0;

    public GameObject Pig_left_right;
    public GameObject Pig_up;

    public GameObject Pig;

    //variable for animation relax
    int variable_relax = 0;

    //Health//
    public int health = 35;

    public Sprite Skin_default;
    public Sprite Skin_damage;
    //-->

    public Item imagePig;

    int variable_start_transform = 1;

    public void OnEnable()
    {
        transform.position = Pig.transform.position;
        StartCoroutine("PigMobMove");

        StartCoroutine("PigSound");
        count = UnityEngine.Random.Range(1, 15);
    }
    public void Start()
    {
        count = UnityEngine.Random.Range(1, 15);
    }

    public void Update()
    {
        if (action > 0)
        {
            transform.Translate(0, -go * 0.01f, 0);
            action--;
        }
        if (action == 0) variable_relax = 0;
        if (variable_relax == 0)
        {
            GetComponent<Animation>().Play();
            variable_relax = 1;
        }
    }
    IEnumerator PigMobMove()

    {
        yield return new WaitForSeconds(count);
        countAbs = UnityEngine.Random.Range(0, 2);
        if (countAbs == 0)
        {
            if (transform.rotation.z > 0)
            {
                transform.Rotate(new Vector3(0, 0, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 15));
            }
        }
        else
        {
            if (transform.rotation.z < 0)
            {
                transform.Rotate(new Vector3(0, 0, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -15));
            }
        }
        if (count < 5)
        {
            action = 150;
        }
        else if (count > 10)
        {
            action = 150;
        }
        count = UnityEngine.Random.Range(1, 15);
        StartCoroutine("PigMobMove");
        StartCoroutine("PigMobChange");
    }

    IEnumerator PigMobChange()

    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(30, 60));
        countAbs = UnityEngine.Random.Range(0, 2);
        if(countAbs == 0)
        {
            Pig.transform.position = transform.position;
            gameObject.SetActive(false);
            Pig_left_right.SetActive(true);
        }
        else
        {
            Pig.transform.position = transform.position;
            gameObject.SetActive(false);
            Pig_up.SetActive(true);
        }
    }

    IEnumerator PigSound()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(15, 60));
        GetComponent<AudioSource>().Play();
        StartCoroutine("PigSound");
    }

    IEnumerator PigCloseStartTransform()
    {
        yield return new WaitForSeconds(1);
        variable_start_transform = 0;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (variable_start_transform == 1)
        {
            if (collision.gameObject.name == "Block_Oak_str" || collision.gameObject.name == "Block_Oak_Leaves" || collision.gameObject.name == "Pig(Clone)")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f);
                Pig.transform.position = transform.position;
            }
            StartCoroutine("PigCloseStartTransform");
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Cursor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 25) //Деревянный меч дает 12 урона минусом
                {
                    HealthMinus(12);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 30) //Каменный меч дает 17 урона минусом
                {
                    HealthMinus(17);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 35) //Железный меч дает 25 урона минусом
                {
                    HealthMinus(25);
                }
                else
                {
                    HealthMinus(7);
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cursor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 25) //Деревянный меч дает 12 урона минусом
                {
                    HealthMinus(12);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 30) //Каменный меч дает 17 урона минусом
                {
                    HealthMinus(17);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 35) //Железный меч дает 25 урона минусом
                {
                    HealthMinus(25);
                }
                else
                {
                    HealthMinus(7);
                }
            }
        }
    }

    IEnumerator BackToDefaultSkin()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().sprite = Skin_default;
    }

    IEnumerator BackToDefaultGo()
    {
        yield return new WaitForSeconds(3);
        go = 1;
    }

    public void HealthMinus(int health_minus)
    {
        health = health - health_minus;
        gameObject.GetComponent<SpriteRenderer>().sprite = Skin_damage;
        Vector3 WhereDamage = GameObject.Find("Player").transform.position - transform.position;
        transform.position -= WhereDamage;
        action = 100;
        go = 7;
        StartCoroutine("BackToDefaultSkin");
        StartCoroutine("BackToDefaultGo");
        if (health < 1)
        {
            GameObject ImageThisBlock = Instantiate(imagePig.gameObject, transform.position, Quaternion.identity);
            //Предмет можно собрать
            ImageThisBlock.GetComponent<Item>().name = "Item_collect";
            //
            ImageThisBlock.GetComponent<Item>().amount = 1;
            ImageThisBlock.GetComponent<Animation>().Play("Image_Grass");
            ImageThisBlock.transform.SetParent(GameObject.Find("Garbage_Collector").transform);

            Destroy(Pig);
        }
    }
}
