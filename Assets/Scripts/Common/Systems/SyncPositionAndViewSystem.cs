using Entitas;
using UnityEngine;

namespace SemoGames.Common
{
    public class SyncPositionAndViewSystem : IExecuteSystem
    {
        private IGroup<GameEntity> relevantEntities;
        

        public SyncPositionAndViewSystem(GameContext context)
        {
            relevantEntities = context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.View));
        }

        public void Execute()
        {
            var entities = relevantEntities.GetEntities();
            for (var i = 0; i < entities.Length; i++)
            {
                GameEntity gameEntity = entities[i];
                Vector3 viewPosition = gameEntity.view.Value.transform.position;
                Vector3 entityPosition = gameEntity.position.Value;

                if (Vector3.Distance(viewPosition, entityPosition) > 0f)
                {
                    gameEntity.ReplacePosition(viewPosition);
                }
            }
        }
    }
}