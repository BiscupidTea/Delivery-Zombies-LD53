using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private Canvas PauseMenu;

    [SerializeField] private Canvas BasicPause;
    [SerializeField] private Canvas OptionsPause;

    private bool gamePause = false;

    private bool gameOptions = false;

    private void Start()
    {
        PauseMenu.enabled = false;
        BasicPause.enabled = false;
        OptionsPause.enabled = false;
    }
    private void Update()
    {
        if (!gameOptions)
        {
            ActivatePauseMenu();
        }
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
        BasicPause.enabled = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        gamePause = false;
        PauseMenu.enabled = false;
        BasicPause.enabled = false;
    }

    public void ActiveOptions()
    {
        gameOptions = true;
        BasicPause.enabled = false;
        OptionsPause.enabled = true;
    }

    public void DesactiveOptions()
    {
        gameOptions = false;
        BasicPause.enabled = true;
        OptionsPause.enabled = false;
    }
}
