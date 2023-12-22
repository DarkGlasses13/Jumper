using UnityEngine.SceneManagement;

namespace Assets._Project.Infrastructure.Scene_Loading
{
    public interface ISceneLoader
    {
        void LoadAsync(object key, LoadSceneMode loadMode, bool activateOnLoad);
    }
}