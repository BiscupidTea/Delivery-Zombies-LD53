using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int actualsCoins = 0;

    public int GetMoney(int coins) 
    {
        actualsCoins += coins;

        return actualsCoins;
    }

    public int LoseMoney(int coins) 
    {
        actualsCoins -= coins;

        if (actualsCoins <= 0) 
        {
            actualsCoins = 0;
        }

        return actualsCoins;
    }

    public void ResetMoney() 
    {
        actualsCoins = 0;
    }
}