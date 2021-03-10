using Entitas;
using SemoGames.Controller;

namespace SemoGames.GameTransition
{
    [Game]
    public class ControllerToRestartTransitionComponent : IComponent
    {
        public GameControllerType Value;
    }
}