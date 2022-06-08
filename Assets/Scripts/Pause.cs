using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is just used to turn the pause menu on/off.
public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Paused()
    {
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
    }
}