using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.LevelSelection
{
    public class LevelItemSelectionStatusChangedSystem : ReactiveSystem<GameEntity>
    {
        private static readonly int IsOutlineActive = Shader.PropertyToID("_IsOutlineActive");
        
        public LevelItemSelectionStatusChangedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AllOf(GameMatcher.LevelSelectionItemBehaviour, GameMatcher.Selected,
                    GameMatcher.SpriteRenderer),
                GroupEvent.AddedOrRemoved));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasLevelSelectionItemBehaviour && entity.hasSpriteRenderer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                gameEntity.spriteRenderer.Value.material.SetInteger(IsOutlineActive, Convert.ToInt32(gameEntity.isSelected));
            }
        }
    }
}