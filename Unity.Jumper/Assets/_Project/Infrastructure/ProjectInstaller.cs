using Assets._Project.Infrastructure.Scene_Loading;
using UnityEngine;
using Zenject;

namespace Assets._Project.Infrastructure
{
    [CreateAssetMenu(fileName = "Project Installer", menuName = "Installers/Project Installer")]
    public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(IInitializable), typeof(ILateDisposable))
                .To<Bootstrap>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ISceneLoader>()
                .To<AddressablesSceneLoader>()
                .FromNew()
                .AsSingle();


        }
    }
}