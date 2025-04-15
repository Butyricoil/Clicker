using UnityEngine;
using Zenject;

public class GameInitializer : MonoBehaviour
{
    [Inject] private ClickerController _clickerController;
    [Inject] private UpgradeController _upgradeController;
    [Inject] private ClickerView _clickerView;
    [Inject] private UpgradeView _upgradeView;
    [Inject] private GameModel _model;

    private void Start()
    {
        // Setup click button
        _clickerView.ClickButton.onClick.AddListener(() => {
            _clickerController.AddClick();
        });

        // Setup upgrade button
        _upgradeView.UpgradeButton.onClick.AddListener(() => {
            _upgradeController.Upgrade();
        });

        // Subscribe to model changes
        _model.OnClicksChanged += clicks => {
            _clickerView.UpdateClicks(clicks);
            _upgradeView.UpdateUpgradeInfo(
                _upgradeController.GetUpgradeCost(),
                _upgradeController.CanUpgrade()
            );
        };

        _model.OnUpgradeChanged += level => {
            _upgradeView.UpdateUpgradeInfo(
                _upgradeController.GetUpgradeCost(),
                _upgradeController.CanUpgrade()
            );
        };

        // Initial update
        _clickerView.UpdateClicks(_model.ClicksCount);
        _upgradeView.UpdateUpgradeInfo(
            _upgradeController.GetUpgradeCost(),
            _upgradeController.CanUpgrade()
        );
    }
}