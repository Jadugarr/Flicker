using System;
using UnityEngine;

namespace SemoGames.Effects
{
    public class MainMenuDemoFlickBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform pointerPosition;
        
        private bool updateMousePosition = false;
        
        public void OnPositionReached()
        {
            updateMousePosition = true;
            Contexts.sharedInstance.game.GetGroup(GameMatcher.Player).GetSingleEntity().isStartFlick = true;
        }

        public void OnEndReached()
        {
            updateMousePosition = false;
            Contexts.sharedInstance.game.GetGroup(GameMatcher.Player).GetSingleEntity().isStartFlick = false;
            Contexts.sharedInstance.game.GetGroup(GameMatcher.Player).GetSingleEntity().isFlick = true;
        }

        private void Update()
        {
            if (updateMousePosition)
            {
                Contexts.sharedInstance.game.ReplaceMousePosition(pointerPosition.position);
            }
        }
    }
}