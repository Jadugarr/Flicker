﻿using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Level.Systems
{
    public class LoadLevelSystem : ReactiveSystem<GameEntity>
    {
        public LoadLevelSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.LevelIndex, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity levelEntity in entities)
            {
                if (levelEntity.hasAsyncOperationHandle)
                {
                    Addressables.Release(levelEntity.asyncOperationHandle.Value);
                    levelEntity.RemoveAsyncOperationHandle();
                }
                
                if (levelEntity.hasView)
                {
                    levelEntity.view.Value.Unlink();
                    GameObject.Destroy(levelEntity.view.Value);
                    levelEntity.RemoveView();
                }
                
                AssetReference levelReference =
                    GameConfigurations.AssetReferenceConfiguration.LevelAssetReferences[levelEntity.levelIndex.Value];

                AssetLoaderUtils.LoadAssetAsync(levelReference, levelEntity, loadedObject =>
                {
                    GameObject levelView = GameObject.Instantiate(loadedObject);
                    levelEntity.AddView(levelView);
                    levelView.Link(levelEntity);
                });
            }
        }
    }
}