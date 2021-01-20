using System.Collections.Generic;
using Entitas;
using SemoGames.Configurations;
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

                AsyncOperationHandle<GameObject> operationHandle =
                    Addressables.LoadAssetAsync<GameObject>(mainMenuReference);
                operationHandle.Completed += handle =>
                {
                    if (gameEntity != null && gameEntity.isMainMenu)
                    {
                        GameObject mainMenuBehaviour = GameObject.Instantiate(handle.Result, Contexts.sharedInstance.game.staticLayer.Value.transform,
                            false);
                        gameEntity.AddMainMenuBehaviour(mainMenuBehaviour.GetComponent<MainMenuBehaviour>());
                    }
                    else
                    {
                        Addressables.Release(operationHandle);
                    }
                };
            }
        }
    }
}