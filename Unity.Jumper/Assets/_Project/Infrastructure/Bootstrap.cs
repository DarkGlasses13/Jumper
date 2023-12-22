using Assets._Project.Infrastructure.Scene_Loading;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets._Project.Infrastructure
{
    public class Bootstrap : IInitializable, ILateDisposable
    {
        private readonly ISceneLoader _sceneLoader;

        public Bootstrap(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _sceneLoader.LoadAsync("Game", LoadSceneMode.Single, activateOnLoad: true);
        }

        public void LateDispose()
        {
        }
    }
}
