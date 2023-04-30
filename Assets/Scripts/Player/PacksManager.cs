using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacksManager : MonoBehaviour
{
    public int actualPacks = 5;

    public int GetPackage(int packs)
    {
        actualPacks += packs;
        return actualPacks;
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
}