using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Player
{
    public class TeardownPlayerSystem : ITearDownSystem
    {
        private IGroup<GameEntity> _playerGroup;
        
        public TeardownPlayerSystem()
        {
            _playerGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Player);
        }

        public void TearDown()
        {
            foreach (GameEntity playerEntity in _playerGroup.GetEntities())
            {
                playerEntity.DestroyEntity();
            }
        }
    }
}