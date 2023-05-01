using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ScriptableObjects/New Shop item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int basePrice;
    public bool bought;
    public bool upgradable;
    public int maxUpgrades;
    public int timesUpgraded;
}
