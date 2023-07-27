using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk_Script : MonoBehaviour
{
    public Transform PlayerPosition;
    public GameObject PointChunk;

    public void Start()
    {
        StartCoroutine("CheckPlayerPosition");
    }

    IEnumerator CheckPlayerPosition()
    {
        yield return new WaitForSeconds(1);
        transform.position = PlayerPosition.position;

        GameObject gameObjectNew = Instantiate(PointChunk, PlayerPosition.position, Quaternion.identity);
        gameObjectNew.name = "Point";
        gameObjectNew.transform.SetParent(gameObject.transform);
        gameObjectNew.SetActive(true);

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(GameObject.Find("Point"));

        transform.position = PlayerPosition.position;
        GameObject gameObjectNew = Instantiate(PointChunk, PlayerPosition.position, Quaternion.identity);
        gameObjectNew.name = "Point";
        gameObjectNew.transform.SetParent(gameObject.transform);
        gameObjectNew.SetActive(true);
    }
}
