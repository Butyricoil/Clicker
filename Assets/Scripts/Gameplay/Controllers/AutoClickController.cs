using UnityEngine;
using Zenject;

// Это контроллер, который отвечает за автоматическое нажатие.
public class AutoClickController : ITickable
{
    private readonly GameModel _model;

    [Inject]
    public AutoClickController(GameModel model)
    {
        _model = model;
    }

    public void Tick()
    {
        if (_model.AutoClickLevel > 0 && Time.time > _model.LastAutoClickTime + _model.AutoClickDelay)
        {
            _model.ClicksCount += _model.GetAutoClicksAmount();
            _model.LastAutoClickTime = Time.time;
            _model.InvokeOnClicksChanged(_model.ClicksCount); // ? правильно ли
        }
    }
}