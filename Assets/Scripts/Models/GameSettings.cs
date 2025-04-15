using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int BaseUpgradeCost = 10;
    public float UpgradeCostMultiplier = 1.5f;
}