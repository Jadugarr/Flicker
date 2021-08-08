using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
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

        private void SpawnCollectableOnSpawns(GameEntity[] listOfSpawnEntities)
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

                if (found) continue;
                
                GameEntity collectableEntity = Contexts.sharedInstance.game.CreateEntity();
                collectableEntity.isCollectable = true;
                collectableEntity.AddCollectableId(spawnEntity.collectableId.Value);
                
                new CollectableSpawner(collectableEntity, spawnEntity).Spawn();
            }
        }

        private class CollectableSpawner : IDisposable
        {
            private GameEntity _entityToLinkTo;
            private GameEntity _spawnEntity;

            public CollectableSpawner(GameEntity entityToLinkTo, GameEntity spawnEntity)
            {
                _entityToLinkTo = entityToLinkTo;
                _spawnEntity = spawnEntity;
            }

            public void Spawn()
            {
                AssetLoaderUtils.LoadAssetAsync(GameConfigurations.AssetReferenceConfiguration.CollectableReference,
                    _entityToLinkTo,
                    loadedObject =>
                    {
                        GameObject collectableObject =
                            GameObject.Instantiate(loadedObject, _spawnEntity.view.Value.transform.position,
                                Quaternion.identity);
                        _entityToLinkTo.AddView(collectableObject);
                        _entityToLinkTo.AddPosition(collectableObject.transform.position);
                        _entityToLinkTo.AddAnimator(collectableObject.GetComponentInChildren<Animator>());
                        collectableObject.Link(_entityToLinkTo);

                        Dispose();
                    });
            }

            public void Dispose()
            {
                
            }
        }
    }
}