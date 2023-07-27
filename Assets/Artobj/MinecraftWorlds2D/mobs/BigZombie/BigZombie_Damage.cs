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
                if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 25) //���������� ��� ���� 12 ����� �������
                {
                    Zombie.GetComponent<BigZombie>().HealthMinus(12);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 30) //�������� ��� ���� 17 ����� �������
                {
                    Zombie.GetComponent<BigZombie>().HealthMinus(17);
                }
                else if (GameObject.Find("Cursor").GetComponent<Cursor_>().id_cursor == 35) //�������� ��� ���� 25 ����� �������
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
