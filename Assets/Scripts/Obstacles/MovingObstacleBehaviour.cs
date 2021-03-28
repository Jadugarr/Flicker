using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Obstacles
{
    public class MovingObstacleBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;
        [SerializeField] private GameObject objectToMove;
        [SerializeField] private float movementSpeed;

        private void Start()
        {
            objectToMove.transform.position = waypoints[0].position;
            
            GameEntity obstacleEntity = Contexts.sharedInstance.game.CreateEntity();
            obstacleEntity.isObstacle = true;
            obstacleEntity.AddWaypoints(waypoints);
            obstacleEntity.AddView(objectToMove);
            obstacleEntity.AddPosition(objectToMove.transform.position);
            obstacleEntity.AddRigidbody(objectToMove.GetComponent<Rigidbody2D>());
            obstacleEntity.AddVelocity(Vector3.zero);
            obstacleEntity.AddCurrentWaypointIndex(0);
            obstacleEntity.AddMovementSpeed(movementSpeed);
            objectToMove.Link(obstacleEntity);
        }
    }
}