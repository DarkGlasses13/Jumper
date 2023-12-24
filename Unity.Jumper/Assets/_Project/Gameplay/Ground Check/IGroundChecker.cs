using System;

namespace Assets._Project.Gameplay.Ground_Check
{
    public interface IGroundChecker
    {
        event Action OnGround;
        bool IsGrounded { get; }
        void Check();
        void OnDrawGizmos();
    }
}
