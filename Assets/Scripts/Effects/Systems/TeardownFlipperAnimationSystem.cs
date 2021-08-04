using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Effects
{
    public class TeardownFlipperAnimationSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> flipperAnimationGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.FlipperAnimation);

            foreach (GameEntity animationEntity in flipperAnimationGroup.GetEntities())
            {
                animationEntity.DestroyEntity();
            }
        }
    }
}