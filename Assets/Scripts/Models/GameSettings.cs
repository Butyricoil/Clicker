using UnityEngine;
using UnityEngine.Serialization;

// Это скрипт, который хранит настройки игры. Он используется для хранения базовых значений и множителей.
[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    // Параметры клика
    public int BaseClicksPerTap = 1;
    public int BaseAddClickCost = 10;
    public float UpgradeCostMultiplier = 1.5f;

    // Параметры автоклика
    public int AutoClickBaseCost = 50;
    public int AutoClickCostIncrement = 25;
}