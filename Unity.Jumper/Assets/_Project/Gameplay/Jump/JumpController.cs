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
                }
            }
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
