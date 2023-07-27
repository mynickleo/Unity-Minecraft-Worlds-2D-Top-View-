using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneSamples : MonoBehaviour
{
    //���� ������ ����� �������� �������� ��������, ������� ��� ����� �������

    //��-����, ��� �������� ����� ����� ��� ������� �������� ����� ���������, ��������������, ����� ������������ start()
    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
        {
            LocationUpWorld();
        }

        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
        {
            LocationCaves();
        }

    }

    //�������� �������� �������
    public void LocationUpWorld() //������� �������� ����
    {
        //����� ����� ������� ���, ��� ������ ����������/����������� � ������� ����

        //<--

        //�������� � ���������� -->
        GameObject.Find("Point Light").transform.position = new Vector3(transform.position.x, transform.position.y, -12); //�� ���������
        //<--
    }

    public void LocationCaves() //������� �����
    {
        //�������� � ���������� -->
        GameObject.Find("Point Light").transform.position = new Vector3(transform.position.x, transform.position.y, -30);
        //<--
    }
}
