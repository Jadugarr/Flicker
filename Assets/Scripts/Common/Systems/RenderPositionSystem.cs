﻿using System.Collections.Generic;
using Entitas;

namespace SemoGames.Common
{
    public class RenderPositionSystem : ReactiveSystem<GameEntity>
    {
        public RenderPositionSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameEntity>(Matcher<GameEntity>.AllOf(GameMatcher.Position, GameMatcher.View),
                    GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                if (e.hasPosition)
                {
                    PositionComponent pos = e.position;
                    e.view.Value.transform.position = pos.Value;
                }
            }
        }
    }
}