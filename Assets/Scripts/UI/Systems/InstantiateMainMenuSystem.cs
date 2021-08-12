using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SemoGames.UI
{
    public class InstantiateMainMenuSystem : ReactiveSystem<GameEntity>
    {        
        public InstantiateMainMenuSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public InstantiateMainMenuSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.MainMenu, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override async void Execute(List<GameEntity> entities)
        {
            GameEntity[] tempList = entities.ToArray();
            AssetReference mainMenuReference = GameConfigurations.AssetReferenceConfiguration.MainMenuReference;
            foreach (GameEntity gameEntity in tempList)
            {
                await AssetLoaderUtils.InstantiateAssetAsyncTask(mainMenuReference, gameEntity, Contexts.sharedInstance.game.staticLayer.Value.transform);
                gameEntity.AddMainMenuBehaviour(gameEntity.view.Value.GetComponent<MainMenuBehaviour>());
            }
        }
    }
}