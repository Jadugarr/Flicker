using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.SceneManagement;

namespace SemoGames.GameScene
{
    [Game, Unique]
    public class CurrentSceneComponent : IComponent
    {
        public Scene Value;
    }
}