using System;
using System.Collections.Generic;
using Entitas;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Collectables.Systems
{
    public class SpawnCollectableSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<SaveDataEntity> _savedCollectables;
        private IGroup<GameEntity> _spawnEntities;
        
        public SpawnCollectableSystem(IContext<GameEntity> context) : base(context)
        {
            _savedCollectables = Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.Collectable);
            _spawnEntities = context.GetGroup(GameMatcher.CollectableSpawn);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.AllOf(GameMatcher.CollectableSpawn, GameMatcher.CollectableId),
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            SpawnCollectableOnSpawns(entities.ToArray());
        }

        public void Initialize()
        {
            SpawnCollectableOnSpawns(_spawnEntities.GetEntities());
        }

        private async void SpawnCollectableOnSpawns(GameEntity[] listOfSpawnEntities)
        {
            foreach (GameEntity spawnEntity in listOfSpawnEntities)
            {
                bool found = false;
                foreach (SaveDataEntity saveDataEntity in _savedCollectables.GetEntities())
                {
                    if (saveDataEntity.collectableId.Value == spawnEntity.collectableId.Value)
                    {
                        found = true;
                        break;
                    }
                }
                
                GameEntity collectableEntity = Contexts.sharedInstance.game.CreateEntity();
                collectableEntity.isCollectable = true;
                collectableEntity.AddCollectableId(spawnEntity.collectableId.Value);
                await AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.CollectableReference, collectableEntity, spawnEntity.view.Value.transform.position, Quaternion.identity);
                Material collectableMaterial = collectableEntity.view.Value.GetComponentInChildren<SpriteRenderer>().material;
                collectableMaterial.SetInt(ShaderUtils.IsOutlineActive, Convert.ToInt32(found));
                collectableEntity.AddAnimator(collectableEntity.view.Value.GetComponentInChildren<Animator>());
                collectableEntity.AddAudioSource(collectableEntity.view.Value.GetComponentInChildren<AudioSource>());
                
            }
        }
    }
}