using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Flick
{
    public class StartFlickSystem : ReactiveSystem<GameEntity>
    {
        public StartFlickSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public StartFlickSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.StartFlick);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isStartFlick;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Debug.Log("Start Flicking!");
            Contexts.sharedInstance.input.playerInput.Value.SwitchCurrentActionMap("Flicking");
        }
    }
}