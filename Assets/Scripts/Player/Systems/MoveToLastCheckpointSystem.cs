using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

namespace SemoGames.Player
{
    public class MoveToLastCheckpointSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _playerSpawnGroup;
        
        public MoveToLastCheckpointSystem(IContext<GameEntity> context) : base(context)
        {
            _playerSpawnGroup = context.GetGroup(GameMatcher.PlayerSpawn);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.MoveToLastCheckpoint,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            Vector3 returnPosition = gameContext.hasLastTriggeredCheckpointEntityId ? gameContext.GetEntityWithId(gameContext.lastTriggeredCheckpointEntityId.Value).checkpointSpawnPosition.Value : _playerSpawnGroup.GetSingleEntity().position.Value;

            foreach (GameEntity playerEntity in entities)
            {
                playerEntity.RemovePosition();
                playerEntity.animation.Value.Play("MoveToRespawn");
                DOTween.To(() => playerEntity.view.Value.transform.position, value => playerEntity.view.Value.transform.position = value,
                    returnPosition, 2f).onComplete += () =>
                {
                    playerEntity.isMoveToLastCheckpoint = false;
                    playerEntity.animation.Value.Play("Dissolve_Reversed");
                    playerEntity.AddPosition(playerEntity.view.Value.transform.position);
                };
            }
        }
    }
}