using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;
using UnityEngine.SceneManagement;

namespace SemoGames.GameTransition
{
    public class ProcessSceneToRemoveTransitionSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _sceneToRemoveGroup;
        private IGroup<GameEntity> _activeScenesGroup;
        
        public ProcessSceneToRemoveTransitionSystem(IContext<GameEntity> context) : base(context)
        {
            _sceneToRemoveGroup = context.GetGroup(GameMatcher.SceneToRemove);
            _activeScenesGroup = context.GetGroup(GameMatcher.ActiveSceneName);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartLevelTransition,
                GroupEvent.Removed), new TriggerOnEvent<GameEntity>(GameMatcher.SceneToRemove, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _sceneToRemoveGroup.count > 0 && !Contexts.sharedInstance.game.isStartLevelTransition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in _sceneToRemoveGroup.GetEntities())
            {
                foreach (GameEntity activeSceneEntity in _activeScenesGroup.GetEntities())
                {
                    if (activeSceneEntity.activeSceneName.Value == gameEntity.sceneToRemove.Value)
                    {
                        SceneManager.sceneUnloaded -= OnSceneUnloaded;
                        SceneManager.sceneUnloaded += OnSceneUnloaded;
                        activeSceneEntity.DestroyEntity();
                    }
                }
            }
        }

        private void OnSceneUnloaded(Scene scene)
        {
            foreach (GameEntity sceneToRemoveEntity in _sceneToRemoveGroup.GetEntities())
            {
                if (sceneToRemoveEntity.sceneToRemove.Value == scene.name)
                {
                    SceneManager.sceneUnloaded -= OnSceneUnloaded;
                    sceneToRemoveEntity.RemoveSceneToRemove();
                }
            }
        }
    }
}