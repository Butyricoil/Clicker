using UnityEngine;
using Zenject;

public class UpgradeController
{
    private GameData _gameData;
    private GameSettings _settings;
    private UpgradeView _upgradeView;
    private AutoClickController _autoClickController;

    [Inject]
    public void Construct(
        GameData gameData,
        GameSettings settings,
        UpgradeView upgradeView,
        AutoClickController autoClickController)
    {
        _gameData = gameData;
        _settings = settings;
        _upgradeView = upgradeView;
        _autoClickController = autoClickController;

        _upgradeView.OnUpgradeClicked.AddListener(OnUpgradeClicked);
        UpdateUpgradeButton();
    }

    private void OnUpgradeClicked()
    {
        int cost = GetUpgradeCost();
        if (_gameData.TotalClicks >= cost)
        {
            _gameData.TotalClicks -= cost;
            _autoClickController.Upgrade();
            UpdateUpgradeButton();
        }
    }

    private void UpdateUpgradeButton()
    {
        int cost = GetUpgradeCost();
        _upgradeView.SetUpgradeButtonState(
            _gameData.TotalClicks >= cost,
            cost
        );
    }

    private int GetUpgradeCost()
    {
        return (int)(_settings.BaseUpgradeCost *
                     Mathf.Pow(_settings.UpgradeCostMultiplier, _gameData.AutoClickLevel));
    }
}