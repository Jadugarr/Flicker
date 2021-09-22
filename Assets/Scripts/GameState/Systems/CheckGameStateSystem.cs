using Entitas;
using UnityEngine.InputSystem;

namespace SemoGames.GameState
{
    public class CheckGameStateSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _playerGroup;
        private GameContext _gameContext;
        private PlayerInput _playerInput;
        
        public CheckGameStateSystem(GameContext gameContext, PlayerInput playerInput)
        {
            _gameContext = gameContext;
            _playerInput = playerInput;
            _playerGroup = gameContext.GetGroup(GameMatcher.Player);
        }

        public void Execute()
        {
            if (IsInDeathState())
            {
                if (_gameContext.gameState.Value != GameStates.Respawning)
                    _gameContext.ReplaceGameState(GameStates.Respawning);
                return;
            }
            
            if (IsInUiState())
            {
                if (_gameContext.gameState.Value != GameStates.UI)
                    _gameContext.ReplaceGameState(GameStates.UI);
                return;
            }
            
            if (IsInFlickingState())
            {
                if (_gameContext.gameState.Value != GameStates.Flicking)
                    _gameContext.ReplaceGameState(GameStates.Flicking);
                return;
            }

            if (_gameContext.gameState.Value != GameStates.Waiting)
                _gameContext.ReplaceGameState(GameStates.Waiting);
        }

        private bool IsInUiState()
        {
            return _gameContext.isPause || _playerGroup.count <= 0 ||
                   (_playerGroup.count > 0 && _playerGroup.GetSingleEntity().isIsInGoal);
        }

        private bool IsInDeathState()
        {
            return _playerGroup.count > 0 && _playerGroup.GetSingleEntity().isDead;
        }

        private bool IsInFlickingState()
        {
            return _playerGroup.count > 0 && _playerGroup.GetSingleEntity().isFlick;
        }
    }
}