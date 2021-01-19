using Entitas;

namespace SemoGames.Common
{
    [Game, Input]
    public class IdComponent : IComponent
    {
        public int Value;
    }
}