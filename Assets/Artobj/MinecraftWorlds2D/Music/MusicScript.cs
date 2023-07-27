using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource[] Music;

    public int count = 0;
    public void Start()
    {
        count = UnityEngine.Random.Range(0, Music.Length);
        StartCoroutine("FirstMusic");
    }

    IEnumerator FirstMusic()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0, 60));
        Music[count].Play();
        StartCoroutine("PlayMusic");
    }

    IEnumerator PlayMusic()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(300, 600));
            count = UnityEngine.Random.Range(0, Music.Length);
            Music[count].Play();
        }
    }
}
