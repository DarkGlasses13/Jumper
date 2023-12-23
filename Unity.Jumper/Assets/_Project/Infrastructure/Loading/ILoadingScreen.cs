using System;

namespace Assets._Project.Infrastructure.Loading
{
    public interface ILoadingScreen
    {
        void FadeIn(Action callback);
        void FadeOut(Action callback);
    }
}