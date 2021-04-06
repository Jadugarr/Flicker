using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.Collectables
{
    [Game, Unique]
    public class CollectedAmountComponent : IComponent
    {
        public int Value;
    }
}