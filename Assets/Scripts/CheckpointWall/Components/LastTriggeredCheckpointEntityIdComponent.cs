using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.CheckpointWall
{
    [Game, Unique]
    public class LastTriggeredCheckpointEntityIdComponent : IComponent
    {
        public int Value;
    }
}