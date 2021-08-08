using Entitas;

namespace SemoGames.Collectables
{
    [Game, SaveData]
    public class CollectableIdComponent : IComponent
    {
        public int Value;
    }
}