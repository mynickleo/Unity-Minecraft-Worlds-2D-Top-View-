using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    public void OnEnable()
    {
        GetComponent<Animation>().Play();
    }
}
