using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Flick
{
    public class TeardownFlickLineSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> flickLineGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.FlickLine);

            foreach (GameEntity entity in flickLineGroup.GetEntities())
            {
                entity.DestroyEntity();
            }
        }
    }
}