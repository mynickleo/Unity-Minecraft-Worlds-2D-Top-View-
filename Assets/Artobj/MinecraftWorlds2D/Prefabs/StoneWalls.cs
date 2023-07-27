using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWalls : MonoBehaviour
{
    public Transform lookAt;

    public void Start()
    {
        StartCoroutine("CheckPlayerPosition");
    }

    IEnumerator CheckPlayerPosition()
    {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(lookAt.position.x, lookAt.position.y, transform.position.z);
    }

        public void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = new Vector3 (lookAt.position.x, lookAt.position.y, transform.position.z);
    }
}
