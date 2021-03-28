using Entitas;
using UnityEngine;

namespace SemoGames.Obstacles.Systems
{
    public class MoveObstaclesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movingObstaclesGroup;

        public MoveObstaclesSystem(GameContext gameContext)
        {
            _movingObstaclesGroup = gameContext.GetGroup(GameMatcher.Obstacle);
        }

        public void Execute()
        {
            foreach (GameEntity movingObstacleEntity in _movingObstaclesGroup.GetEntities())
            {
                Transform[] obstacleWaypoints = movingObstacleEntity.waypoints.Value;
                int currentWaypointIndex = movingObstacleEntity.currentWaypointIndex.Value;
                Transform currentWaypoint = obstacleWaypoints[currentWaypointIndex];
                Vector3 currentPosition = movingObstacleEntity.position.Value;
                Vector2 expectedDirection = movingObstacleEntity.velocity.Value.normalized;
                Vector2 currentDirection =
                    (obstacleWaypoints[currentWaypointIndex].position - movingObstacleEntity.position.Value).normalized;
                float angle = Vector2.Angle(expectedDirection, currentDirection);

                if (Vector3.Distance(currentPosition, currentWaypoint.position) <= 0.01f || (currentDirection != Vector2.zero && angle > 0.2f))
                {
                    int nextWaypointIndex = currentWaypointIndex < obstacleWaypoints.Length - 1
                        ? currentWaypointIndex + 1
                        : 0;

                    Transform nextWaypoint = obstacleWaypoints[nextWaypointIndex];
                    Vector2 dir = (nextWaypoint.position - currentPosition).normalized;
                    movingObstacleEntity.ReplaceVelocity(dir * movingObstacleEntity.movementSpeed.Value);
                    movingObstacleEntity.ReplaceCurrentWaypointIndex(nextWaypointIndex);
                }
            }
        }
    }
}