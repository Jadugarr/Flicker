using Entitas;
using SemoGames.Extensions;
using UnityEngine;

namespace SemoGames.Obstacles.Systems
{
    public class TeardownObstaclesSystem : ITearDownSystem
    {
        private IGroup<GameEntity> _movingObstacleGroup;
        
        public TeardownObstaclesSystem(GameContext gameContext)
        {
            _movingObstacleGroup = gameContext.GetGroup(GameMatcher.Obstacle);
        }

        public void TearDown()
        {
            foreach (GameEntity obstacleEntity in _movingObstacleGroup.GetEntities())
            {
                GameObject parentObject = obstacleEntity.view.Value.transform.parent.gameObject;
                obstacleEntity.DestroyEntity();
                GameObject.Destroy(parentObject);
            }
        }
    }
}