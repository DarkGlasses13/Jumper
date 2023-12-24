using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Assets._Project.Gameplay
{
    public class GameConfigFactory : IFactory<GameConfig>
    {
        private GameConfig _instance;

        public GameConfig Create()
        {
            if (_instance == null)
            {
                AsyncOperationHandle<GameConfig> loading = Addressables.LoadAssetAsync<GameConfig>("Game Config");
                loading.WaitForCompletion();
                _instance = loading.Result;
            }

            return _instance;
        }
    }
}
