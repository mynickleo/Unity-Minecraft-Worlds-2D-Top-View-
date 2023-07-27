using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Cursor_ : MonoBehaviour
{
    public Transform lookAt;

    public GameObject PointCreatingBlocks;

    private Vector3 mousePosition;
    public float moveSpeed = 2f;

    public Vector3 PositionRay;

    public GameObject Cursor_Block;

    public string name;

    public int id_cursor;


    //--> Изменение в зависимости от предмета в активной ячейке хотбара<--//
    public Sprite Default_Cursor; //Стандартный спрайт курсора

    //Дерево - кирка, лопата, меч, топор, мотыга
    public Sprite Wooden_axe;
    public Sprite Wooden_pickaxe;
    public Sprite Wooden_shovel;
    public Sprite Wooden_sword;
    public Sprite Wooden_hoe;
    //Камень - кирка, лопата, меч, топор, мотыга
    public Sprite Stone_axe;
    public Sprite Stone_pickaxe;
    public Sprite Stone_shovel;
    public Sprite Stone_sword;
    public Sprite Stone_hoe;
    //Железо - кирка, лопата, меч, топор, мотыга
    public Sprite Iron_axe;
    public Sprite Iron_pickaxe;
    public Sprite Iron_shovel;
    public Sprite Iron_sword;
    public Sprite Iron_hoe;

    //->закрытие<--//

    public void Start()
    {
        ChangeActiveCursor(0);
    }

    public void ChangeActiveCursor(int id)
    {
        if(id == 0)
        {
            //Если я передаю 0, то изменить на стандарт
            GetComponent<SpriteRenderer>().sprite = Default_Cursor;

            transform.localScale = new Vector3(3, 3, transform.localScale.z);

            id_cursor = id;
        }

        //Дерево
        if(id == 22)
        {
            GetComponent<SpriteRenderer>().sprite = Wooden_axe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if(id == 23)
        {
            GetComponent<SpriteRenderer>().sprite = Wooden_pickaxe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if(id == 24)
        {
            GetComponent<SpriteRenderer>().sprite = Wooden_shovel;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if(id == 25)
        {
            GetComponent<SpriteRenderer>().sprite = Wooden_sword;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 26)
        {
            GetComponent<SpriteRenderer>().sprite = Wooden_hoe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }

        //Камень
        if (id == 27)
        {
            GetComponent<SpriteRenderer>().sprite = Stone_axe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 28)
        {
            GetComponent<SpriteRenderer>().sprite = Stone_pickaxe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 29)
        {
            GetComponent<SpriteRenderer>().sprite = Stone_shovel;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 30)
        {
            GetComponent<SpriteRenderer>().sprite = Stone_sword;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 31)
        {
            GetComponent<SpriteRenderer>().sprite = Stone_hoe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }

        //Железо
        if (id == 32)
        {
            GetComponent<SpriteRenderer>().sprite = Iron_axe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 33)
        {
            GetComponent<SpriteRenderer>().sprite = Iron_pickaxe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 34)
        {
            GetComponent<SpriteRenderer>().sprite = Iron_shovel;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 35)
        {
            GetComponent<SpriteRenderer>().sprite = Iron_sword;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
        if (id == 36)
        {
            GetComponent<SpriteRenderer>().sprite = Iron_hoe;

            transform.localScale = new Vector3(0.7f, 0.7f, transform.localScale.z);
            id_cursor = id;
        }
    }

    private void LateUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float deltaX = lookAt.position.x - transform.position.x;

        float deltaY = lookAt.position.y - transform.position.y;

        float deltaMouseX = mousePosition.x - lookAt.position.x;
        float deltaMouseY = mousePosition.y - lookAt.position.y;

        if (deltaMouseX > 0)
        {
            if (deltaMouseY > 0)
            {
                if (deltaMouseX > deltaMouseY)
                {
                    transform.position += new Vector3(deltaX + 1, deltaY);
                }
                else
                {
                    transform.position += new Vector3(deltaX, deltaY + 1);
                }
            }
            else
            {
                if (deltaMouseX > Mathf.Abs(deltaMouseY))
                {
                    transform.position += new Vector3(deltaX + 1, deltaY);
                }
                else
                {
                    transform.position += new Vector3(deltaX, deltaY - 1);
                }
            }
        }
        if (deltaMouseX < 0)
        {
            if (deltaMouseY < 0)
            {
                if (Mathf.Abs(deltaMouseX) > Mathf.Abs(deltaMouseY))
                {
                    transform.position += new Vector3(deltaX - 1, deltaY);
                }
                else
                {
                    transform.position += new Vector3(deltaX, deltaY - 1);
                }
            }
            else
            {
                if (Mathf.Abs(deltaMouseX) > deltaMouseY)
                {
                    transform.position += new Vector3(deltaX - 1, deltaY);
                }
                else
                {
                    transform.position += new Vector3(deltaX, deltaY + 1);
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name != "0(Clone)")
        {
            if (collision.gameObject.name != "0_(Clone)")
            {
                name = collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name != "0(Clone)")
        {
            if (collision.gameObject.name != "0_(Clone)")
            {
                name = collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            }
        }
    }
}
