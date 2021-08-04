using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Effects
{
    public class FlipperAnimationBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntity flipperAnimationEntity = Contexts.sharedInstance.game.CreateEntity();
            flipperAnimationEntity.AddView(gameObject);
            flipperAnimationEntity.isFlipperAnimation = true;
            flipperAnimationEntity.AddAnimation(GetComponent<Animation>());

            gameObject.Link(flipperAnimationEntity);
        }
    }
}