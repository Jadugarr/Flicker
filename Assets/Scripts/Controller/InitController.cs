﻿using Controller;
using Entitas;
using SemoGames.Configurations;
using SemoGames.GameScene;
using SemoGames.UI;

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
        }

        protected override void AfterStart()
        {
            Contexts.sharedInstance.game.CreateEntity().AddActiveSceneName(GameConfigurations.GameSceneConfiguration.MainMenuSceneName);
        }

        private void OnEntityCreated(IContext context, IEntity entity)
        {
            (entity as GameEntity)?.AddId(entity.creationIndex);
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            
            return new Systems()
                .Add(new InitCurrentSceneSystem())
                .Add(new LoadNewSceneSystem(gameContext))
                .Add(new UnloadSceneSystem(gameContext))
                .Add(new RestartControllerSystem(gameContext))
                .Add(new StartLevelTransitionSystem(gameContext))
                .Add(new EndLevelTransitionSystem(gameContext));
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