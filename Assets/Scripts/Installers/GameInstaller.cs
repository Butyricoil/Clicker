using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

// Это инсталлятор, который отвечает за связывание зависимостей в игре. Привязан к Dependency Container.
public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _settings;
    [SerializeField] private ClickerView _clickerView;
    [FormerlySerializedAs("_upgradeView")] [SerializeField] private AddClicks addClicks;

    public override void InstallBindings()
    {
        // Bind model
        Container.Bind<GameModel>().AsSingle().NonLazy();

        // Bind settings
        Container.BindInstance(_settings);

        // Bind views
        Container.BindInstance(_clickerView);
        Container.BindInstance(addClicks);

        // Bind controllers
        Container.BindInterfacesAndSelfTo<ClickerController>().AsSingle();
        Container.BindInterfacesAndSelfTo<UpgradeController>().AsSingle();
    }
}