using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadChunkCaves : MonoBehaviour
{
    //Специальный скрипт для загрузки локации пещеры

    //Помечаю себе или тем, кто будет исследоват код ---> пещеры не стоит делать бесконечными, так как при существующих возможностях - много триггеров (твердых блоков) = мало фпс
    //Лучше ограничить пространство и проработать механику

    public Chunk ChunkPrefab;

    public Transform Player;

    public GameObject DeletedObject;

    public GameObject StoneWalls;

    public GameObject StoneClose;

    public GameObject LocationPoint;

    float SeedWorld;
    float Zoom = 10f;
    //В зависимости от сида и координат будет спавниться либо 1, либо 2 чанка
    int how_chunks = 0;

    public int Drawing_distance = 14;

    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;

    float coordinate_x = 0;
    float coordinate_y = 0;
    public void Start()
    {
        SeedWorld = GameObject.Find("SeedWorld").GetComponent<FindSeed>().SeedWorld_;
        float Count_MathfPerlin = Mathf.PerlinNoise((transform.position.x + SeedWorld) / Zoom, (transform.position.y + SeedWorld) / Zoom);
        how_chunks = 1;

        StartCoroutine("LoadPositionAndGenerate");
    }
    void LateUpdate()
    {
        if (GameObject.Find("DeletedObject_") == null)
        {
            foreach (Transform child in GameObject.Find("0_(Clone)").GetComponentInChildren<Transform>())
            {
                Vector3 LookAt = Camera.main.transform.position;
                if ((child.position.x < LookAt.x + Drawing_distance) && (child.position.y < LookAt.y + Drawing_distance) && (child.position.x > (LookAt.x - Drawing_distance)) && (child.position.y > (LookAt.y - Drawing_distance)))
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator LoadPositionAndGenerate()

    {
        yield return new WaitForSeconds(1);
        GenerationStart(how_chunks);
    }
    void GenerationStart(int how_chunks)
    {
        if (how_chunks == 1)
        {
            Chunk NewChunk = Instantiate(ChunkPrefab, new Vector3(Mathf.Round(Player.position.x), Mathf.Round(Player.position.y)), Quaternion.identity);
            NewChunk.transform.SetParent(gameObject.transform);

            GameObject StoneClose_ = Instantiate(StoneClose, new Vector3(Mathf.Round(Player.position.x), Mathf.Round(Player.position.y + 21)), Quaternion.identity);
            StoneClose_ = Instantiate(StoneClose, new Vector3(Mathf.Round(Player.position.x), Mathf.Round(Player.position.y - 21)), Quaternion.identity);
            GameObject StoneClose__ = Instantiate(StoneClose, new Vector3(Mathf.Round(Player.position.x - 21), Mathf.Round(Player.position.y + 1)), Quaternion.identity);
            StoneClose__.transform.Rotate(0, 0, 90);
            StoneClose__ = Instantiate(StoneClose, new Vector3(Mathf.Round(Player.position.x + 20), Mathf.Round(Player.position.y + 1)), Quaternion.identity);
            StoneClose__.transform.Rotate(0, 0, 90);

            GameObject StoneWalls_ = Instantiate(StoneWalls, new Vector3(Mathf.Round(Player.position.x + 50), Mathf.Round(Player.position.y), 10), Quaternion.identity);
            StoneWalls_ = Instantiate(StoneWalls, new Vector3(Mathf.Round(Player.position.x - 50), Mathf.Round(Player.position.y), 10), Quaternion.identity);
            StoneWalls_ = Instantiate(StoneWalls, new Vector3(Mathf.Round(Player.position.x), Mathf.Round(Player.position.y + 50), 10), Quaternion.identity);
            StoneWalls_ = Instantiate(StoneWalls, new Vector3(Mathf.Round(Player.position.x), Mathf.Round(Player.position.y - 50), 10), Quaternion.identity);
            StoneWalls_ = Instantiate(StoneWalls, new Vector3(Mathf.Round(Player.position.x), Mathf.Round(Player.position.y), 10), Quaternion.identity);

            GameObject gameObjectNew = Instantiate(DeletedObject, NewChunk.transform.position, Quaternion.identity);
            gameObjectNew.name = "DeletedObject_";
        }
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
            GameObject PointBackToWorld = Instantiate(LocationPoint, new Vector3(coordinate_x, coordinate_y), Quaternion.identity);
        }

    }
}
