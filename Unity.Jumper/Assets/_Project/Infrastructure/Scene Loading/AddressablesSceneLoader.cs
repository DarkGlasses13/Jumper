using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Assets._Project.Infrastructure.Scene_Loading
{
    public class AddressablesSceneLoader : ISceneLoader
    {
        public async void LoadAsync(object key, LoadSceneMode loadMode, bool activateOnLoad)
        {
            await Addressables.LoadSceneAsync("Empty", loadMode, activateOnLoad).Task;
            Addressables.LoadSceneAsync(key, loadMode, activateOnLoad);
        }
    }
}