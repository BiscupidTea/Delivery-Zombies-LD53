using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;

    public TMP_Text coinsUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseButtons;

    private void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsSO[i].gameObject.SetActive(true);
            coinsUI.text = "Coins: " + coinManager.actualsCoins.ToString();
            ResetUpgrades();
            LoadPanels();
           
            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
       for (int i = 0;i < shopItemsSO.Length; i++)
       {
            shopPanels[i].titleText.text = shopItemsSO[i].title;
            shopPanels[i].descriptionText.text = shopItemsSO[i].description;
            if (shopItemsSO[i].upgradable)
                shopPanels[i].costText.text = "Unlock level: " + (shopItemsSO[i].timesUpgraded + 1) +  "Coins: " + shopItemsSO[i].basePrice.ToString();
            else
                shopPanels[i].costText.text = "Coins: " + shopItemsSO[i].basePrice.ToString();

        }
    }

    public void PurchaseItem(int buttonNumber)
    {
        if (!shopItemsSO[buttonNumber].bought)
        {
            shopItemsSO[buttonNumber].lastPrice = shopItemsSO[buttonNumber].currentPrice;

            coinManager.actualsCoins -= shopItemsSO[buttonNumber].currentPrice;
            if (coinManager.actualsCoins <= 0)
            {
                coinManager.actualsCoins = 0;
            }
            coinsUI.text = "Coins " + coinManager.actualsCoins.ToString();               
            shopItemsSO[buttonNumber].currentPrice = shopItemsSO[buttonNumber].lastPrice * 2;

            if (shopItemsSO[buttonNumber].upgradable)
            {
                if (shopItemsSO[buttonNumber].timesUpgraded < shopItemsSO[buttonNumber].maxUpgrades)
                {
                    shopItemsSO[buttonNumber].timesUpgraded++;

                    

                    shopPanels[buttonNumber].costText.text = "Unlock level: " + (shopItemsSO[buttonNumber].timesUpgraded + 1) +
                    " Coins: " + shopItemsSO[buttonNumber].currentPrice.ToString();


                    if (shopItemsSO[buttonNumber].timesUpgraded == shopItemsSO[buttonNumber].maxUpgrades)
                    {
                        shopItemsSO[buttonNumber].bought = true;
                        shopPanels[buttonNumber].costText.text = "Upgraded to MaxLevel";
                    }
                }

            }           

            CheckPurchaseable();           
        }      
    }

    private void ResetUpgrades()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (shopItemsSO[i].upgradable)
            {
                shopItemsSO[i].bought = false;
                shopItemsSO[i].timesUpgraded = 0;
                shopItemsSO[i].currentPrice = shopItemsSO[i].basePrice;
                shopItemsSO[i].lastPrice = shopItemsSO[i].basePrice;
            }
        } 
    }

    public void AddCoins()
    {
        coinManager.GetMoney(100);
        coinsUI.text = "Coins " + coinManager.actualsCoins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (!shopItemsSO[i].bought)
            {
                if (coinManager.actualsCoins >= shopItemsSO[i].basePrice)
                    myPurchaseButtons[i].interactable = true;
                else
                    myPurchaseButtons[i].interactable = false;
            }           
        }
    }
}
