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
            Debug.Log($"InputAction: {inputAction.action.name}; Phase: {inputAction.phase}");
            
            _context.CreateEntity().AddInputAction(inputAction);
        }

        private void OnDestroy()
        {
            _playerInput.onActionTriggered -= OnInputActionTriggered;

            _context.RemovePlayerInput();
        }
    }
}