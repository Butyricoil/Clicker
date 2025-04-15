using System;

[Serializable]
public class GameModel
{
    public int ClicksCount;
    public int UpgradeLevel;

    public event Action<int> OnClicksChanged;
    public event Action<int> OnUpgradeChanged;

    public void AddClick()
    {
        ClicksCount++;
        OnClicksChanged?.Invoke(ClicksCount);
    }

    public void Upgrade(int cost)
    {
        ClicksCount -= cost;
        UpgradeLevel++;
        OnClicksChanged?.Invoke(ClicksCount);
        OnUpgradeChanged?.Invoke(UpgradeLevel);
    }
}