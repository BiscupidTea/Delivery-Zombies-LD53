using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseButtons;

    private void Start()
    {
        coins = 0;

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsSO[i].gameObject.SetActive(true);
            coinsUI.text = "Coins: " + coins.ToString();
            LoadPanels();
            //CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
       for (int i = 0;i < shopItemsSO.Length; i++)
       {
            shopPanels[i].titleText.text = shopItemsSO[i].title;
            shopPanels[i].descriptionText.text = shopItemsSO[i].description;
            shopPanels[i].costText.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
       }
    }

    public void AddCoins()
    {
        coins++;
        coinsUI.text = "Coins " + coins.ToString();
        //CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost)
                myPurchaseButtons[i].interactable = true;
            else
                myPurchaseButtons[i].interactable = false;
        }
    }
}
