using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Effects
{
    public class SpaceBarAnimationBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntity spaceBarAnimationEntity = Contexts.sharedInstance.game.CreateEntity();
            spaceBarAnimationEntity.AddView(gameObject);
            spaceBarAnimationEntity.isSpaceBarAnimation = true;
            spaceBarAnimationEntity.AddAnimation(GetComponent<Animation>());

            gameObject.Link(spaceBarAnimationEntity);
        }
    }
}