using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private Canvas PauseMenu;

    private bool gamePause = false;

    private void Start()
    {
        PauseMenu.enabled = false;
    }
    private void Update()
    {
        ActivatePauseMenu();
    }

    private void ActivatePauseMenu()
    {
        if (inputManager.CheckPauseInput())
        {
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        gamePause = true;
        PauseMenu.enabled = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        gamePause = false;
        PauseMenu.enabled = false;
    }
}
