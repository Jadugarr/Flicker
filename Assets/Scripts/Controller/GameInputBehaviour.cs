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
                case "Fire":
                    Debug.Log($"[Fire] Phase: {inputAction.phase}");
                    HandleFireInput(inputAction);
                    break;
                case "MousePosition":
                    //HandleMousePositionInput(inputAction);
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

        private void HandleMousePositionInput(InputAction.CallbackContext inputAction)
        {
            Ray ray = Camera.main.ScreenPointToRay(inputAction.ReadValue<Vector2>());
            var hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject.CompareTag(Tags.Player))
            {
                Contexts.sharedInstance.game.CreateEntity().isStartFlick = true;
            }
        }

        private void HandleFireInput(InputAction.CallbackContext inputAction)
        {
            if (inputAction.phase == InputActionPhase.Performed)
            {
                Debug.Log($"[Fire] Trying to hit...");
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                Debug.Log($"[Fire] Current Mouse position: {mousePosition}");
                Vector2 ray = Camera.main.ScreenToWorldPoint(mousePosition);
                Debug.Log($"[Fire] Position to check: {ray}");
                var hit = Physics2D.Raycast(ray, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject.CompareTag(Tags.Player))
                {
                    Debug.Log($"[Fire] Hit!");
                    Contexts.sharedInstance.game.CreateEntity().isStartFlick = true;
                }
            }
        }
    }
}