using System;
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
            gameObject.Link(collectableEntity);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                ((GameEntity) gameObject.GetEntityLink().entity).isCollected = true;
            }
        }
    }
}