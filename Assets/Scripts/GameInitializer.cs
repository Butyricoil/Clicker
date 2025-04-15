using UnityEngine;
using Zenject;

public class GameInitializer : MonoBehaviour
{
    [Inject] private ClickerController _clickerController;
    [Inject] private UpgradeController _upgradeController;
    [Inject] private ClickerView _clickerView;
    [Inject] private AddClicks _addClicks;
    [Inject] private GameModel _model;

    private void Start()
    {
         _clickerView.ClickButton.onClick.AddListener(() => {
            _clickerController.AddClick();
        });

         _addClicks.UpgradeButton.onClick.AddListener(() => {
            _upgradeController.Upgrade();
        });

         _model.OnClicksChanged += clicks => {
            _clickerView.UpdateClicks(clicks);
            _addClicks.UpdateUpgradeInfo(
                _upgradeController.GetUpgradeCost(),
                _upgradeController.CanUpgrade()
            );
        };

        _model.OnUpgradeChanged += level => {
            _addClicks.UpdateUpgradeInfo(
                _upgradeController.GetUpgradeCost(),
                _upgradeController.CanUpgrade()
            );
        };

        _model.OnClicksPerTapChanged += amount => {
            _clickerView.UpdateClicksPerTap(amount);
        };

         _clickerView.UpdateClicks(_model.ClicksCount);
        _clickerView.UpdateClicksPerTap(_model.ClicksPerTap);
        _addClicks.UpdateUpgradeInfo(
            _upgradeController.GetUpgradeCost(),
            _upgradeController.CanUpgrade()
        );
    }
}