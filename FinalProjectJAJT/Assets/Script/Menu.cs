using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void iniciar()
    {
        LoadLevel.NivelLoad("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Me presiono");
    }

}
