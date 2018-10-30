using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScene : MonoBehaviour
{


    public string playMenuLevel;
    public string playGameLevel;


    public void MainMenu()
    {
        Application.LoadLevel(playMenuLevel);
    }

    public void TryAgain()
    {
        Application.LoadLevel(playGameLevel);
    }
}