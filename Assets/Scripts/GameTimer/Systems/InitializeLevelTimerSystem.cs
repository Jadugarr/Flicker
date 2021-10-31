using Entitas;
using SemoGames.Configurations;
using SemoGames.GameTimer;
using SemoGames.Utils;

namespace GameTimer.Systems
{
    public class InitializeLevelTimerSystem : IInitializeSystem
    {
        public async void Initialize()
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            GameEntity levelTimerEntity = gameContext.CreateEntity();
            await AssetLoaderUtils.InstantiateAssetAsyncTask(
                GameConfigurations.AssetReferenceConfiguration.LevelTimerComponentReference, levelTimerEntity,
                gameContext.staticLayer.Value.transform);
            levelTimerEntity.isLevelTimer = true;
            levelTimerEntity.AddLevelTimerBehaviour(levelTimerEntity.view.Value.GetComponent<LevelTimerBehaviour>());
        }
    }
}