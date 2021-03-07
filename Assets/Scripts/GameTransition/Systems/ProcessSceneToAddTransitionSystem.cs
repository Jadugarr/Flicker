using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

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
                GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _sceneToAddGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity sceneToAddEntity in _sceneToAddGroup.GetEntities())
            {
                Contexts.sharedInstance.game.CreateEntity().AddActiveSceneName(sceneToAddEntity.sceneToAdd.Value);
                sceneToAddEntity.RemoveSceneToAdd();
            }
        }
    }
}