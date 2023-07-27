using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    public void OnClick_()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
