using Assets._Project.Gameplay.Ground_Check;
using Assets._Project.Gameplay.Jump;
using System;
using UnityEngine;
using Zenject;

namespace Assets._Project.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
    public class PlayerCharacter : MonoBehaviour, ICanJump
    {
        public event Action OnLand;

        private SpriteRenderer _renderer;
        private IGroundChecker _groundChecker;

        public bool IsGrounded => _groundChecker.IsGrounded;
        public float Height => _renderer.bounds.size.y;
        public Rigidbody2D Rigidbody { get; private set; }

        [Inject]
        public void Construct()
        {
        }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            Rigidbody = GetComponent<Rigidbody2D>();
            _groundChecker = new CapsuleGroundChecker
            (
                transform,
                transform.position + (Vector3.down * Height / 2) + (Vector3.up * _renderer.bounds.extents.x),
                _renderer.bounds.extents.x,
                LayerMask.GetMask("Ground")
            );
        }

        private void OnEnable()
        {
            _groundChecker.OnGround += OnGrounded;
        }

        private void OnGrounded() => OnLand?.Invoke();

        private void FixedUpdate()
        {
            _groundChecker?.Check();
        }

        private void OnDrawGizmos()
        {
            _groundChecker?.OnDrawGizmos();
        }

        private void OnDisable()
        {
            _groundChecker.OnGround -= OnGrounded;
        }
    }
}