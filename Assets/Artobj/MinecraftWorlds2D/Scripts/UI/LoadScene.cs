using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        for (double i = 0; i <= 1; i = i + 0.01)
        {
            GameObject.Find("SliderLoadScene").GetComponent<Slider>().value = (float)i;
        }
        StartCoroutine("DeleteGameObject");
    }
    IEnumerator DeleteGameObject()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

}