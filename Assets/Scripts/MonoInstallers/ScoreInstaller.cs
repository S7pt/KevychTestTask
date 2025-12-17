using Score;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ScoreInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView scoreView;

        public override void InstallBindings()
        {
            Container.Bind<ScoreModel>().AsSingle();
            Container.Bind<ScoreView>().FromInstance(scoreView).AsSingle();
            Container.BindInterfacesTo<ScorePresenter>().AsSingle();
        }
    }
}