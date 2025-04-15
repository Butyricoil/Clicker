// Это файл ClickController.cs, который отвечает за логику кликов в игре.
public class ClickerController
{
    private readonly GameModel _model;

    public ClickerController(GameModel model)
    {
        _model = model;
    }

    public void AddClick()
    {
        _model.AddClick();
    }
}