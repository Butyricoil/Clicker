using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private ClickView _clickView;
    [SerializeField] private AutoClickView _autoClickView;
    [SerializeField] private UpgradeView _upgradeView;

    public override void InstallBindings()
    {
        // Биндим данные и настройки
        Container.Bind<GameData>().AsSingle();
        Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();

        // Биндим View
        Container.Bind<ClickView>().FromInstance(_clickView).AsSingle();
        Container.Bind<AutoClickView>().FromInstance(_autoClickView).AsSingle();
        Container.Bind<UpgradeView>().FromInstance(_upgradeView).AsSingle();

        // Биндим контроллеры
        Container.Bind<ClickController>().AsSingle();
        Container.Bind<AutoClickController>().AsSingle();
        Container.Bind<UpgradeController>().AsSingle();
        Container.Bind<SaveController>().AsSingle().NonLazy();
    }
}