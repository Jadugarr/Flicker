using Entitas;
using UnityEngine.InputSystem;

namespace SemoGames.GameInput
{
    [Input]
    public class InputAdapterComponent : IComponent
    {
        public InputAction.CallbackContext Value;
    }
}