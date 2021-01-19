using Entitas;
using UnityEngine.InputSystem;

namespace SemoGames.GameInput
{
    [Input]
    public class InputActionComponent : IComponent
    {
        public InputAction.CallbackContext Value;
    }
}