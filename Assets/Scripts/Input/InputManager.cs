using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Gun[] guns;
    public AudioManager audioManager;

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

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            audioManager.PlayPlayerWalkSFX();
        }
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

    public bool CheckOpenStoreInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
            return true;
        else
            return false;
    }

    public int ChangeWeapon()
    {
        int weaponNumber;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponNumber = 1;
            Debug.Log("ChangeWeapon");

            return weaponNumber;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponNumber = 2;
            Debug.Log("ChangeWeapon");
            return weaponNumber;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponNumber = 3;
            Debug.Log("ChangeWeapon");
            return weaponNumber;
        }

        return 0;
    }
}
