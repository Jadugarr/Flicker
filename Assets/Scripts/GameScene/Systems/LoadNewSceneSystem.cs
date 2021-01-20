using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;

namespace SemoGames.GameScene
{
    public class LoadNewSceneSystem : ReactiveSystem<GameEntity>
    {
        public LoadNewSceneSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.ActiveSceneName,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            if (entity != null && entity.hasActiveSceneName)
            {
                Scene scene = SceneManager.GetSceneByName(entity.activeSceneName.Value);
                return !scene.isLoaded;
            }

            return false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                SceneManager.LoadSceneAsync(entity.activeSceneName.Value, LoadSceneMode.Additive);
            }
        }
    }
}