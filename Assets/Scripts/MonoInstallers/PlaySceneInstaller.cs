using ScriptableObjects;
using Game;
using Menu;
using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlaySceneInstaller : MonoInstaller
    {
        [SerializeField] private GameSettingsModel gameSettingsModel;
        [SerializeField] private PlayerStatsController playerStatsController;
        [SerializeField] private GameStateView gameStateView;
        [SerializeField] private GameInitializer gameInitializer;

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettingsModel).AsSingle();
            Container.BindInstance(playerStatsController).AsSingle();
            Container.BindInstance(gameInitializer).AsSingle();
            Container.Bind<PlayerStatsModel>().AsSingle().WithArguments(gameSettingsModel.PlayerMoveSpeed, gameSettingsModel.PlayerSize);

            Container.BindInstance(gameStateView).AsSingle();
            Container.Bind<GameStateModel>().AsSingle().WithArguments(gameSettingsModel.NumberOfItems);
            Container.BindInterfacesTo<GameStatePresenter>().AsSingle();
        }
    }
}