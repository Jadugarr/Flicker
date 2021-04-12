using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Collectables
{
    public class CollectableBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntity collectableEntity = Contexts.sharedInstance.game.CreateEntity();
            collectableEntity.isCollectable = true;
            collectableEntity.AddView(gameObject);
            collectableEntity.AddPosition(gameObject.transform.position);
            collectableEntity.AddAnimator(GetComponentInChildren<Animator>());
            gameObject.Link(collectableEntity);
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