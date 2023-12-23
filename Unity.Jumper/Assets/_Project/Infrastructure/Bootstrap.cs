using Assets._Project.Infrastructure.Scene_Loading;
using UnityEngine;
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
            Application.targetFrameRate = 60;
            _sceneLoader.LoadAsync("Game", LoadSceneMode.Single, activateOnLoad: true);
        }

        public void LateDispose()
        {
        }
    }
}
