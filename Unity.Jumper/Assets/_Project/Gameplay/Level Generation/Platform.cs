using UnityEngine;

namespace Assets._Project.Gameplay.Level_Generation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Platform : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        public float Length => _renderer.bounds.size.x;
        public Vector3 TopCenter => _renderer.bounds.center + Vector3.up * _renderer.bounds.size.y / 2;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
    }
}
