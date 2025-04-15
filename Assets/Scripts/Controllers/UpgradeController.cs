
public class UpgradeController
{
    private readonly GameModel _model;
    private readonly GameSettings _settings;

    public UpgradeController(GameModel model, GameSettings settings)
    {
        _model = model;
        _settings = settings;
    }

    public int GetUpgradeCost()
    {
        return (int)(_settings.BaseUpgradeCost *
                     System.Math.Pow(_settings.UpgradeCostMultiplier, _model.UpgradeLevel));
    }

    public bool CanUpgrade()
    {
        return _model.ClicksCount >= GetUpgradeCost();
    }

    public void Upgrade()
    {
        if (CanUpgrade())
        {
            _model.Upgrade(GetUpgradeCost());
        }
    }
}