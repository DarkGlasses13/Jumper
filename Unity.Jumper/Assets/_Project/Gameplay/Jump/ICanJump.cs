using System;
using UnityEngine;

namespace Assets._Project.Gameplay.Jump
{
    public interface ICanJump
    {
        event Action OnLand;
        bool IsGrounded { get; }
        Rigidbody2D Rigidbody { get; }
    }
}
