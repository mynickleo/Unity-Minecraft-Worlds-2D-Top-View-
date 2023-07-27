using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Block_Delete : Collectable
{
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;

    private BoxCollider2D BoxCollider;

    public GameObject Destroy_Block;

    public AudioSource SoundDelete;

    public AudioSource SoundGo;

    public AudioSource SoundSet;

    protected override void OnCollide(Collider2D Coll)
    {
        if (Coll.name == "Cursor")
        {
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Player").GetComponent<Player>().gamemode == 1)
            {
                StreamReader ReaderWorld = new StreamReader(World, false);
                NameWorld = ReaderWorld.ReadLine();
                ReaderWorld.Close();

                if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
                {
                    Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\DestroyedBlocks";

                    StreamWriter GenerationWorld = new StreamWriter(Folder, true);
                    GenerationWorld.WriteLine(gameObject.transform.position.x);
                    GenerationWorld.WriteLine(gameObject.transform.position.y);
                    GenerationWorld.Close();

                }
                else if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
                {
                    Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\DestroyedBlocks_Cave";

                    StreamWriter GenerationWorld = new StreamWriter(Folder, true);
                    GenerationWorld.WriteLine(gameObject.transform.position.x);
                    GenerationWorld.WriteLine(gameObject.transform.position.y);
                    GenerationWorld.Close();

                }
                Destroy(gameObject);
                GameObject.Find("Cursor").GetComponent<Cursor_>().name = "";
            }
            else if (Input.GetMouseButtonDown(0) && GameObject.Find("Player").GetComponent<Player>().gamemode == 0) {
                  Destroy_Block.SetActive(true);
                  SoundDelete.Play();
                //Ломание ЗЕМЛИ и ГРЯЗИ для разных инструментов
                if ((GetComponent<Block_information>().id == 0 || GetComponent<Block_information>().id == 1) && Coll.GetComponent<Cursor_>().id_cursor == 24)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Grass_with_Wood");
                }
                if ((GetComponent<Block_information>().id == 0 || GetComponent<Block_information>().id == 1) && Coll.GetComponent<Cursor_>().id_cursor == 29)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Grass_with_Stone");
                }
                if ((GetComponent<Block_information>().id == 0 || GetComponent<Block_information>().id == 1) && Coll.GetComponent<Cursor_>().id_cursor == 34)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Grass_with_Iron");
                }
                //Ломание Булыжника, Камня и Угля для разных инструментов
                if ((GetComponent<Block_information>().id == 2 || GetComponent<Block_information>().id == 6 || GetComponent<Block_information>().id == 19) && Coll.GetComponent<Cursor_>().id_cursor == 23)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Stone_with_Wood");
                }
                if ((GetComponent<Block_information>().id == 2 || GetComponent<Block_information>().id == 6 || GetComponent<Block_information>().id == 19) && Coll.GetComponent<Cursor_>().id_cursor == 28)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Stone_with_Stone");
                }
                if ((GetComponent<Block_information>().id == 2 || GetComponent<Block_information>().id == 6 || GetComponent<Block_information>().id == 19) && Coll.GetComponent<Cursor_>().id_cursor == 33)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Stone_with_Iron");
                }
                //Ломание всего ДЕРЕВА и ВЕРСТАКА
                if ((GetComponent<Block_information>().id == 3 || GetComponent<Block_information>().id == 10 || GetComponent<Block_information>().id == 11 || GetComponent<Block_information>().id == 21) && Coll.GetComponent<Cursor_>().id_cursor == 22)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Wood_with_Wood");
                }
                if ((GetComponent<Block_information>().id == 3 || GetComponent<Block_information>().id == 10 || GetComponent<Block_information>().id == 11 || GetComponent<Block_information>().id == 21) && Coll.GetComponent<Cursor_>().id_cursor == 27)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Wood_with_Stone");
                }
                if ((GetComponent<Block_information>().id == 3 || GetComponent<Block_information>().id == 10 || GetComponent<Block_information>().id == 11 || GetComponent<Block_information>().id == 21) && Coll.GetComponent<Cursor_>().id_cursor == 32)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Wood_with_Iron");
                }
                //Ломание ПЕСКА и ГРАВИЯ
                if ((GetComponent<Block_information>().id == 5 || GetComponent<Block_information>().id == 8) && Coll.GetComponent<Cursor_>().id_cursor == 24)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Sand_with_Wood");
                }
                if ((GetComponent<Block_information>().id == 5 || GetComponent<Block_information>().id == 8) && Coll.GetComponent<Cursor_>().id_cursor == 29)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Sand_with_Stone");
                }
                if ((GetComponent<Block_information>().id == 5 || GetComponent<Block_information>().id == 8) && Coll.GetComponent<Cursor_>().id_cursor == 34)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Sand_with_Iron");
                }
                //Ломание ТРАВЫ, ЛИСТВЫ, ГРИБОВ, ЦВЕТОВ и т.д.
                if ((GetComponent<Block_information>().id == 7 || GetComponent<Block_information>().id == 9 || GetComponent<Block_information>().id == 13 || GetComponent<Block_information>().id == 14 || GetComponent<Block_information>().id == 15 || GetComponent<Block_information>().id == 16 || GetComponent<Block_information>().id == 17 || GetComponent<Block_information>().id == 18) && (Coll.GetComponent<Cursor_>().id_cursor == 24 || Coll.GetComponent<Cursor_>().id_cursor == 29 || Coll.GetComponent<Cursor_>().id_cursor == 34))
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Seedlight_with_any");
                }
                //Ломание ЖЕЛЕЗА
                if (GetComponent<Block_information>().id == 20 && Coll.GetComponent<Cursor_>().id_cursor == 23)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Iron_with_Wood");
                }
                if (GetComponent<Block_information>().id == 20 && Coll.GetComponent<Cursor_>().id_cursor == 28)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Iron_with_Stone");
                }
                if (GetComponent<Block_information>().id == 20 && Coll.GetComponent<Cursor_>().id_cursor == 33)
                {
                    Destroy_Block.GetComponent<Animator>().Play("Base Layer.Destroy_Iron_with_Iron");
                }
            }
            else if(Input.GetMouseButtonUp(0) && GameObject.Find("Player").GetComponent<Player>().gamemode == 0)
            {
                Destroy_Block.SetActive(false);
                SoundDelete.Stop();
            }

            if(Input.GetMouseButtonDown(1) && GameObject.Find("Player").GetComponent<Player>().gamemode == 0)
            {
                //Если это верстак тогда я открываю UI верстака
                if (gameObject.GetComponent<Block_information>().id == 21)
                {
                    GameObject.Find("Cursor").SetActive(false);
                    GameObject.Find("Inventory_massive").GetComponent<Inventory>().Inventory_Visible = GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().Worckbench.GetComponent<Inventory_vis>();
                    GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().ChangeInventoryVisible();
                    GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().OpenInventory();
                }
                else if(gameObject.GetComponent<Block_information>().id == 41)
                {
                    GameObject.Find("Cursor").SetActive(false);
                    GameObject.Find("InventoryGameAndChest").GetComponent<InventoryGameAndChest>().InventoryChest = gameObject;
                    GameObject.Find("InventoryGameAndChest").GetComponent<InventoryGameAndChest>().LoadAllInventory();

                    GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().ChangeInventoryVisibleChest();
                    GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().OpenInventory();
                }
                else if(gameObject.GetComponent<Block_information>().id == 42)
                {
                    GameObject.Find("Cursor").SetActive(false);
                    GameObject.Find("InventoryGameAndFurnace").GetComponent<Inventory_Furnace>().InventoryFurnace = gameObject;
                    GameObject.Find("InventoryGameAndFurnace").GetComponent<Inventory_Furnace>().LoadAllInventory();

                    GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().ChangeInventoryVisibleFurnace();
                    GameObject.Find("CanvasPlayer").GetComponent<Menu_Pause>().OpenInventory();
                }
            }
        }
        if(Coll.name == "DeletedObject" && gameObject.GetComponent<SpriteRenderer>().sortingLayerName != "Block_Layer_2")
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cursor")
        {
            Destroy_Block.SetActive(false);
            SoundDelete.Stop();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cursor")
        {
            Destroy_Block.SetActive(false);
            SoundDelete.Stop();
        }
    }

    void Delete_Object()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sortingLayerName != "Block_Layer_2")
        {
            Destroy(gameObject);
        }
    }
}
