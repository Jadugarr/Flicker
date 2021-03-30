using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.Pause
{
    [Game, Unique]
    public class PauseTimeEndedComponent : IComponent
    {
        public float Value;
    }
}