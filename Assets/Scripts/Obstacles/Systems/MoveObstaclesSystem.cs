using Entitas;
using UnityEngine;

namespace SemoGames.Obstacles.Systems
{
    public class MoveObstaclesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movingObstaclesGroup;
        private GameContext _gameContext;

        public MoveObstaclesSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _movingObstaclesGroup = gameContext.GetGroup(GameMatcher.Obstacle);
        }

        public void Execute()
        {
            if (_gameContext.isPause)
                return;
            
            foreach (GameEntity movingObstacleEntity in _movingObstaclesGroup.GetEntities())
            {
                Transform[] obstacleWaypoints = movingObstacleEntity.waypoints.Value;
                Vector3 currentWaypointPosition =
                    obstacleWaypoints[movingObstacleEntity.currentWaypointIndex.Value].position;
                Vector3 nextWaypointPosition = obstacleWaypoints[movingObstacleEntity.nextWaypointIndex.Value].position;
                float distCovered =
                    Mathf.Sin(Mathf.PI / -2f + (Time.time - movingObstacleEntity.timeWhenMovementStarted.Value) *
                        movingObstacleEntity.movementSpeed.Value) / 2f + 0.5f;

                Vector3 newPosition = Vector3.Lerp(currentWaypointPosition, nextWaypointPosition, distCovered);
                movingObstacleEntity.ReplacePosition(newPosition);

                if (1f - distCovered <= 0.001f)
                {
                    int nextWaypointIndex = movingObstacleEntity.nextWaypointIndex.Value;

                    movingObstacleEntity.ReplaceCurrentWaypointIndex(movingObstacleEntity.nextWaypointIndex.Value);
                    movingObstacleEntity.ReplaceNextWaypointIndex(nextWaypointIndex < obstacleWaypoints.Length - 1
                        ? nextWaypointIndex + 1
                        : 0);
                    movingObstacleEntity.ReplaceTimeWhenMovementStarted(Time.time);
                }
            }
        }
    }
}