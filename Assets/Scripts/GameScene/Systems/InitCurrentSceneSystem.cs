using Entitas;
using UnityEngine.SceneManagement;

namespace GameScene.Systems
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