using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Player
{
    public class SpawnPlayerSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> spawnPointGroup;
        private IGroup<GameEntity> playerGroup;
        
        public SpawnPlayerSystem(IContext<GameEntity> context) : base(context)
        {
            spawnPointGroup = context.GetGroup(GameMatcher.PlayerSpawn);
            playerGroup = context.GetGroup(GameMatcher.Player);
        }

        public SpawnPlayerSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameEntity>(GameMatcher.AnyOf(GameMatcher.PlayerSpawn, GameMatcher.Player),
                    GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return spawnPointGroup.count > 0 && playerGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity playerEntity = playerGroup.GetSingleEntity();
            GameEntity spawnEntity = spawnPointGroup.GetSingleEntity();
            
            AssetLoaderUtils.LoadAssetAsync(GameConfigurations.AssetReferenceConfiguration.PlayerAssetReference, playerEntity,
                loadedObject =>
                {
                    GameObject playerObject =
                        GameObject.Instantiate(loadedObject, spawnEntity.view.Value.transform.position, Quaternion.identity);
                    playerEntity.AddView(playerObject);
                    playerEntity.AddPosition(playerObject.transform.position);
                    Rigidbody2D playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
                    playerEntity.AddRigidbody(playerRigidBody);
                    playerEntity.AddVelocity(playerRigidBody.velocity);
                    playerEntity.isCameraFollow = true;
                    playerObject.Link(playerEntity);
                });
        }
    }
}