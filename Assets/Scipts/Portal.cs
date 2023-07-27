using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string SceneName;
    protected override void OnCollide(Collider2D Coll)
    {
        if(Coll.name == "Player")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
