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

        public void SetTimerValue(float duration)
        {
            _gameTimerTextfield.text = FormattingUtils.FormatDuration(duration);
        }
    }
}