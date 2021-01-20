using Entitas;
using UnityEngine.SceneManagement;

namespace SemoGames.GameScene
{
    public class InitCurrentSceneSystem : IInitializeSystem
    {
        public void Initialize()
        {
            GameEntity newSceneEntity = Contexts.sharedInstance.game.CreateEntity();
            newSceneEntity.AddActiveSceneName(SceneManager.GetActiveScene().name);
        }
    }
}