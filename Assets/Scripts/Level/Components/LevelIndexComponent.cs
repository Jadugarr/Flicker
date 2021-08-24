using Entitas;

namespace SemoGames.Level
{
    [Game, SaveData]
    public class LevelIndexComponent : IComponent
    {
        public int Value;
    }
}