using Assets._Project.Gameplay.Level_Generation;
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
        private readonly GameConfig _config;
        private readonly LevelGenerator _levelGenerator;
        private readonly Platform _initialPlatform;
        private readonly PlayerCharacter _playerCharacter;

        public GameStartup(Canvas canvas, Camera uiCamera,
            ILoadingScreen loadingScreen, GameConfig config,
            LevelGenerator levelGenerator, Platform initialPlatform,
            PlayerCharacter playerCharacter)
        {
            _canvas = canvas;
            _uiCamera = uiCamera;
            _loadingScreen = loadingScreen;
            _config = config;
            _levelGenerator = levelGenerator;
            _initialPlatform = initialPlatform;
            _playerCharacter = playerCharacter;
        }

        public void Initialize()
        {
            _canvas.worldCamera = _uiCamera;
            _canvas.planeDistance = _uiCamera.farClipPlane - 1;
            _levelGenerator.Spawn(_config.InitialPlatformsCount);
            _playerCharacter.transform.position = _initialPlatform.TopCenter + Vector3.up * (_playerCharacter.Height / 2);
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
