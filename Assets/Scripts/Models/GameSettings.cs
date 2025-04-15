using UnityEngine;

// Это скрипт, который хранит настройки игры. Он используется для хранения базовых значений и множителей.
[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int BaseUpgradeCost = 10;
    public float UpgradeCostMultiplier = 1.5f;
    public int BaseClicksPerTap = 1;
}