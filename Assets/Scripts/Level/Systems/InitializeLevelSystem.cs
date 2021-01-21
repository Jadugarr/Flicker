using Entitas;
using SemoGames.Configurations;
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

                Addressables.LoadAssetAsync<GameObject>(levelReference).Completed += handle =>
                {
                    GameObject levelView = GameObject.Instantiate(handle.Result);
                    levelEntity.AddLevelView(levelView);
                };
            }
        }
    }
}