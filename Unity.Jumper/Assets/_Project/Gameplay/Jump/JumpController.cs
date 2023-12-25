using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets._Project.Gameplay.Jump
{
    public class JumpController : IInitializable, ITickable, IDisposable
    {
        private readonly ICanJump _jumper;
        private readonly GameConfig _config;
        private float _inputForce;

        public JumpController(ICanJump jumper, GameConfig config)
        {
            _jumper = jumper;
            _config = config;
        }

        public void Initialize()
        {
            _config.JumpInputAction.Enable();
            _config.JumpInputAction.canceled += OnInputActionCanceled;
            _jumper.OnLand += OnLanded;
        }

        private void OnLanded()
        {
            _jumper.Rigidbody.velocity = Vector2.zero;
            _jumper.DrawTrajectory(null);
        }

        private void OnInputActionCanceled(InputAction.CallbackContext context)
        {
            if (_jumper.IsGrounded)
            {
                Jump();
                _inputForce = 0f;
            }
        }

        public void Tick()
        {
            if (_jumper.IsGrounded)
            {
                if (_config.JumpInputAction.IsPressed())
                {
                    _inputForce = Mathf.Clamp01(_inputForce += Time.deltaTime);
                    _jumper.DrawTrajectory(CalculateTrajectory());
                }
            }
        }

        private Vector3[] CalculateTrajectory()
        {
            Vector3[] pointrajectorys = new Vector3[_config.JumpTrajectoryLength];
            Vector3 currentPosition = _jumper.Transform.position;
            Vector3 currentVelocity = _config.JumpForce * _inputForce * new Vector3(1, 1, 0);

            for (int i = 0; i < pointrajectorys.Length; i++)
            {
                float time = i * _config.JumpTrajectoryPointIntervals;
                pointrajectorys[i] = currentPosition + currentVelocity * time + 0.5f * time * time * Physics.gravity;
            }

            return pointrajectorys;
        }

        private void Jump()
        {
            _jumper.Rigidbody.velocity = _inputForce * _config.JumpForce * Vector2.one;
        }

        public void Dispose()
        {
            _config.JumpInputAction.canceled -= OnInputActionCanceled;
            _jumper.OnLand -= OnLanded;
            _config.JumpInputAction.Disable();
        }
    }
}
