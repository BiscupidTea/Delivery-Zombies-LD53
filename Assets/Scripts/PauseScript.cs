using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private void Update()
    {
        ActivatePauseMenu();
    }

    private void ActivatePauseMenu()
    {
        if (inputManager.CheckPauseInput())
        {

        }
        
    }


}
