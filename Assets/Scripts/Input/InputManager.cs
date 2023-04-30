using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        CheckDeliveryInput();
        GetPlayerMovementInput();
    }

    public bool CheckDeliveryInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
            return true;
        else
            return false;
    }

    public Vector2 GetPlayerMovementInput()
    {
        Vector2 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        return movement;
    }

    public bool CheckShootingInput()
    {
        if (Input.GetMouseButton(0))
            return true;
        else
            return false;
    }

    public bool CheckArrowInput()
    {
        if (Input.GetMouseButton(1))
            return true;
        else
            return false;
    }

    public bool CheckPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            return true;
        else
            return false;
    }
}
