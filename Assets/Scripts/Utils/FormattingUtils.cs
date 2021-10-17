using UnityEngine;

namespace SemoGames.Utils
{
    public static class FormattingUtils
    {
        /// <summary>
        /// Returns string in format of MM:SS:MS
        /// </summary>
        /// <returns></returns>
        public static string FormatDuration(float durationInSeconds)
        {
            int durationInMilliseconds = Mathf.FloorToInt(durationInSeconds * 1000f);
            
            int minutes = 0;
            int seconds = 0;
            int milliseconds = 0;

            milliseconds = durationInMilliseconds % 1000;
            durationInMilliseconds /= 1000;
            seconds = durationInMilliseconds % 60;
            durationInMilliseconds /= 60;
            minutes = durationInMilliseconds;

            return $"{minutes:D2}:{seconds:D2}:{milliseconds:D3}";
        }
    }
}