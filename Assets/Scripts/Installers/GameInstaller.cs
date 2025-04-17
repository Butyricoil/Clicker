using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

// Это инсталлятор, который отвечает за связывание зависимостей в игре. Привязан к Dependency Container.
public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _settings;
    [SerializeField] private ClickerView _clickerView;
    [SerializeField] private AddClickView _addClickView;
    [SerializeField] private AutoClickView _autoClickView;


    public override void InstallBindings()
    {
        // Биндим модель игры
        Container.Bind<GameModel>().AsSingle().NonLazy();

        // Биндим настройки игры
        Container.BindInstance(_settings);

        // Биндим представления
        Container.BindInstance(_clickerView);
        Container.BindInstance(_addClickView);
        Container.BindInstance(_autoClickView);

        // Биндим контроллеры
        Container.BindInterfacesAndSelfTo<ClickerController>().AsSingle();
        Container.BindInterfacesAndSelfTo<AddClickController>().AsSingle();
        Container.BindInterfacesAndSelfTo<AutoClickController>().AsSingle();
        Container.BindInterfacesAndSelfTo<AutoClickUpgradeController>().AsSingle();
    }
}