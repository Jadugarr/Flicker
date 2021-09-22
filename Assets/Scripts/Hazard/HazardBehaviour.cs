using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Hazard
{
    public class HazardBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                ((GameEntity) other.gameObject.GetEntityLink().entity).isDead = true;
            }
        }
    }
}