using Zenject;

// Обрабатывает клики игрока, работает через Zenject

public class ClickController
{
    private GameData _gameData;
    private ClickView _clickView;

    [Inject]
    public void Construct(GameData gameData, ClickView clickView)
    {
        _gameData = gameData;
        _clickView = clickView;
    }

    public void AddClick()
    {
        _gameData.TotalClicks++;
        _clickView.UpdateClicks(_gameData.TotalClicks);
    }
}