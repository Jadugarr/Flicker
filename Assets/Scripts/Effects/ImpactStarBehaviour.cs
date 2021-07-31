using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Effects
{
    public class ImpactStarBehaviour : MonoBehaviour
    {
        public void AnimationFinished()
        {
            GameEntity starEntity = transform.parent.gameObject.GetEntityLink().entity as GameEntity;
            if (starEntity != null)
            {
                starEntity.isGarbage = true;
            }
        }
    }
}