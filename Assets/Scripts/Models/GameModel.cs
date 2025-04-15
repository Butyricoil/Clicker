using System;

[Serializable]
public class GameModel
{
    public int ClicksCount;
    public int UpgradeLevel;
    public int ClicksPerTap = 1;

    public event Action<int> OnClicksChanged;
    public event Action<int> OnUpgradeChanged;
    public event Action<int> OnClicksPerTapChanged;

    public void AddClick()
    {
        ClicksCount += ClicksPerTap;
        OnClicksChanged?.Invoke(ClicksCount);
    }

    public void Upgrade(int cost)
    {
        ClicksCount -= cost;
        UpgradeLevel++;
        ClicksPerTap++;
        OnClicksChanged?.Invoke(ClicksCount);
        OnUpgradeChanged?.Invoke(UpgradeLevel);
        OnClicksPerTapChanged?.Invoke(ClicksPerTap);
    }
}