using System;

// Это скрипт модели, который хранит данные о состоянии игры.
[Serializable] public class GameModel
{
    // Параметры кликов
    public int ClicksCount;
    public int AddClickLevel;
    public int ClicksPerTap = 1;

    // Параметры автоклика
    public int AutoClickLevel;
    public float AutoClickDelay = 1f;
    public float LastAutoClickTime;

    // События для обновления UI
    public event Action<int> OnClicksChanged;
    public event Action<int> OnUpgradeChanged;
    public event Action<int> OnClicksPerTapChanged;
    public event Action<int> OnAutoClickUpgraded;

    public void AddClick()
    {
        ClicksCount += ClicksPerTap;
        OnClicksChanged?.Invoke(ClicksCount);
    }


    public void Upgrade(int cost)
    {
        ClicksCount -= cost;
        AddClickLevel++;
        ClicksPerTap++;
        OnClicksChanged?.Invoke(ClicksCount);
        OnUpgradeChanged?.Invoke(AddClickLevel);
        OnClicksPerTapChanged?.Invoke(ClicksPerTap);
    }

    public void UpgradeAutoClick(int cost)
    {
        ClicksCount -= cost;
        AutoClickLevel++;
        OnAutoClickUpgraded?.Invoke(AutoClickLevel);
    }

    public int GetAutoClicksAmount()
    {
        return AutoClickLevel * 2; // Например, 2 клика за уровень
    }

    public void InvokeOnClicksChanged(int clicksCount) // ? правильно ли
    {
        OnClicksChanged?.Invoke(clicksCount);
    }
}