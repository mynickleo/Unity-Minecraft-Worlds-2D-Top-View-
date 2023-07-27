using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour
{
    public Transform lookAt;

    public void Start()
    {
        StartCoroutine("CheckPlayerPosition");
    }

    IEnumerator CheckPlayerPosition()
    {
        yield return new WaitForSeconds(1);
        transform.position = lookAt.position;
    }
        public void OnTriggerExit2D(Collider2D collision)
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
