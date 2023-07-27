using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] GameObject steveCap;
    int capIsTrue = 1;

    private BoxCollider2D BoxCollider; 
    private Vector3 move;
    private RaycastHit2D hit;
    private Rigidbody2D body;
    public float MainActorSpeed = 0.12f;

    public Sprite Sprite_right;
    public Sprite Sprite_left;
    public Sprite Sprite_back;
    public Sprite Sprite_up;
    public Sprite Sprite_damage;

    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;

    float coordinate_x = 0;
    float coordinate_y = 0;

    //Health//
    public int health = 100; //У игрока здоровье будет равно 100
    public GameObject[] HealthMassiveVisible = new GameObject[10]; //Графическое отображение
    //-->

    //Inventory//
    public Inventory Inventory_massive;
    //-->

    //Game variable//
    public int gamemode = 0;
    //<--//
    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();

        body = GetComponent<Rigidbody2D>();

        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats";
        if (File.Exists(Folder))
        {
            StreamReader TransformPosition = new StreamReader(Folder, false);
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                    coordinate_x = (float)Convert.ToDouble(TransformPosition.ReadLine());
                else if (i == 1)
                    coordinate_y = (float)Convert.ToDouble(TransformPosition.ReadLine());
            }
            TransformPosition.Close();
            transform.position = new Vector3(coordinate_x, coordinate_y);
        }
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Player";

        int health_player = -1;
        if (File.Exists(Folder))
        {
            StreamReader GameStatsPlayer = new StreamReader(Folder, false);
            int i = 0;
            while (GameStatsPlayer.EndOfStream != true)
            {
                if (i == 0) health_player = Convert.ToInt32(GameStatsPlayer.ReadLine());
            }

            if (health_player != -1)
            {
                SetHealth(health_player);
            }
            else
            {
                SetHealth(100);
            }
        }
        else
        {
            SetHealth(100);
        }
    }

    private void FixedUpdate()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        if (move.x > 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprite_right;
        }
        else if (move.x < 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprite_left;
        }
        if (move.y > 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprite_up;
        }
        else if (move.y < 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprite_back;
        }
        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(0, move.y), Mathf.Abs(move.y * 0.5f), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(0, move.y * MainActorSpeed, 0);
        }
        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(move.x, 0), Mathf.Abs(move.x * 0.5f), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(move.x * MainActorSpeed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (capIsTrue == 0)
            {
                steveCap.gameObject.SetActive(true);
                capIsTrue = 1;
            }
            else
            {
                steveCap.gameObject.SetActive(false);
                capIsTrue = 0;
            }
        }
    }

    public void SetHealth(int health_player)
    {
        health = health_player;
        int j = 0;
        for(int i = 0; i <= health; i = i + 10)
        {
            HealthMassiveVisible[j].GetComponent<Health_full>().Health.SetActive(true);
            j++;
        }
    }

    IEnumerator SetNormalSprite()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprite_right;
        steveCap.gameObject.SetActive(true);
    }
    public void HealthMinus(int health_minus)
    {
        steveCap.gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprite_damage;
        StartCoroutine("SetNormalSprite");
        health = health - health_minus;
        if(health == 90)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 80)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 70)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 60)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[6].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 50)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[6].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[5].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 40)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[6].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[5].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[4].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 30)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[6].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[5].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[4].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[3].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 20)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[6].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[5].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[4].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[3].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[2].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 10)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[6].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[5].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[4].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[3].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[2].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[1].GetComponent<Health_full>().Health.SetActive(false);
        }
        else if(health == 0)
        {
            HealthMassiveVisible[9].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[8].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[7].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[6].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[5].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[4].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[3].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[2].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[1].GetComponent<Health_full>().Health.SetActive(false);
            HealthMassiveVisible[0].GetComponent<Health_full>().Health.SetActive(false);
            GameEnd();
            SceneManager.LoadScene("GameMenu");
        }
    }

    public void HealthPlus(int health_plus)
    {
        health = health + health_plus;
        int j = 0;
        for (int i = 0; i <= health; i = i + 10)
        {
            HealthMassiveVisible[j].GetComponent<Health_full>().Health.SetActive(true);
            j++;
        }
    }

    public void GameEnd()
    {
        //Обнуляем весь инвентарь, выбрасываем предметы и сохраняем это *INVENTORY_END_GAME*
        for(int i = 0; i < Inventory_massive.ItemsInventory.Length; i++)
        {
            if(Inventory_massive.ItemsInventory[i] != null)
            {
                //Выбрасываем предмет и кладем в сборщик мусора
                GameObject ImageThisBlock = Instantiate(Inventory_massive.ItemsInventory[i].gameObject, new Vector3(transform.position.x, transform.position.y + 1f), Quaternion.identity);
                //Предмет можно собрать
                ImageThisBlock.GetComponent<Item>().name = "Item_collect";
                //
                ImageThisBlock.GetComponent<Item>().amount = 1;
                ImageThisBlock.GetComponent<Animation>().Play("Image_Grass");
                ImageThisBlock.transform.SetParent(GameObject.Find("Garbage_Collector").transform);

                Inventory_massive.ItemsInventory[i] = null;
            }
        }
        Inventory_massive.SaveInventoryToFile(); //сохраняем
        //--> *INVENTORY_END_GAME*

        //Обновляем хотбар
        GameObject.Find("HotBar").GetComponent<CellScript_>().UpdateCellsHotbar();

        //Перемещаем игрока в начальные координаты
        transform.position = new Vector3(0, 0);

        //делаем здоровье на 100
        health = 100;

        //сохраняем все
        SaveGameStats();


    }

    public void SaveGameStats()
    {
        GameObject.Find("Inventory_massive").GetComponent<Inventory>().SaveInventoryToFile();
        int TriggerOrNot = 0;
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();

        if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D")
        {
            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats";

            StreamWriter GameStats = new StreamWriter(Folder, false);
            GameStats.Close();

            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Player";
            StreamWriter GameStatsPlayer = new StreamWriter(Folder, false);
            GameStatsPlayer.WriteLine(GameObject.Find("Player").GetComponent<Player>().health); //здоровье записать нужно
            GameStatsPlayer.Close();

            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Cave";

            StreamWriter GameStats_ = new StreamWriter(Folder, false);
            GameStats_.WriteLine(GameObject.Find("Point Light").transform.position.z);
            GameStats_.Close();

            string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CreateBlocks";

            StreamWriter GenerationWorld = new StreamWriter(PathToWorld, false);
            foreach (Transform children in GameObject.Find("BuildCreatedBlocks").GetComponentInChildren<Transform>())
            {
                coordinate_x = children.position.x;
                coordinate_y = children.position.y;
                if (children.gameObject.GetComponent<BoxCollider2D>().isTrigger == true)
                {
                    TriggerOrNot = 1;
                }
                else
                {
                    TriggerOrNot = 0;
                }
                GenerationWorld.WriteLine(coordinate_x);
                GenerationWorld.WriteLine(coordinate_y);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().id);
                GenerationWorld.WriteLine(TriggerOrNot);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().ChestVariable);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().FurnaceVariable);
            }

            GenerationWorld.Close();
        }
        else if (SceneManager.GetActiveScene().name == "Minecraft_Worlds2D_Cave")
        {
            Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats_Cave";

            StreamWriter GameStats = new StreamWriter(Folder, false);
            GameStats.WriteLine(GameObject.Find("GameObjectPoint").transform.position.z);
            GameStats.Close();

            string PathToWorld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\CreateBlocks_Cave";

            StreamWriter GenerationWorld = new StreamWriter(PathToWorld, false);
            foreach (Transform children in GameObject.Find("BuildCreatedBlocks").GetComponentInChildren<Transform>())
            {
                coordinate_x = children.position.x;
                coordinate_y = children.position.y;
                if (children.gameObject.GetComponent<BoxCollider2D>().isTrigger == true)
                {
                    TriggerOrNot = 1;
                }
                else
                {
                    TriggerOrNot = 0;
                }
                GenerationWorld.WriteLine(coordinate_x);
                GenerationWorld.WriteLine(coordinate_y);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().id);
                GenerationWorld.WriteLine(TriggerOrNot);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().ChestVariable);
                GenerationWorld.WriteLine(children.GetComponent<Block_information>().FurnaceVariable);
            }

            GenerationWorld.Close();
        }
    }
}
