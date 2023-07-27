using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D Coll)
    {
        if(Coll.name == "Player")
        {
            OnCollected();
        }
    }

    protected virtual void OnCollected()
    {
        collected = true;
    }
}
