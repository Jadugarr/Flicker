using Entitas;
using SemoGames.Configurations;
using SemoGames.GameCamera;
using SemoGames.GameScene;
using UnityEngine.AddressableAssets;

namespace SemoGames.Controller
{
    public class InitController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.Init;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override void AfterAwake()
        {
            GetContext().OnEntityCreated += OnEntityCreated;
            GetContext().OnEntityWillBeDestroyed += OnEntityWillBeDestroyed;
        }

        protected override void AfterStart()
        {
            Contexts.sharedInstance.game.CreateEntity().AddActiveSceneName(GameConfigurations.GameSceneConfiguration.MainMenuSceneName);
        }

        private void OnEntityCreated(IContext context, IEntity entity)
        {
            (entity as GameEntity)?.AddId(entity.creationIndex);
        }

        private void OnEntityWillBeDestroyed(IContext context, IEntity entity)
        {
            GameEntity gameEntity = (GameEntity) entity;
            if (gameEntity != null && gameEntity.hasAsyncOperationHandle)
            {
                Addressables.Release(gameEntity.asyncOperationHandle.Value);
            }
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            
            return new Systems()
                .Add(new InitCurrentSceneSystem())
                .Add(new LoadNewSceneSystem(gameContext))
                .Add(new UnloadSceneSystem(gameContext));
        }

        protected override Systems CreateLateUpdateSystems(IContext context)
        {
            return new Systems();
        }

        protected override Systems CreateFixedUpdateSystems(IContext context)
        {
            return new Systems();
        }
    }
}