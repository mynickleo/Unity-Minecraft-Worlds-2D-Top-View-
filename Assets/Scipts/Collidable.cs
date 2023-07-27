using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D BoxCollider;
    private Collider2D[] hits = new Collider2D[10]; // переменная, которая будет хранить информацию о том, куда мы вообще попали

    protected virtual void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //Работа Столкновений
        BoxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) continue;

            OnCollide(hits[i]);

            //Массив не очищен, поэтому мы делаем это сами
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D Coll)
    {
        Debug.Log(Coll.name);
    }
}
