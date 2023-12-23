using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using UnityEngine;

namespace Assets._Project.Infrastructure.Loading
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private float _fadeInDuration, _fadeOutDuration;
        private CanvasGroup _canvasGroup;
        private TweenerCore<float, float, FloatOptions> _fadeInTween, _fadeOutTween;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();    
        }

        public void FadeIn(Action callback)
        {
            _fadeInTween?.Restart();
            _fadeInTween ??= _canvasGroup
                .DOFade(endValue: 1, _fadeInDuration)
                .Play()
                .OnComplete(callback.Invoke);
        }

        public void FadeOut(Action callback)
        {
            _fadeOutTween?.Restart();
            _fadeOutTween ??= _canvasGroup
                .DOFade(endValue: 0, _fadeOutDuration)
                .Play()
                .OnComplete(callback.Invoke);
        }
    }
}