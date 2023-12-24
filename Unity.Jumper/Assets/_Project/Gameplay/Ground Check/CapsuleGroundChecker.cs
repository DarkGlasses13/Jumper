using System;
using UnityEngine;

namespace Assets._Project.Gameplay.Ground_Check
{
    public class CapsuleGroundChecker : IGroundChecker
    {
        public event Action OnGround;

        private Collider2D[] _groundColliders = new Collider2D[1];
        private Collider2D _lastCollision;

        public bool IsGrounded { get; private set; }
        public float Radius { get; set; }
        public LayerMask LayerMask { get; set; }
        public Transform Transform { get; set; }
        public Vector3 Offset { get; set; }

        public CapsuleGroundChecker(Transform transform, Vector3 offset,
            float radius, LayerMask layerMask)
        {
            Transform = transform;
            Offset = offset;
            Radius = radius;
            LayerMask = layerMask;
        }

        public void Check()
        {
            if (Physics2D.OverlapCircleNonAlloc(Transform.position + Offset, Radius, _groundColliders, LayerMask) > 0)
            {
                IsGrounded = true;

                if (_lastCollision == null)
                    OnGround?.Invoke();

                _lastCollision = _groundColliders[0];
                return;
            }

            _lastCollision = null;
            IsGrounded = false;
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(Transform.position + Offset, Radius);
        }
    }
}
