using UnityEngine;
using UnityEngine.InputSystem;

namespace SemoGames.GameInput
{
    public class GameInputBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        private InputContext _context;

        private void Awake()
        {
        }

        private void Start()
        {
            _playerInput.onActionTriggered += OnInputActionTriggered;
            _context = Contexts.sharedInstance.input;

            _context.ReplacePlayerInput(_playerInput);
        }

        private void OnInputActionTriggered(InputAction.CallbackContext inputAction)
        {
            switch (inputAction.action.name)
            {
                case "TestVelocity":
                    HandleTestVelocityInput(inputAction);
                    break;
            }
        }

        private void OnDestroy()
        {
            _playerInput.onActionTriggered -= OnInputActionTriggered;

            _context.RemovePlayerInput();
        }

        private void HandleTestVelocityInput(InputAction.CallbackContext inputAction)
        {
            if (inputAction.phase == InputActionPhase.Performed)
            {
                Contexts.sharedInstance.game.GetGroup(GameMatcher.Player).GetSingleEntity().isFlick = true;
            }
        }
    }
}