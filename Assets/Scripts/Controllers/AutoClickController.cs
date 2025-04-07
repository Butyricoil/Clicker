using Zenject;
using UnityEngine;

public class AutoClickController : ITickable
{
    private GameData _gameData;
    private GameSettings _settings;
    private AutoClickView _autoClickView;

    [Inject]
    public void Construct(
        GameData gameData,
        GameSettings settings,
        AutoClickView autoClickView)
    {
        _gameData = gameData;
        _settings = settings;
        _autoClickView = autoClickView;
        UpdateAutoClickView();
    }

    public void Tick()
    {
        if (_gameData.AutoClickLevel > 0)
        {
            _gameData.TotalClicks += _settings.AutoClicksPerSecond * _gameData.AutoClickLevel * Time.deltaTime;
        }
    }

    public void Upgrade()
    {
        _gameData.AutoClickLevel++;
        UpdateAutoClickView();
    }

    private void UpdateAutoClickView()
    {
        _autoClickView.UpdateAutoClickInfo(
            _gameData.AutoClickLevel,
            _settings.AutoClicksPerSecond
        );
    }
}