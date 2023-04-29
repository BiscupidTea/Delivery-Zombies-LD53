using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ScriptableObjects/New Shop item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
}
