using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigHealth : MonoBehaviour
{
    public int health = 35;

    public Sprite Skin_default;
    public Sprite Skin_damage;

    IEnumerator BackToDefaultSkin()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().sprite = Skin_default;
    }

    public void HealthMinus(int health_minus)
    {
        health = health - health_minus;
        gameObject.GetComponent<SpriteRenderer>().sprite = Skin_damage;
        StartCoroutine("BackToDefaultSkin");
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }


}
