﻿using Bumpers.Systems;
using Entitas;
using FastForward.Systems;
using GameTimer.Systems;
using Level.Systems;
using SaveData.Systems;
using SemoGames.Audio;
using SemoGames.CheckpointWall;
using SemoGames.Collectables.Systems;
using SemoGames.Common;
using SemoGames.Effects;
using SemoGames.Flick;
using SemoGames.Flipper;
using SemoGames.GameCamera;
using SemoGames.GameInput;
using SemoGames.GameState;
using SemoGames.GameTimer;
using SemoGames.Goal.Systems;
using SemoGames.Obstacles.Systems;
using SemoGames.Pause;
using SemoGames.Player;
using SemoGames.UI;
using Speedrun.Systems;

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

        protected override void AfterAwake()
        {
            Contexts.sharedInstance.game.ReplaceCameraOrthographicSize(10f);
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            InputContext inputContext = Contexts.sharedInstance.input;
            SaveDataContext saveDataContext = Contexts.sharedInstance.saveData;
            GameSettingsContext gameSettingsContext = Contexts.sharedInstance.gameSettings;
            
            return new Systems()
                .Add(new InitializePauseSystem())
                .Add(new InitializeLevelSystem())
                .Add(new InitializePlayerSystem())
                .Add(new InitializeGameStateSystem())
                .Add(new InitializeGameTimeSystem())
                .Add(new InitializeSpeedrunTimeSystem())
                .Add(new InitializeLevelTimerSystem())
                .Add(new InitializeLevelSpeedrunTimerSystem())
                .Add(new CheckGameStateSystem(gameContext, inputContext.playerInput.Value))
                .Add(new SwitchToPlayerInputMap(gameContext))
                .Add(new SwitchToUiInputMapSystem(gameContext))
                .Add(new SwitchToEnvironmentInputMapSystem(gameContext))
                .Add(new SwitchToNothingInputMapSystem(gameContext))
                .Add(new SpawnPlayerSystem(gameContext))
                .Add(new SpawnCollectableSystem(gameContext))
                .Add(new SetCameraFollowPlayerSystem(gameContext))
                .Add(new CreateFlickLineSystem(gameContext))
                .Add(new DrawFlickLineSystem(gameContext))
                .Add(new CalculateCurrentPowerSystem(gameContext))
                .Add(new CalculateFlickAngleSystem(gameContext))
                .Add(new DestroyFlickLineSystem(gameContext))
                .Add(new ShowFinishLevelDialogOnReachedGoalSystem(gameContext))
                .Add(new TeardownPlayerSystem())
                .Add(new LoadLevelSystem(gameContext))
                .Add(new TeardownLevelSystem())
                .Add(new TeardownPlayerSpawnSystem())
                .Add(new InitializeFlipperSystem(gameContext))
                .Add(new TeardownFlipperSystem())
                .Add(new InteractWithFlipperSystem(inputContext))
                .Add(new StopInteractingWithFlipperSystem(inputContext))
                .Add(new PauseSystem(gameContext))
                .Add(new UnpauseSystem(gameContext))
                .Add(new FastForwardActivatedSystem(gameContext))
                .Add(new FastForwardDeactivatedSystem(gameContext))
                .Add(new CheckpointWallTriggeredSystem(gameContext))
                .Add(new CollectableCollectedSystem(gameContext))
                .Add(new HandleTrailRendererEmissionSystem(gameContext))
                .Add(new PlaySoundSystem(gameContext))
                .Add(new PlayFlipperTutorialAnimationSystem(gameContext))
                .Add(new PlaySpaceBarAnimationSystem(gameContext))
                .Add(new DissolvePlayerAndTrailSystem(gameContext))
                .Add(new ReverseDissolvePlayerAndTrailSystem(gameContext))
                .Add(new StopGameTimeSystem(gameContext))
                .Add(new ResumeTimeSystem(gameContext))
                .Add(new MeasureGameTimeSystem())
                .Add(new SaveCollectedCollectableSystem(gameContext))
                .Add(new SaveGameSystem(saveDataContext))
                .Add(new SaveBeatenLevelSystem(gameContext))
                .Add(new SaveLevelTimeSystem(gameContext))
                .Add(new ReachedGoalInSpeedrunSystem(gameContext))
                .Add(new CheckIfAllCollectedSystem(gameContext))
                .Add(new RemoveSpeedrunTimerSystem(gameSettingsContext))
                .Add(new UpdateLevelTimerSystem(gameContext))
                .Add(new TeardownObstaclesSystem(gameContext))
                .Add(new TeardownPauseSystem())
                .Add(new TeardownBumpersSystem())
                .Add(new TeardownCollectablesSystem())
                .Add(new TeardownCollectableSpawnSystem())
                .Add(new TeardownCheckpointWallsSystem())
                .Add(new TeardownGoalSystem())
                .Add(new TeardownImpactStarsSystem())
                .Add(new TeardownFlipperAnimationSystem())
                .Add(new TeardownSpaceBarAnimationSystem())
                .Add(new TeardownFlickLineSystem())
                .Add(new TeardownLastTriggeredCheckpointSystem())
                .Add(new TeardownGameTimeSystem())
                .Add(new TeardownLevelTimerSystem())
                .Add(new TeardownAllCollectedSystem());
        }

        protected override Systems CreateLateUpdateSystems(IContext context)
        {
            return new Systems();
        }

        protected override Systems CreateFixedUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;

            return new Systems()
                .Add(new SyncVelocitySystem(gameContext))
                .Add(new SyncPositionAndViewSystem(gameContext))
                .Add(new ProcessBumperCollisionSystem(gameContext))
                .Add(new CheckGroundStateSystem(gameContext))
                .Add(new ApplyPowerToCharacterSystem(gameContext))
                .Add(new DetectStopMovingSystem(gameContext))
                .Add(new StopSimulationOfEntitySystem(gameContext))
                .Add(new ResumeSimulationOfEntitySystem(gameContext))
                .Add(new AdjustObstacleMoveTimerSystem(gameContext))
                .Add(new MoveObstaclesSystem(gameContext))
                .Add(new PlayerDiedSystem(gameContext))
                .Add(new MoveToLastCheckpointSystem(gameContext))
                .Add(new RenderVelocitySystem(gameContext))
                .Add(new RenderPositionSystem(gameContext))
                .Add(new CleanupInputActionsSystem());
        }
    }
}