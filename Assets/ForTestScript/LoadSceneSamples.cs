using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneSamples : MonoBehaviour
{
    //Этот скрипт будет посвящен загрузке объектов, функций для новых локаций

    //По-сути, при загрузке новой сцены все объекты проходят новое включение, соответственно, можно использовать start()
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

    //Пропишем вариации локаций
    public void LocationUpWorld() //Локация верхнего мира
    {
        //Здесь будет описано все, что должно включаться/выключаться в верхнем мире

        //<--

        //Работаем с освещением -->
        GameObject.Find("Point Light").transform.position = new Vector3(transform.position.x, transform.position.y, -12); //по умолчанию
        //<--
    }

    public void LocationCaves() //Локация пещер
    {
        //Работаем с освещением -->
        GameObject.Find("Point Light").transform.position = new Vector3(transform.position.x, transform.position.y, -30);
        //<--
    }
}
