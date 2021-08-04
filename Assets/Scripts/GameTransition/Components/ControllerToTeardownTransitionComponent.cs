using Entitas;
using SemoGames.Controller;

namespace SemoGames.GameTransition
{
    [Game]
    public class ControllerToTeardownTransitionComponent : IComponent
    {
        public GameControllerType Value;
    }
}