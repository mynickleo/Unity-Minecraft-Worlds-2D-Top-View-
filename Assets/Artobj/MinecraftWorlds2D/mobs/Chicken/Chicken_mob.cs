using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_mob : MonoBehaviour
{
    //-->Прописываем поведение цыпе<--//

    //Переменная для изменения спрайта
    public Sprite Chicken_up;

    public Sprite Chicken_default;

    public GameObject Chicken_Body;

    //Переменная счетчик времени
    int count = 0;

    //Переменная "куда двигаться цыпе"
    int count_where = 0;

    //Переменная есть ли действие у объекта
    int count_action = 0;

    //Переменная скорости
    int go = 1;

    //Начальная переменная, чтобы уйти от дерева
    int first_variable_go = 0;

    //Health//
    public int health = 28;

    public Sprite Skin_default;
    public Sprite Skin_damage;
    //-->

    public Item imageChicken;

    public Item ChickenFeather;

    public void OnEnable()
    {
        //В течение от 1 до n (30) секунд будет происходить что-то по счетчику
        count = UnityEngine.Random.Range(1, 31);
        StartCoroutine("ChickenMobMove");

        StartCoroutine("FirstVariableSet");

        StartCoroutine("ChickenSound");

        //Проигрование анимации
        GetComponent<Animation>().Play();
    }
    public void LateUpdate()
    {
        //Пока действие существует цыпа будет двигаться
        if(count_action > 0)
        {
            ChickenMove(count_where);
            count_action--;
        }
    }

    IEnumerator ChickenMobMove()

    {
        yield return new WaitForSeconds(count);

        count_where = UnityEngine.Random.Range(1, 5);

        //В зависимости от направления движения цыпа будет менять свое "направление спрайта"
        if (count_where != 2) Chicken_Body.GetComponent<SpriteRenderer>().sprite = Chicken_default;
        else Chicken_Body.GetComponent<SpriteRenderer>().sprite = Chicken_up;

        //Сделаю так, чтобы цыпа двигалась не всегда
        if (count < 10)
        {
            //Сколько будет выполняться действие
            count_action = 50;
        }
        else if (count > 20) count_action = 150;
        //Заново выполняю корутину
        count = UnityEngine.Random.Range(1, 31);
        StartCoroutine("ChickenMobMove");
    }

    IEnumerator FirstVariableSet()
    {
        yield return new WaitForSeconds(1);
        first_variable_go = 1;
    }

    public void ChickenMove(int count_where)
    {
        if (Time.timeScale != 0f)
        {
            //движение цыпы вниз
            if (count_where == 1) transform.Translate(0, -go * 0.01f, 0);
            //вверх
            if (count_where == 2) transform.Translate(0, go * 0.01f, 0);
            //влево
            if (count_where == 3) transform.Translate(-go * 0.01f, 0, 0);
            //вправо
            if (count_where == 4) transform.Translate(go * 0.01f, 0, 0);
        }
    }

    IEnumerator ChickenSound()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(15, 30));
        GetComponent<AudioSource>().Play();
        StartCoroutine("ChickenSound");
    }

    //Необходима функция на реагирование внешних раздражителей - мобов, предметов и т.д.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Block_Oak_str" || collision.gameObject.name == "Block_Oak_Leaves" || collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "mobs" || collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Block_Layer_2")
        {
            if(first_variable_go == 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                first_variable_go = 1;
            }
            count_where = UnityEngine.Random.Range(1, 5);
            ChickenMove(count_where);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
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
        transform.position = new Vector3(transform.position.x - WhereDamage.x, transform.position.y - WhereDamage.y, transform.position.z); 
        count_action = 50;
        go = 7;
        StartCoroutine("BackToDefaultSkin");
        StartCoroutine("BackToDefaultGo");
        if (health < 1)
        {
            GameObject ImageThisBlock = Instantiate(imageChicken.gameObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            //Предмет можно собрать
            ImageThisBlock.GetComponent<Item>().name = "Item_collect";
            //
            ImageThisBlock.GetComponent<Item>().amount = UnityEngine.Random.Range(1, 4);
            ImageThisBlock.GetComponent<Animation>().Play("Image_Grass");
            ImageThisBlock.transform.SetParent(GameObject.Find("Garbage_Collector").transform);

            //Выброс перьев
            GameObject FeatherThisChicken = Instantiate(ChickenFeather.gameObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            //Предмет можно собрать
            FeatherThisChicken.GetComponent<Item>().name = "Item_collect";
            //
            FeatherThisChicken.GetComponent<Item>().amount = UnityEngine.Random.Range(1, 3);
            FeatherThisChicken.GetComponent<Animation>().Play("Image_Grass");
            FeatherThisChicken.transform.SetParent(GameObject.Find("Garbage_Collector").transform);

            Destroy(gameObject);
        }
    }

}