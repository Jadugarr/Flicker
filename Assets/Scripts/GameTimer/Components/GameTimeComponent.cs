using Entitas;

namespace SemoGames.GameTimer
{
    [Game, SaveData]
    public class GameTimeComponent : IComponent
    {
        public float Value;
    }
}