using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private InputManager inputManager;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject house;

    [SerializeField] private GameObject warningImage;

    [SerializeField] private CoinManager cM;

    [SerializeField] private PacksManager pM;

    public AudioManager audioManager;

    [Header("House Cold Down")]

    [SerializeField] private float maxHouseTimer = 5.0f;

    private float houseTimer = 0;

    private bool starColdDown = false;

    private bool isCollision = false;

    void Start()
    {
        houseTimer = maxHouseTimer;
    }

    void Update()
    {
        if (pM.CheckCurrentPackages())
        {
            DeliveryLogic();
            HouseTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = false;
        }
    }

    public void DeliveryLogic()
    {
        if (inputManager.CheckDeliveryInput())
        {
            if (isCollision == true && starColdDown == false)
            {
                starColdDown = true;

                warningImage.SetActive(false);

                //if (pM.CheckCurrentPackages())
                //{
                    pM.RemovePackage(1);
                    var rnd = Random.Range(25, 75);
                    cM.GetMoney(rnd);
                    Debug.Log("Paquete Entregado");
                audioManager.PlaySFX(audioManager.playerDelivery);
                //}
                //else
                //    warningImage.SetActive(false);
            }
        }       
    }

    private void HouseTimer() 
    {
        if (starColdDown == true)
        {
            houseTimer -= Time.deltaTime;

            if (houseTimer <= 0)
            {
                //if (pM.CheckCurrentPackages())
                //{
                    warningImage.SetActive(true);
                //}
                starColdDown = false;
                houseTimer = maxHouseTimer;
            }
        }
    }
}
