using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.InputSystem;

namespace SemoGames.GameInput
{
    [Input, Unique]
    public class PlayerInputComponent : IComponent
    {
        public PlayerInput Value;
    }
}