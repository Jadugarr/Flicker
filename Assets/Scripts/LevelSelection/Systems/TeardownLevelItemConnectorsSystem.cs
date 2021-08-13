using Entitas;
using SemoGames.Extensions;

namespace SemoGames.LevelSelection
{
    public class TeardownLevelItemConnectorsSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> levelItemConnectorGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.LevelSelectionItemConnector);

            foreach (GameEntity levelItemConnector in levelItemConnectorGroup.GetEntities())
            {
                levelItemConnector.DestroyEntity();
            }
        }
    }
}