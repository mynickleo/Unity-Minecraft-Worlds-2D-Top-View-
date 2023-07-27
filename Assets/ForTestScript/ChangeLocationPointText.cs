using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLocationPointText : MonoBehaviour
{
    public GameObject ParentGmObj;
    public void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
        {
            if (ParentGmObj.GetComponent<CavePoint>().BossTrue == 1)
            {
                GetComponentInChildren<Text>().text = "R - вход в подземное царство";
            }
            else
            {
                GetComponentInChildren<Text>().text = "R - вход в пещеру";
            }
        }
        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
        {
            GetComponentInChildren<Text>().text = "R - выход из пещеры";
        }
        if(SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Boss")
        {
            GetComponentInChildren<Text>().text = "R - выход из  подземного царства";
        }
    }
}
