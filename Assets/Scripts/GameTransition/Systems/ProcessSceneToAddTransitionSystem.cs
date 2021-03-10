using System;
using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;
using UnityEngine.SceneManagement;

namespace SemoGames.GameTransition
{
    public class ProcessSceneToAddTransitionSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _sceneToAddGroup;
        
        public ProcessSceneToAddTransitionSystem(IContext<GameEntity> context) : base(context)
        {
            _sceneToAddGroup = context.GetGroup(GameMatcher.SceneToAdd);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartLevelTransition,
                GroupEvent.Removed), new TriggerOnEvent<GameEntity>(GameMatcher.SceneToAdd, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _sceneToAddGroup.count > 0 && !Contexts.sharedInstance.game.isStartLevelTransition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity sceneToAddEntity in _sceneToAddGroup.GetEntities())
            {
                Contexts.sharedInstance.game.CreateEntity().AddActiveSceneName(sceneToAddEntity.sceneToAdd.Value);
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            foreach (GameEntity sceneToAddEntity in _sceneToAddGroup.GetEntities())
            {
                if (sceneToAddEntity.sceneToAdd.Value == scene.name)
                {
                    SceneManager.sceneLoaded -= OnSceneLoaded;
                    sceneToAddEntity.RemoveSceneToAdd();
                    break;
                }
            }
        }
    }
}