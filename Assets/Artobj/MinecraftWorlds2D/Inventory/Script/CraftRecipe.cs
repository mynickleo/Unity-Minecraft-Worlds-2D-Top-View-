using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe : MonoBehaviour
{
    public Item[,] Items;
    public int Amount;

    public Item[] ItemsOrder;

    public CraftRecipe(Item[,] items, int amount)
    {
        Items = items;
        Amount = amount;
        ItemsOrder = new Item[Items.Length];

        for(int orderId = 0, i = 0; i < Items.GetLength(0); i++)
        {
            for(int k = 0; k < Items.GetLength(0); k++)
            {
                ItemsOrder[orderId++] = Items[i, k];
            }
        }
    }
}
