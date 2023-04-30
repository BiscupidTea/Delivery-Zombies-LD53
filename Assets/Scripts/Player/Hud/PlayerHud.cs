using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{

    [Header("References")]
    [SerializeField] CoinManager coinManager;
    [SerializeField] PacksManager packsManager;
    [SerializeField] PlayerHealth playerHealth;
 
    [Header("Text")]
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text packsText;

    [Header("Counters")]
    public int currentMoney = 0;
    public int currentPacks = 0;

    public Slider slider;

    private void Update()
    {
        currentMoney = coinManager.actualsCoins;
        currentPacks = packsManager.actualPacks;
        slider.value = playerHealth.health;
        slider.maxValue = playerHealth.maxHealth;

        moneyText.text = "Money: " + currentMoney.ToString();
        packsText.text = "Packs: " + currentPacks.ToString();
    }

}
