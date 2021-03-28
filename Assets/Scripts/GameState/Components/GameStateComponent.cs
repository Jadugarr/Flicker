using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.GameState
{
    [Game, Unique]
    public class GameStateComponent : IComponent
    {
        public GameStates Value;
    }
}