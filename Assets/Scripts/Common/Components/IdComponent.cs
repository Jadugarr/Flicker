using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.Common
{
    [Game, Input]
    public class IdComponent : IComponent
    {
        [PrimaryEntityIndex] public int Value;
    }
}