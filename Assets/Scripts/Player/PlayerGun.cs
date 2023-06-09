using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject firePivotsHolder;

    [SerializeField] private ShopItemSO shotgun;
    [SerializeField] private ShopItemSO rifle;

    [SerializeField] private GameObject playerSprite;
    [SerializeField] private Sprite[] playerSprites;

    private void Start()
    {
        guns[0].SetActive(true);
        guns[1].SetActive(false);
        guns[2].SetActive(false);


        playerSprite.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
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
                playerSprite.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
                break;
            case 2:
                if (shotgun.bought)
                {
                    firePivotsHolder.SetActive(true);
                    guns[0].SetActive(false);
                    guns[1].SetActive(true);
                    guns[2].SetActive(false);
                    playerSprite.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
                }
                break;
            case 3:
                if (rifle.bought)
                {
                    firePivotsHolder.SetActive(false);
                    guns[0].SetActive(false);
                    guns[1].SetActive(false);
                    guns[2].SetActive(true);
                    playerSprite.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                }                    
                break;
            default:
                break;
        }
    }
}
