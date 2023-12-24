using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Assets._Project.Gameplay.Level_Generation
{
    public class LevelGenerator
    {
        private readonly List<Platform> _platforms = new();
        private Platform _last;
        private readonly GameConfig _config;
        private readonly Transform _container;
        private readonly DiContainer _di;
        private GameObject _prefab;

        public LevelGenerator(DiContainer di, Platform initial, GameConfig config) 
        {
            _di = di;
            _container = initial.transform.parent;
            _platforms.Add(initial);
            _last = initial;
            _config = config;
        }

        public void Spawn() 
        {
            Platform instance = null;
            IEnumerable<Platform> inactivePlatforms = _platforms
                .Where(platform => platform.gameObject.activeInHierarchy == false);

            if (inactivePlatforms.Count() > 0)
            {
                int randomIndex = Random.Range(0, inactivePlatforms.Count());
                instance = inactivePlatforms.ElementAt(randomIndex);
            }

            if (instance == null)
                instance = Create();

            float randomDistance = Random
                .Range(_config.PlatformDistanceRange.x, _config.PlatformDistanceRange.y);

            float shift = (_last.Length / 2) + (instance.Length / 2) + randomDistance;
            instance.transform.position = _last.transform.position + Vector3.right * shift;
            _last = instance;
        }

        private Platform Create()
        {
            if (_prefab == null)
            {
                AsyncOperationHandle<GameObject> loading = Addressables
                    .LoadAssetAsync<GameObject>("Platform");

                loading.WaitForCompletion();
                _prefab = loading.Result;
            }

            Platform instance = _di.InstantiatePrefabForComponent<Platform>(_prefab);
            instance.transform.SetParent(_container);
            _platforms.Add(instance);
            return instance;
        }

        public void Spawn(int amount)
        {
            for (int i = 0; i < amount; i++)
                Spawn();
        }
    }
}
