using Entitas.Unity;
using UnityEngine;

namespace SemoGames.CheckpointWall
{
    public class CheckpointWallTriggerBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                GameEntity checkpointWallEntity = (GameEntity)transform.parent.gameObject.GetEntityLink().entity;
                checkpointWallEntity.isTriggered = true;
            }
        }
    }
}