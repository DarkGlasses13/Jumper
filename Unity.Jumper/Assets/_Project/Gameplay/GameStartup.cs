using Assets._Project.Infrastructure.Loading;
using UnityEngine;
using Zenject;

namespace Assets._Project.Gameplay
{
    public class GameStartup : IInitializable, ILateDisposable
    {
        private readonly Canvas _canvas;
        private readonly Camera _uiCamera;
        private readonly ILoadingScreen _loadingScreen;

        public GameStartup(Canvas canvas, Camera uiCamera, ILoadingScreen loadingScreen)
        {
            _canvas = canvas;
            _uiCamera = uiCamera;
            _loadingScreen = loadingScreen;
        }

        public void Initialize()
        {
            _canvas.worldCamera = _uiCamera;
            _canvas.planeDistance = _uiCamera.farClipPlane - 1;
            _loadingScreen.FadeOut(OnFadeOut);
        }

        private void OnFadeOut()
        {
        }

        public void LateDispose()
        {
        }
    }
}
