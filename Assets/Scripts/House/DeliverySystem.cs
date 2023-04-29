using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    [Header("References")] 
    
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject house;

    [SerializeField] private GameObject warningImage;

    [SerializeField] private CoinManager cM;

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
        if (Input.GetKeyDown(KeyCode.E) && isCollision == true && starColdDown == false)
        {
            starColdDown = true;

            warningImage.SetActive(false);

            cM.GetMoney(10);

            Debug.Log("Paquete Entregado");
        }

        if(starColdDown == true) 
        {
            houseTimer -= Time.deltaTime;

            if (houseTimer <= 0) 
            {
                warningImage.SetActive(true);
                starColdDown = false;
                houseTimer = maxHouseTimer;
            }
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
}
