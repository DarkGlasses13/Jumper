using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project.Infrastructure.Asset_Loading
{
    public abstract class AddressablesAssetLoader<T> : IAssetLoader<T>
    {
        private T _asset;

        public abstract object Key { get; }

        public T Load()
        {
            if (_asset == null)
            {
                AsyncOperationHandle<T> loading = Addressables.LoadAssetAsync<T>(Key);
                loading.WaitForCompletion();
                _asset = loading.Result;
            }

            return _asset;
        }

        public async Task<T> LoadAsync()
        {
            _asset ??= await Addressables.LoadAssetAsync<T>(Key).Task;
            return _asset;
        }

        public void Unload()
        {
            if (_asset != null)
                Addressables.Release(_asset);
        }
    }
}
