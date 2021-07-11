using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Goal.Systems
{
    public class TeardownGoalSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> goalGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Goal);

            foreach (GameEntity goalEntity in goalGroup.GetEntities())
            {
                goalEntity.DestroyEntity();
            }
        }
    }
}