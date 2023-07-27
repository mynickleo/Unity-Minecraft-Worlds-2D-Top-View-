using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id; //����� id �����

    public string name; //��� �������
    public string description; //�������� �������
    public int amount; // ���-�� �� �������

    public double endurance = 100; //���������

    private Vector3 MousePosition;

    public Text Amount_Text;

    public GameObject ChildrenInventory;

    public int variable_for_action = 0;

    public void Update()
    {
        if (name == "Item_active")
        {
            if (variable_for_action == 1)
            {
                MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = MousePosition;
            }

            if(variable_for_action == 2)
            {
                StartCoroutine("ChangeVariable");
            }

        }

        
    }

    IEnumerator ChangeVariable()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        variable_for_action = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (name == "Item_collect" && collision.gameObject.name == "Player")
        {
            GameObject.Find("Inventory_massive").GetComponent<Inventory>().PutInInventory(gameObject.GetComponent<Item>());
            gameObject.SetActive(false);
            name = "";
        }
    }
}
