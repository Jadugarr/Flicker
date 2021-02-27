using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Goal))
            {
                GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
                playerEntity.isIsInGoal = true;
            }
        }
    }
}