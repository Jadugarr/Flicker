using System;
using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Collectables
{
    public class CollectableBehaviour : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, 360 * Time.deltaTime * _rotationSpeed);
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