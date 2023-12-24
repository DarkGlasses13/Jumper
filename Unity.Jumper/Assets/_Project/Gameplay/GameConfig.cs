using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Project.Gameplay
{
    [CreateAssetMenu(fileName = "Game Config")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public int InitialPlatformsCount { get; private set; }
        [field: SerializeField] public Vector2 PlatformDistanceRange { get; private set; }
        [field: SerializeField] public float ClearPassedDistance { get; private set; }
        [field: SerializeField] public InputAction JumpInputAction { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
    }
}
