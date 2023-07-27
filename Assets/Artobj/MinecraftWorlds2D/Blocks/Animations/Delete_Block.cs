using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delete_Block : MonoBehaviour
{
    public GameObject ParentBlock;

    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;

    public GameObject Image_Block;
    void Deleted_Block()
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
        GameObject ImageThisBlock = Instantiate(Image_Block, ParentBlock.transform.position, Quaternion.identity);
        //Предмет можно собрать
        ImageThisBlock.GetComponent<Item>().name = "Item_collect";
        //
        ImageThisBlock.GetComponent<Item>().amount = 1;
        ImageThisBlock.GetComponent<Animation>().Play("Image_Grass");
        ImageThisBlock.transform.SetParent(GameObject.Find("Garbage_Collector").transform);
        Destroy(ParentBlock);
        GameObject.Find("HotBar").GetComponent<CellScript_>().UpdateONECellHotbarEndurance(GameObject.Find("CanvasPlayer").GetComponent<InvActive>().active);
        GameObject.Find("Cursor").GetComponent<Cursor_>().name = "";
    }
}
