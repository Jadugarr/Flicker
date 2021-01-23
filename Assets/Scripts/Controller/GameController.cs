﻿using Entitas;
using Level.Systems;
using SemoGames.Controller;
using SemoGames.GameCamera;
using SemoGames.Player;

namespace SemoGames.Controller
{
    public class GameController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.Game;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            
            return new Systems()
                .Add(new InitializeLevelSystem())
                .Add(new InitializePlayerSystem())
                .Add(new SpawnPlayerSystem(gameContext))
                .Add(new SetCameraConfinerSystem(gameContext))
                .Add(new SetCameraFollowPlayerSystem(gameContext));
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