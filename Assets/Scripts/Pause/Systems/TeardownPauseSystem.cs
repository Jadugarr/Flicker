using Entitas;
using UnityEngine;

namespace SemoGames.Pause
{
    public class TeardownPauseSystem : ITearDownSystem
    {
        public void TearDown()
        {
            GameEntity pauseOverlayEntity =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.PauseOverlay).GetSingleEntity();
            pauseOverlayEntity.pauseOverlay.Value.enabled = false;
            Contexts.sharedInstance.game.isPause = false;
            Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
        }
    }
}