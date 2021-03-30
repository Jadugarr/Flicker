using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.Pause
{
    [Game,Unique]
    public class PauseTimeStartedComponent : IComponent
    {
        public float Value;
    }
}