using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Clicker/GameSettings")]
public class GameSettings : ScriptableObject
{
    public int AutoClicksPerSecond = 1;
    public int BaseUpgradeCost = 50;
    public float UpgradeCostMultiplier = 1.5f;
}