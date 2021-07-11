using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag(Tags.Ground))
            {
                GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
                playerEntity.isPlaySound = true;
            }
        }
    }
}