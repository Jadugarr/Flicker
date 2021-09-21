using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Common;
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

        protected override async void Execute(List<GameEntity> entities)
        {
            GameEntity playerEntity = playerGroup.GetSingleEntity();
            GameEntity spawnEntity = spawnPointGroup.GetSingleEntity();

            if (playerEntity.hasView)
            {
                playerEntity.ReplacePosition(spawnEntity.view.Value.transform.position);
                playerEntity.ReplaceVelocity(Vector3.zero);
                playerEntity.isIsInGoal = false;
            }
            else
            {
                await AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.PlayerAssetReference, playerEntity, spawnEntity.view.Value.transform.position, Quaternion.identity);
                GameObject playerObject = playerEntity.view.Value;
                playerObject.transform.position = spawnEntity.view.Value.transform.position;
                Rigidbody2D playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
                CircleCollider2D playerCircleCollider2D = playerObject.GetComponent<CircleCollider2D>();
                playerEntity.AddRigidbody(playerRigidBody);
                playerEntity.AddCircleCollider(playerCircleCollider2D);
                playerEntity.AddVelocity(playerRigidBody.velocity);
                playerEntity.isCameraFollow = true;
                playerEntity.AddGroundState(GroundState.Ground);
                playerEntity.AddTrailRenderer(playerObject.GetComponentInChildren<TrailRenderer>());
                playerEntity.AddAudioSource(playerObject.GetComponent<AudioSource>());
                playerEntity.AddSpriteRenderer(playerObject.GetComponent<SpriteRenderer>());
                playerEntity.AddAnimation(playerObject.GetComponent<Animation>());
            }
        }
    }
}