using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Script : MonoBehaviour
{
    public Sprite CloseChest;
    public Sprite FullChest;
    public Sprite EmptyChest;

    protected bool collected = false;

    private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.name == "Player")
            {
                if (!collected)
                {
                    GetComponent<SpriteRenderer>().sprite = FullChest;
                    if (Input.GetKey(KeyCode.E))
                    {
                        GiveGoldForPlyaer();
                    }
                }
                else GetComponent<SpriteRenderer>().sprite = EmptyChest;
            }
            Debug.Log("Protivno");
        }

    private void GiveGoldForPlyaer()
        {
            if (!collected)
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = EmptyChest;
            }
        }

    private void OnTriggerExit2D(Collider2D collision)
        {
            GetComponent<SpriteRenderer>().sprite = CloseChest;
        }
}
