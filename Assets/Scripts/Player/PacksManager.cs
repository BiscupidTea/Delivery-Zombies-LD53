using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacksManager : MonoBehaviour
{
    public int Numberofpacks = 5;

    public int GetPackage(int packs)
    {
        Numberofpacks += packs;
        return Numberofpacks;
    }

    public int RemovePackage(int packs)
    {
        Numberofpacks -= packs;
        return Numberofpacks;
    }

    public void ResetPackage()
    {
        Numberofpacks = 0;
    }
}
