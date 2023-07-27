using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_change_sprite : MonoBehaviour
{
    public Sprite Mob_default;
    public Sprite Mob_damage;

    IEnumerator SetDefaultSprite()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().sprite = Mob_default;
    }
    public void ChangeSpriteDamage()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Mob_damage;
        StartCoroutine("SetDefaultSprite");
    }
}
