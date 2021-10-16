using Entitas;
using UnityEngine;

namespace GameTimer.Systems
{
    public class MeasureGameTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _gameTimeGroup;

        public MeasureGameTimeSystem()
        {
            _gameTimeGroup =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.GameTime));
        }

        public void Execute()
        {
            GameEntity gameTimeEntity = _gameTimeGroup.GetSingleEntity();

            if (gameTimeEntity.isActive)
            {
                gameTimeEntity.ReplaceGameTime(gameTimeEntity.gameTime.Value + Time.deltaTime);
            }
        }
    }
}