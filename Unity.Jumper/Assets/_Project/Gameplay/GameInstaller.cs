using UnityEngine;
using Zenject;

namespace Assets._Project.Gameplay
{
    [CreateAssetMenu(fileName = "Game Installer", menuName = "Installers/Game Installer")]
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(IInitializable), typeof(ILateDisposable))
                .To<GameStartup>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<Canvas>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}