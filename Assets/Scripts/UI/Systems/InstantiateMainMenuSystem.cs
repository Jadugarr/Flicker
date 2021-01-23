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

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                // Create proper system to load/unload assets
                AssetReference mainMenuReference = GameConfigurations.AssetReferenceConfiguration.MainMenuReference;

                AssetLoaderUtils.LoadAssetAsync(mainMenuReference, gameEntity, loadedObject =>
                {
                    GameObject mainMenuBehaviour = GameObject.Instantiate(loadedObject, Contexts.sharedInstance.game.staticLayer.Value.transform,
                        false);
                    gameEntity.AddMainMenuBehaviour(mainMenuBehaviour.GetComponent<MainMenuBehaviour>());
                    gameEntity.AddView(mainMenuBehaviour);
                    mainMenuBehaviour.Link(gameEntity);
                });
            }
        }
    }
}