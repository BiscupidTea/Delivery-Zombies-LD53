using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject firePivotsHolder;

    private void Start()
    {
        guns[0].SetActive(true);
        guns[1].SetActive(false);
        guns[2].SetActive(false);
    }

    private void Update()
    {
        GetWeapon();
    }

    private void GetWeapon()
    {
        switch (inputManager.ChangeWeapon())
        {
            case 1:
                firePivotsHolder.SetActive(false);
                guns[0].SetActive(true);
                guns[1].SetActive(false);
                guns[2].SetActive(false);
                break;
            case 2:
                firePivotsHolder.SetActive(true);
                guns[0].SetActive(false);
                guns[1].SetActive(true);
                guns[2].SetActive(false);
                break;
            case 3:
                firePivotsHolder.SetActive(false);
                guns[0].SetActive(false);
                guns[1].SetActive(false);
                guns[2].SetActive(true);
                break;
            default:
                break;
        }
    }
}
