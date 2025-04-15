using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _settings;
    [SerializeField] private ClickerView _clickerView;
    [SerializeField] private UpgradeView _upgradeView;

    public override void InstallBindings()
    {
        // Bind model
        Container.Bind<GameModel>().AsSingle().NonLazy();

        // Bind settings
        Container.BindInstance(_settings);

        // Bind views
        Container.BindInstance(_clickerView);
        Container.BindInstance(_upgradeView);

        // Bind controllers
        Container.BindInterfacesAndSelfTo<ClickerController>().AsSingle();
        Container.BindInterfacesAndSelfTo<UpgradeController>().AsSingle();
    }
}