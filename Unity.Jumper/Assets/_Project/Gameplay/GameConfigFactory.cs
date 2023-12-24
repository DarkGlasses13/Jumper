using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Assets._Project.Gameplay
{
    public class GameConfigFactory : IFactory<GameConfig>
    {
        public GameConfig Create()
        {
            AsyncOperationHandle<GameConfig> loading = Addressables.LoadAssetAsync<GameConfig>("Game Config");
            loading.WaitForCompletion();
            return loading.Result;
        }
    }
}
