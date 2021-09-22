using System.Collections.Generic;
using DG.Tweening;
using Entitas;

namespace SemoGames.Player
{
    public class MoveToLastCheckpointSystem : ReactiveSystem<GameEntity>
    {
        public MoveToLastCheckpointSystem(IContext<GameEntity> context) : base(context)
        {
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
            GameEntity lastCheckpointEntity =
                gameContext.GetEntityWithId(gameContext.lastTriggeredCheckpointEntityId.Value);

            foreach (GameEntity playerEntity in entities)
            {
                playerEntity.RemovePosition();
                playerEntity.animation.Value.Play("MoveToRespawn");
                DOTween.To(() => playerEntity.view.Value.transform.position, value => playerEntity.view.Value.transform.position = value,
                    lastCheckpointEntity.checkpointSpawnPosition.Value, 2f).onComplete += () =>
                {
                    playerEntity.isMoveToLastCheckpoint = false;
                    playerEntity.animation.Value.Play("Dissolve_Reversed");
                    playerEntity.AddPosition(playerEntity.view.Value.transform.position);
                };
            }
        }
    }
}