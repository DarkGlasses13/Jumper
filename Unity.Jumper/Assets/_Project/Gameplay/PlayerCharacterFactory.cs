using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Assets._Project.Gameplay
{
    public class PlayerCharacterFactory : IFactory<PlayerCharacter>
    {
        public PlayerCharacter Create()
        {
            AsyncOperationHandle<GameObject> loading = Addressables.InstantiateAsync("Player Character");
            loading.WaitForCompletion();
            return loading.Result.GetComponent<PlayerCharacter>();
        }
    }
}