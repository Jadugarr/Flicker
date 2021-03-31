using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

namespace Bumpers
{
    public class BumperBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntity bumperEntity = Contexts.sharedInstance.game.CreateEntity();
            bumperEntity.isBumper = true;
            bumperEntity.AddView(gameObject);
            bumperEntity.AddPosition(transform.position);
            gameObject.Link(bumperEntity);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ContactFilter2D contactFilter2D = new ContactFilter2D
            {
                layerMask = LayerMask.GetMask(Layers.Flipper),
                useLayerMask = true,
                useTriggers = true
            };
            Vector3 otherPosition = other.transform.position;
            Vector3 dir = transform.position - otherPosition;
            List<RaycastHit2D> results = new List<RaycastHit2D>();
            Physics2D.Raycast(otherPosition, dir, contactFilter2D, results);
            if (results.Count > 0)
            {
                GameEntity playerEntity = other.gameObject.GetEntityLink().entity as GameEntity;
                RaycastHit2D result = results[0];
                Vector3 normal = result.normal;
                Vector3 reflectedVector = Vector3.Reflect(playerEntity.velocity.Value, normal).normalized;
                
                playerEntity.ReplaceBumperCollisionVelocity(reflectedVector * 25f);
            }
        }
    }
}