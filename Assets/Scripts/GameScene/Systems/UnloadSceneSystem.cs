using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;

namespace SemoGames.GameScene
{
    public class UnloadSceneSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _activeSceneNames;

        public UnloadSceneSystem(IContext<GameEntity> context) : base(context)
        {
            _activeSceneNames = context.GetGroup(GameMatcher.ActiveSceneName);
        }

        public UnloadSceneSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.ActiveSceneName,
                GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            List<Scene> activeScenes = new List<Scene>(SceneManager.sceneCount);

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                activeScenes.Add(SceneManager.GetSceneAt(i));
            }

            bool isFound;
            foreach (Scene activeScene in activeScenes)
            {
                isFound = false;
                foreach (GameEntity activeSceneEntity in _activeSceneNames.GetEntities())
                {
                    if (activeSceneEntity.activeSceneName.Value == activeScene.name)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    SceneManager.UnloadSceneAsync(activeScene.name);
                }
            }
        }
    }
}