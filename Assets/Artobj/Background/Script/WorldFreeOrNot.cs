using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldFreeOrNot : MonoBehaviour
{
    // Start is called before the first frame update

    float SidWorld;
    public void FixedUpdate()
    {
        string Firstfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D";
        if (Directory.Exists(Firstfolder))
        {
            string pathToOtherFile = Firstfolder + @"\Save";
            if (Directory.Exists(pathToOtherFile))
            {
                pathToOtherFile = pathToOtherFile + @"\"+gameObject.name;
                if (Directory.Exists(pathToOtherFile))
                {
 
                    GetComponentInChildren<Text>().text = gameObject.name;
                }
                else
                {
                    GetComponentInChildren<Text>().text = "��������";
                }
            }
            else
            {
                Directory.CreateDirectory(pathToOtherFile);
                GetComponentInChildren<Text>().text = "��������";
            }
        }
        else
        {
            Directory.CreateDirectory(Firstfolder);
            string pathToOtherFile = Firstfolder + @"\Save";
            Directory.CreateDirectory(pathToOtherFile);
            GetComponentInChildren<Text>().text = "��������";
        }
    }

    public void OnClick()
    {
        string Firstfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D";
        string pathToOtherFile = Firstfolder + @"\Save\"+gameObject.name;
        SidWorld = UnityEngine.Random.Range(0, 9999999);
        string pathToSid = pathToOtherFile + @"\Seed";
        string path = Firstfolder + @"\World_Name.txt";
        if (Directory.Exists(pathToOtherFile))
        {
            StreamWriter writer = new StreamWriter(path, false); //���� ���������� ������������, ����� � ���� ����������, ��� ��� ����������
            writer.WriteLine(gameObject.name);
            writer.Close();
            SceneManager.LoadScene("Minecraft_Worlds2D");
        }
        else
        {
            StreamWriter writer = new StreamWriter(path, false); //���� ���, ����� �� ������� ���, �� �������� ������ ������� �� �����
            writer.WriteLine(gameObject.name);
            writer.Close();

            SceneManager.LoadScene("Minecraft_Worlds2D");
            Directory.CreateDirectory(pathToOtherFile);
            StreamWriter writerSeed = new StreamWriter(pathToSid, false); //���� ���, ����� �� ������� ���, �� �������� ������ ������� �� �����
            writerSeed.WriteLine(SidWorld);
            writerSeed.Close();
        }
    }
}
