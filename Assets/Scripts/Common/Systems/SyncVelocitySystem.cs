using Entitas;

namespace SemoGames.Common
{
    public class SyncVelocitySystem : IExecuteSystem
    {
        private IGroup<GameEntity> relevantEntities;

        public SyncVelocitySystem(GameContext context)
        {
            relevantEntities = context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.View));
        }

        public void Execute()
        {
            var entities = relevantEntities.GetEntities();
            for (var i = 0; i < entities.Length; i++)
            {
                GameEntity gameEntity = entities[i];

                if (gameEntity.hasRigidbody && gameEntity.rigidbody.Value != null
                                            && gameEntity.hasView && gameEntity.view.Value != null)
                {
                    gameEntity.ReplaceVelocity(gameEntity.rigidbody.Value.velocity);
                }
            }
        }
    }
}