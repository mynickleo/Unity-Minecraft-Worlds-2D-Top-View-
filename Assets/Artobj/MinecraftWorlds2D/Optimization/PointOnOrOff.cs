using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOnOrOff : MonoBehaviour
{
    public GameObject point;
    public int count = 1;

    public GameObject DeletedObjectedGame;
    public void Start()
    {
        StartCoroutine("CheckDeletedObjects");
    }

    IEnumerator CheckDeletedObjects()

    {
        while (count == 1)
        {
            yield return new WaitForSeconds(1);
            if (GameObject.Find("DeletedObject_") == null)
            {
                count = 0;
                if (Mathf.Abs(gameObject.transform.position.x) == 0)
                {
                    if (Mathf.Abs(gameObject.transform.position.y - GameObject.Find("Player").transform.position.y) < 35)
                    {
                        point.SetActive(true);
                    }
                    else
                    {
                        point.SetActive(false);
                    }
                }
                else if (Mathf.Abs(gameObject.transform.position.y) == 0)
                {
                    if ((Mathf.Abs(gameObject.transform.position.x - GameObject.Find("Player").transform.position.x) < 35)){

                    }
                    else
                    {
                        point.SetActive(false);
                    }
                }
                else if (Mathf.Abs(gameObject.transform.position.x - GameObject.Find("Player").transform.position.x) < 35 && Mathf.Abs(gameObject.transform.position.y - GameObject.Find("Player").transform.position.y) < 35)
                {

                }
                else {
                    point.SetActive(false);
                }
            }
            else
            {
                StartCoroutine("CheckDeletedObjects");
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            point.SetActive(true);
            GameObject DeletedObj = Instantiate(DeletedObjectedGame, transform.position, Quaternion.identity);
            DeletedObj.name = "DeletedObject_";
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            point.SetActive(false);
        }
    }
}
