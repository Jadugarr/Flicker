using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Flick
{
    public class DestroyFlickLineSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _lineGroup;
        
        public DestroyFlickLineSystem(IContext<GameEntity> context) : base(context)
        {
            _lineGroup = context.GetGroup(GameMatcher.FlickLine);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartFlick, GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity lineEntity = _lineGroup.GetSingleEntity();
            lineEntity.DestroyEntity();
        }
    }
}