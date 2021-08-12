using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Level.Systems
{
    public class InitializeLevelSystem : IInitializeSystem
    {
        public async void Initialize()
        {
            IGroup<GameEntity> levelGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Level);
            GameEntity levelEntity = levelGroup.GetSingleEntity();

            if (levelEntity != null && !levelEntity.hasView)
            {
                AssetReference levelReference =
                    GameConfigurations.AssetReferenceConfiguration.LevelAssetReferences[levelEntity.levelIndex.Value];

                await AssetLoaderUtils.InstantiateAssetAsyncTask(levelReference, levelEntity, Vector3.zero, Quaternion.identity);
            }
        }
    }
}