using System.Globalization;
using Entitas;
using SemoGames.Utils;
using TMPro;
using UnityEngine;

namespace SemoGames.GameTimer
{
    public class LevelTimerBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameTimerTextfield;
        
        private IGroup<GameEntity> _currentTimeGroup;

        private void Awake()
        {
            _currentTimeGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.GameTime);
        }

        private void Update()
        {
            if (_currentTimeGroup.count == 1)
            {
                GameEntity currentTime = _currentTimeGroup.GetSingleEntity();
                _gameTimerTextfield.text = FormattingUtils.FormatDuration(currentTime.gameTime.Value);
            }
        }
    }
}