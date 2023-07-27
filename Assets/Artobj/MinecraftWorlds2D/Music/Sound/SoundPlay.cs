using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public AudioSource Sound_Play;
    public void OnMouseDown()
    {
        Sound_Play.Play();
    }
}
