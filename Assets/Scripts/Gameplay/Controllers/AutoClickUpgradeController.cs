using Zenject;

public class AutoClickUpgradeController
{
    private readonly GameModel _model;
    private readonly GameSettings _settings;

    [Inject]
    public AutoClickUpgradeController(GameModel model, GameSettings settings)
    {
        _model = model;
        _settings = settings;
    }

    public int GetUpgradeCost()
    {
        return _settings.AutoClickBaseCost + (_model.AutoClickLevel * _settings.AutoClickCostIncrement);
    }

    public bool CanUpgrade()
    {
        return _model.ClicksCount >= GetUpgradeCost();
    }

    public void Upgrade()
    {
        if (CanUpgrade())
        {
            _model.UpgradeAutoClick(GetUpgradeCost());
        }
    }
}