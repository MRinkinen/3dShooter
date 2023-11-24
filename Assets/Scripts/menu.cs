using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("SampleScene");
        Cursor.visible = false;

    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
}
