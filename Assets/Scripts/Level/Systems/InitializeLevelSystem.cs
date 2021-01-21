using Entitas;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Level.Systems
{
    public class InitializeLevelSystem : IInitializeSystem
    {
        public void Initialize()
        {
            IGroup<GameEntity> levelGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Level);
            GameEntity levelEntity = levelGroup.GetSingleEntity();

            if (levelEntity != null)
            {
                AssetReference levelReference =
                    GameConfigurations.AssetReferenceConfiguration.LevelAssetReferences[levelEntity.levelIndex.Value];

                AssetLoaderUtils.LoadAssetAsync(levelReference, loadedObject =>
                {
                    GameObject levelView = GameObject.Instantiate(loadedObject);
                    levelEntity.AddLevelView(levelView);
                });
            }
        }
    }
}