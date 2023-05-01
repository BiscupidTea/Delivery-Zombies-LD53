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

    [SerializeField] private Canvas TextAdvisor;

    public AudioManager audioManager;

    [Header("House Cold Down")]

    [SerializeField] private float maxHouseTimer = 120f;

    private float houseTimer = 0;

    private bool starColdDown = false;

    private bool isCollision = false;

    void Start()
    {
        houseTimer = maxHouseTimer;
        TextAdvisor.gameObject.SetActive(false);
    }

    void Update()
    {
        DeliveryLogic();
        HouseTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (starColdDown == false && pM.CheckCurrentPackages())
            {
                TextAdvisor.gameObject.SetActive(true);
            }
            else
            {
                TextAdvisor.gameObject.SetActive(false);
            }
            isCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextAdvisor.gameObject.SetActive(false);
            isCollision = false;
        }
    }

    public void DeliveryLogic()
    {
        if (inputManager.CheckDeliveryInput())
        {
            if (isCollision == true && starColdDown == false && pM.CheckCurrentPackages())
            {
                starColdDown = true;

                TextAdvisor.gameObject.SetActive(false);
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
