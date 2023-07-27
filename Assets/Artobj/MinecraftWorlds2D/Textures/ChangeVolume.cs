using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    int volume;
    void Update()
    {
        volume = Convert.ToInt32(GameObject.Find("Scrollbar_Music").GetComponent<Scrollbar>().value * 100);
        GameObject.Find("TextVolume").GetComponent<Text>().text = Convert.ToString(volume) + "%";
        for(int i = 0; i < GameObject.Find("Main Camera").GetComponent<MusicScript>().Music.Length; i++)
        {
            GameObject.Find("Main Camera").GetComponent<MusicScript>().Music[i].volume = GameObject.Find("Scrollbar_Music").GetComponent<Scrollbar>().value;
        }
    }
}
