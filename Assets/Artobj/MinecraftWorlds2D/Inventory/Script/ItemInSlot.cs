using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInSlot : MonoBehaviour
{
    public Item Item;
    public int Amount;

    public ItemInSlot(Item item, int amount)
    {
        Item = item;
        Amount = amount;
    }
}
