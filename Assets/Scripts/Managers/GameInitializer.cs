using UnityEngine;
using Zenject;

public class GameInitializer : MonoBehaviour
{
    [Inject] private ClickerController _clickerController;
    [Inject] private UpgradeController _upgradeController;
    [Inject] private AutoClickUpgradeController _autoClickUpgradeController;

    [Inject] private ClickerView _clickerView;
    [Inject] private AddClickView _addClickView;
    [Inject] private AutoClickView _autoClickView;

    [Inject] private GameModel _model;

    private void Start()
    {
        _clickerView.ClickButton.onClick.AddListener(() => { _clickerController.AddClick(); });

        _addClickView.UpgradeButton.onClick.AddListener(() => { _upgradeController.Upgrade(); });

        _model.OnClicksChanged += clicks =>
        {
            _clickerView.UpdateClicks(clicks);
            _addClickView.UpdateUpgradeInfo(
                _upgradeController.GetUpgradeCost(),
                _upgradeController.CanUpgrade()
            );
        };

        _model.OnUpgradeChanged += level =>
        {
            _addClickView.UpdateUpgradeInfo(
                _upgradeController.GetUpgradeCost(),
                _upgradeController.CanUpgrade()
            );
        };

        _model.OnClicksPerTapChanged += amount => { _clickerView.UpdateClicksPerTap(amount); };

        _clickerView.UpdateClicks(_model.ClicksCount);
        _clickerView.UpdateClicksPerTap(_model.ClicksPerTap);
        _addClickView.UpdateUpgradeInfo(
            _upgradeController.GetUpgradeCost(),
            _upgradeController.CanUpgrade()
        );

        _autoClickView.UpgradeButton.onClick.AddListener(() => { _autoClickUpgradeController.Upgrade(); });

        _model.OnAutoClickUpgraded += level =>
        {
            _autoClickView.UpdateInfo(
                level,
                _model.GetAutoClicksAmount(),
                _autoClickUpgradeController.GetUpgradeCost(),
                _autoClickUpgradeController.CanUpgrade()
            );
        };

        _autoClickView.UpdateInfo(
            _model.AutoClickLevel,
            _model.GetAutoClicksAmount(),
            _autoClickUpgradeController.GetUpgradeCost(),
            _autoClickUpgradeController.CanUpgrade()
        );
    }
}
