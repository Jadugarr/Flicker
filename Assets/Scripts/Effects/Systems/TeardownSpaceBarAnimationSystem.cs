using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Effects
{
    public class TeardownSpaceBarAnimationSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> spaceBarAnimationGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.SpaceBarAnimation);

            foreach (GameEntity animationEntity in spaceBarAnimationGroup.GetEntities())
            {
                animationEntity.DestroyEntity();
            }
        }
    }
}