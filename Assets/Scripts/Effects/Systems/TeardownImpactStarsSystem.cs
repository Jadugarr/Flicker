using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Effects
{
    public class TeardownImpactStarsSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> impactStarGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.ImpactStar);

            foreach (GameEntity starEntity in impactStarGroup.GetEntities())
            {
                starEntity.DestroyEntity();
            }
        }
    }
}