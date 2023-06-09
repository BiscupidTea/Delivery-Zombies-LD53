using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MainHouse : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject StoreCanvas;
    [SerializeField] private GameObject TextStore;
    [SerializeField] private GameObject PositionHouse;
    [SerializeField] private GameObject Player;
    [SerializeField] private PacksManager PlayerPacks;

    private bool insideOpenStore;

    private void Start()
    {
        StoreCanvas.SetActive(false);
        TextStore.SetActive(false);
    }

    private void Update()
    {
        if (insideOpenStore)
        {
            if (inputManager.CheckOpenStoreInput())
            {
                ActivateShop();
            }
        }
    }

    private void ActivateShop()
    {
        StoreCanvas.SetActive(true);

        Time.timeScale = 0;
    }

    public void ExitShop()
    {
        Time.timeScale = 1;
        StoreCanvas.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextStore.SetActive(true);
            PlayerPacks.ResetFullPackage();
            insideOpenStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextStore.SetActive(false);
        insideOpenStore = false;
    }
}
