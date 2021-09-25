using System;
using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Hazard
{
    public class HazardBehaviour : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime * _rotationSpeed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                ((GameEntity) other.gameObject.GetEntityLink().entity).isDead = true;
            }
        }
    }
}