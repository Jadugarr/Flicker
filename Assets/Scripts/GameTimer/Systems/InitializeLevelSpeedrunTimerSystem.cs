using Entitas;
using SemoGames.Configurations;
using SemoGames.GameTimer;
using SemoGames.Utils;
using UnityEngine;

namespace GameTimer.Systems
{
    public class InitializeLevelSpeedrunTimerSystem : IInitializeSystem
    {
        public async void Initialize()
        {
            if (Contexts.sharedInstance.gameSettings.isSpeedrun)
            {
                GameContext gameContext = Contexts.sharedInstance.game;
                GameEntity levelTimerEntity = gameContext.CreateEntity();
                await AssetLoaderUtils.InstantiateAssetAsyncTask(
                    GameConfigurations.AssetReferenceConfiguration.LevelTimerComponentReference, levelTimerEntity,
                    gameContext.staticLayer.Value.transform);
                levelTimerEntity.isSpeedrunLevelTimer = true;
                levelTimerEntity.AddLevelTimerBehaviour(levelTimerEntity.view.Value
                    .GetComponent<LevelTimerBehaviour>());

                var positionComponent = levelTimerEntity.position.Value;

                // changing the speedrun timer's position in a super hacky way
                Vector3 transformPosition = levelTimerEntity.view.Value.transform.position;
                levelTimerEntity.view.Value.transform.position =
                    new Vector3(transformPosition.x, transformPosition.y - 50f, transformPosition.z);
            }
        }
    }
}