using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SemoGames.GameInput
{
    public class GameInputBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        private IGroup<GameEntity> _playerGroup;
        private IGroup<GameEntity> _cameraGroup;
        private InputContext _context;

        private void Start()
        {
            _playerInput.onActionTriggered += OnInputActionTriggered;
            _context = Contexts.sharedInstance.input;

            _context.ReplacePlayerInput(_playerInput);

            _playerGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Player);
            _cameraGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Camera);
        }

        private void OnInputActionTriggered(InputAction.CallbackContext inputAction)
        {
            switch (inputAction.action.name)
            {
                case "TestVelocity":
                    HandleTestVelocityInput(inputAction);
                    break;
                case "Fire":
                    HandleFireInput(inputAction);
                    break;
                case "MousePosition":
                    HandleMousePositionInput(inputAction);
                    break;
                case "Interact":
                    HandleInteractInput(inputAction);
                    break;
                case "Pause":
                    HandlePauseInput(inputAction);
                    break;
                case "Unpause":
                    HandleUnpauseInput(inputAction);
                    break;
            }
        }

        private void OnDestroy()
        {
            _playerInput.onActionTriggered -= OnInputActionTriggered;

            _context.RemovePlayerInput();
        }

        private void HandlePauseInput(InputAction.CallbackContext inputAction)
        {
            if (inputAction.phase != InputActionPhase.Performed)
                return;

            GameContext gameContext = Contexts.sharedInstance.game;
            if (!gameContext.isPause)
            {
                gameContext.isPause = true;
                gameContext.ReplacePauseTimeStarted(Time.time);
            }
        }

        private void HandleUnpauseInput(InputAction.CallbackContext inputAction)
        {
            if (inputAction.phase != InputActionPhase.Performed)
                return;

            GameContext gameContext = Contexts.sharedInstance.game;
            if (gameContext.isPause)
            {
                gameContext.isPause = false;
                gameContext.ReplacePauseTimeEnded(Time.time);
            }
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
            GameEntity cameraEntity = _cameraGroup.GetSingleEntity();
            if (cameraEntity != null)
            {
                Camera camera = cameraEntity.camera.Value;
                Vector2 rawMousePosition = Mouse.current.position.ReadValue();
                Vector3 mouseVector = new Vector3(rawMousePosition.x, rawMousePosition.y, camera.nearClipPlane);
                Vector2 worldMousePosition = camera.ScreenToWorldPoint(mouseVector);
                
                Contexts.sharedInstance.game.ReplaceMousePosition(worldMousePosition);
            }
        }

        private void HandleFireInput(InputAction.CallbackContext inputAction)
        {
            if (inputAction.phase == InputActionPhase.Performed)
            {
                GameEntity cameraEntity = _cameraGroup.GetSingleEntity();
                if (cameraEntity != null)
                {
                    Camera camera = cameraEntity.camera.Value;
                    Vector2 mousePosition = Mouse.current.position.ReadValue();
                    Vector3 mouseVector = new Vector3(mousePosition.x, mousePosition.y, camera.nearClipPlane);
                    Vector2 ray = camera.ScreenToWorldPoint(mouseVector);
                    var hit = Physics2D.Raycast(ray, Vector2.up);

                    if (hit.collider != null && hit.collider.gameObject.CompareTag(Tags.Player))
                    {
                        GameEntity playerEntity = _playerGroup.GetSingleEntity();
                        if (playerEntity != null)
                        {
                            playerEntity.isStartFlick = true;
                        }
                    }
                }
            }
            else if (inputAction.phase == InputActionPhase.Canceled)
            {
                GameEntity playerEntity = _playerGroup.GetSingleEntity();
                if (playerEntity != null && playerEntity.isStartFlick)
                {
                    playerEntity.isStartFlick = false;
                    playerEntity.isFlick = true;
                }
            }
        }

        private void HandleInteractInput(InputAction.CallbackContext inputAction)
        {
            if (inputAction.phase == InputActionPhase.Performed)
            {
                Contexts.sharedInstance.input.isInteracting = true;
            }

            if (inputAction.phase == InputActionPhase.Canceled)
            {
                Contexts.sharedInstance.input.isInteracting = false;
            }
        }
    }
}