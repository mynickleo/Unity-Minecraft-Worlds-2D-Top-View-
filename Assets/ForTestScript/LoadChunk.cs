using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadChunk : MonoBehaviour
{
    public Chunk ChunkPrefab;
    public Transform Player;

    public GameObject DeletedObject;

    private List<Chunk> Chunks = new List<Chunk>();

    float deltaX = 0;
    float deltaY = 0;

    int count_x = 41;
    int count_y = 41;

    int countExist = 0;

    //ѕеременные необходимые дл€ загрузки из файла//
    string World = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\World_Name.txt";
    string NameWorld;
    string Folder;
    int some_action = 0;
    //////////////////////////////////////////////////
    public int CreatedChunks = 0;

    public int Drawing_distance = 12;

    private int generated_chunk = 0;

    public void Start()
    {
        //ѕри старте мне нужно будет узнавать позицию всех точек дл€ воссоздани€ местности
        //»наче при воссоздании местности по позиции игрока местность не сохран€етс€

        //ѕроще говор€ нужно будет загружать позицию всех чанков
        StreamReader ReaderWorld = new StreamReader(World, false);
        NameWorld = ReaderWorld.ReadLine();
        ReaderWorld.Close();
        Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraftworlds2D\Save\" + NameWorld + @"\GameStats";
        if (File.Exists(Folder))
        {
            StreamReader TransformPosition = new StreamReader(Folder, false);
            //„итаем пока есть строки
            while (!TransformPosition.EndOfStream)
            {
                //ћне нужно пропустить первые три строчки, так как это - позици€ игрока и позици€ света
                if (some_action < 3)
                {
                    TransformPosition.ReadLine();
                    some_action++;
                }
                else
                {
                    if (some_action == 3) deltaX = (float)Convert.ToDouble(TransformPosition.ReadLine());
                    else if (some_action == 4)
                    {
                        deltaY = (float)Convert.ToDouble(TransformPosition.ReadLine());
                    }
                    if (some_action != 4) some_action++;
                    else some_action = 3;
                }
            }
        }
        if(CreatedChunks == 0)
        {
            Chunk NewChunk = Instantiate(ChunkPrefab, new Vector3(Mathf.Round(deltaX), Mathf.Round(deltaY)), Quaternion.identity);
            Instantiate(DeletedObject, transform.position, Quaternion.identity);
            NewChunk.GetComponent<Chunk>().countChunk = 1;
            NewChunk.transform.SetParent(gameObject.transform);
            Chunks.Add(NewChunk);
        }
    }

    void LateUpdate()
    {
        for (int i = 0; i <= Chunks.Count - 1; i++)
        {
            if (Chunks[i].GetComponent<Chunk>().countChunk == 1)
            {
                SpawnChunks(i);
            }
            if (GameObject.Find("DeletedObject_") == null && Chunks[i].GetComponent<Spawn_Point>().Generated == 1)
            {
                //включение чанков, если игрок находитс€ на них
                if (Mathf.Abs(Chunks[i].transform.position.x - Player.position.x) <= 20 && Mathf.Abs(Chunks[i].transform.position.y - Player.transform.position.y) <= 20) Chunks[i].gameObject.SetActive(true);
                else if (Mathf.Abs(Chunks[i].transform.position.y - Player.position.y) <= 20 && Mathf.Abs(Chunks[i].transform.position.x - Player.position.x) <= 20) Chunks[i].gameObject.SetActive(true);

                //выключение чанков, если игрок не находитс€ на них
                else if (Mathf.Abs(Chunks[i].transform.position.x - Player.position.x) >= 31 || Mathf.Abs(Chunks[i].transform.position.y - transform.position.y) >= 31) Chunks[i].gameObject.SetActive(false);
                foreach (Transform child in Chunks[i].gameObject.GetComponentInChildren<Transform>())
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
    }

    private void CreateMeshForChunk(int i)
    {
        // Create a new Mesh object
        Mesh mesh = new Mesh();

        // Create lists to store the vertices, edges, and faces of the mesh
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        // Loop through the blocks and add their vertices, edges, and faces to the lists
        foreach (Transform block in Chunks[i].gameObject.GetComponentInChildren<Transform>())
        {
            // Get the block's transform and sprite
            SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();

            // Add the block's vertices to the list
            vertices.Add(block.position + new Vector3(-0.5f, 0.5f));
            vertices.Add(block.position + new Vector3(0.5f, 0.5f));
            vertices.Add(block.position + new Vector3(-0.5f, -0.5f));
            vertices.Add(block.position + new Vector3(0.5f, -0.5f));

            // Calculate the indices of the block's vertices in the list
            int i0 = vertices.Count - 4;
            int i1 = vertices.Count - 3;
            int i2 = vertices.Count - 2;
            int i3 = vertices.Count - 1;

            // Add the block's faces to the list
            triangles.Add(i0);
            triangles.Add(i2);
            triangles.Add(i1);

            triangles.Add(i2);
            triangles.Add(i3);
            triangles.Add(i1);
        }

        // Assign the vertices, edges, and faces to the Mesh object
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        // Optimize the mesh for rendering
        mesh.Optimize();
    }
    
     public void SpawnChunks(int i)
    {
        deltaX = (Player.position.x - Chunks[i].transform.position.x);
        deltaY = (Player.position.y - Chunks[i].transform.position.y);

        if (deltaX > 0) count_x = 25;
        else count_x = -25;
        if (deltaY > 0) count_y = 25;
        else count_y = -25;

        deltaX = Mathf.Abs(deltaX);
        deltaY = Mathf.Abs(deltaY);

        generated_chunk = 0;

        for (int j = 0; j <= Chunks.Count - 1; j++)
        {
            if (Chunks[j].transform.position.x == Chunks[i].transform.position.x + count_x && Chunks[j].transform.position.y == Chunks[i].transform.position.y)
            {
                countExist = 1;
            }
        }
        if (deltaX > 5)
        {
            if (countExist != 1)
            {
                Chunk NewChunk = Instantiate(ChunkPrefab, new Vector3(Chunks[i].transform.position.x + count_x, Chunks[i].transform.position.y), Quaternion.identity);
                Chunks.Add(NewChunk);
                NewChunk.transform.SetParent(gameObject.transform);
                Instantiate(DeletedObject, NewChunk.transform.position, Quaternion.identity);
                generated_chunk = 1;
                if (Chunks[i].meshEnd == 0)
                {
                    CreateMeshForChunk(i);
                }
            }
        }

        countExist = 0;

        if (generated_chunk == 0)
        {
            for (int j = 0; j <= Chunks.Count - 1; j++)
            {
                if (Chunks[j].transform.position.y == Chunks[i].transform.position.y + count_y && Chunks[j].transform.position.x == Chunks[i].transform.position.x)
                {
                    countExist = 1;
                }
            }
            if (deltaY > 5)
            {
                if (countExist != 1)
                {
                    Chunk NewChunk = Instantiate(ChunkPrefab, new Vector3(Chunks[i].transform.position.x, Chunks[i].transform.position.y + count_y), Quaternion.identity);
                    Chunks.Add(NewChunk);
                    NewChunk.transform.SetParent(gameObject.transform);
                    Instantiate(DeletedObject, NewChunk.transform.position, Quaternion.identity);
                    generated_chunk = 1;
                    if (Chunks[i].meshEnd == 0)
                    {
                        CreateMeshForChunk(i);
                    }
                }
            }
        }

        countExist = 0;
        if (generated_chunk == 0)
        {
            for (int j = 0; j <= Chunks.Count - 1; j++)
            {
                if (Chunks[j].transform.position.x == Chunks[i].transform.position.x + count_x && Chunks[j].transform.position.y == Chunks[i].transform.position.y + count_y)
                {
                    countExist = 1;
                }
            }
            if (deltaX > 5 && deltaY > 5)
            {
                if (countExist != 1)
                {
                    Chunk NewChunk = Instantiate(ChunkPrefab, new Vector3(Chunks[i].transform.position.x + count_x, Chunks[i].transform.position.y + count_y), Quaternion.identity);
                    Chunks.Add(NewChunk);
                    NewChunk.transform.SetParent(gameObject.transform);
                    Instantiate(DeletedObject, NewChunk.transform.position, Quaternion.identity);
                    generated_chunk = 1;
                    if (Chunks[i].meshEnd == 0)
                    {
                        CreateMeshForChunk(i);
                    }
                }
            }
        }

        if (Chunks.Count > 6)
        {
            Destroy(Chunks[0].gameObject);
            Chunks.RemoveAt(0);
        }
        countExist = 0;
    }
}
