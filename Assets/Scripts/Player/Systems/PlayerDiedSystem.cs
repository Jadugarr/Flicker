using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using SemoGames.Common;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Player
{
    public class PlayerDiedSystem : ReactiveSystem<GameEntity>
    {
        public PlayerDiedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Dead));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.isDead;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            GameEntity lastCheckpointEntity =
                gameContext.GetEntityWithId(gameContext.lastTriggeredCheckpointEntityId.Value);

            foreach (GameEntity playerEntity in entities)
            {
                playerEntity.isDead = false;
                playerEntity.isStopSimulation = true;
                playerEntity.isDissolve = true;
                playerEntity.RemovePosition();
                DOTween.To(() => playerEntity.view.Value.transform.position, value => playerEntity.view.Value.transform.position = value,
                    lastCheckpointEntity.checkpointSpawnPosition.Value, 2f).onComplete += () =>
                {
                    playerEntity.isDissolve = false;
                    playerEntity.isStopSimulation = false;
                    playerEntity.AddPosition(playerEntity.view.Value.transform.position);
                };
            }
        }
    }
}