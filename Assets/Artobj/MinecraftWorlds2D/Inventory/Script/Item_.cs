using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ : MonoBehaviour
{
    public string Name;
    public Sprite Sprite;
    public CraftRecipe Recipe;
    public bool hasRecipe => Recipe != null;
    public Item_(string name, Sprite sprite, CraftRecipe craftRecipe = null)
    {
        Name = name;
        Sprite = sprite;
        Recipe = craftRecipe;
    }

}
