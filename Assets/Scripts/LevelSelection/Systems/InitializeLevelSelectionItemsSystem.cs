using Entitas;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.LevelSelection
{
    public class InitializeLevelSelectionItemsSystem : IInitializeSystem
    {
        public async void Initialize()
        {
            GameContext context = Contexts.sharedInstance.game;
            for (int i = 0; i < GameConfigurations.AssetReferenceConfiguration.LevelAssetReferences.Length; i++)
            {
                GameEntity levelSelectionItemEntity = context.CreateEntity();
                await AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.LevelSelectionItemReference, levelSelectionItemEntity, Vector3.zero, Quaternion.identity);
                var behaviour = levelSelectionItemEntity.view.Value.GetComponent<LevelSelectionItemBehaviour>();
                behaviour.LevelIndex = i;
                levelSelectionItemEntity.AddLevelSelectionItemBehaviour(behaviour);
            }
        }
    }
}