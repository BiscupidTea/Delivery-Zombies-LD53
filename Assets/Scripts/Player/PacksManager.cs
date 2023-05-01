using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacksManager : MonoBehaviour
{
    public int actualPacks = 5;
    public int MaxPacks = 5;

    public int GetPackage(int packs)
    {
        actualPacks += packs;
        return actualPacks;
    }

    public int ResetFullPackage()
    {
        actualPacks = MaxPacks;
        return actualPacks;
    }

    public bool CheckCurrentPackages()
    {
        if (actualPacks > 0) 
            return true;
        else
            return false;
    }

    public int RemovePackage(int packs)
    {
        actualPacks -= packs;

        if (actualPacks <= 0)
        {
            actualPacks = 0;
        }

        return actualPacks;
    }

    public void ResetPackage()
    {
        actualPacks = 0;
    }

    public void addOneMoreMaxPackage()
    {
        MaxPacks++;
    }
}