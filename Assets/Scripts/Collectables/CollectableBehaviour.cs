using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Collectables
{
    public class CollectableBehaviour : MonoBehaviour
    {
        private void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                ((GameEntity) gameObject.GetEntityLink().entity).isCollected = true;
            }
        }

        private void OnCollectionFinished()
        {
            GameEntity linkedEntity = gameObject.GetEntityLink().entity as GameEntity;
            if (linkedEntity == null) return;

            linkedEntity.isGarbage = true;
        }
    }
}