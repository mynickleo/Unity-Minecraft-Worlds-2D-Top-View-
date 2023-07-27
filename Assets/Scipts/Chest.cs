using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Chest : Collectable
{
    public Sprite CloseChest;
    public Sprite FullChest;
    public Sprite EmptyChest;

    public int GoldAmount = 100;
    protected override void OnCollide(Collider2D Coll)
    {
        if (Coll.name == "Player")
        {
            if (!collected)
            {
                GetComponent<SpriteRenderer>().sprite = FullChest;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GiveGoldForPlayer();
                }
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = EmptyChest;
            }
        }
        if (Coll.name == "Cursor")
        {
            Destroy(gameObject);
        }
    }

    private void GiveGoldForPlayer()
    {
        collected = true;
        GetComponent<SpriteRenderer>().sprite = EmptyChest;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = CloseChest;
    }
}
