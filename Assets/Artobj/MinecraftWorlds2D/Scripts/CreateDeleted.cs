using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDeleted : MonoBehaviour
{
    public GameObject DeletedObjectedGame;
    void Start()
    {
        Instantiate(DeletedObjectedGame, transform.position, Quaternion.identity);
    }
}
