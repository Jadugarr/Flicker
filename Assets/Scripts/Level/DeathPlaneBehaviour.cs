using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Level
{
    public class DeathPlaneBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                var entity = other.gameObject.GetEntityLink()?.entity;
                if (entity != null)
                    ((GameEntity) entity).isDead = true;
            }
        }
    }
}