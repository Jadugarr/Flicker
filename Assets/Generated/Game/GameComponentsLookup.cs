//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int AudioSource = 0;
    public const int PlaySound = 1;
    public const int BumperCollisionVelocity = 2;
    public const int Bumper = 3;
    public const int CheckpointEndMarker = 4;
    public const int CheckpointTriggerObject = 5;
    public const int CheckpointWall = 6;
    public const int Collectable = 7;
    public const int CollectableId = 8;
    public const int CollectableSpawn = 9;
    public const int Collected = 10;
    public const int Animation = 11;
    public const int Animator = 12;
    public const int AsyncOperationHandle = 13;
    public const int BoxCollider = 14;
    public const int CircleCollider = 15;
    public const int Garbage = 16;
    public const int Id = 17;
    public const int MovementSpeed = 18;
    public const int Position = 19;
    public const int Rigidbody = 20;
    public const int SpriteRenderer = 21;
    public const int Triggered = 22;
    public const int Velocity = 23;
    public const int View = 24;
    public const int Controller = 25;
    public const int RestartController = 26;
    public const int TeardownController = 27;
    public const int FlipperAnimation = 28;
    public const int ImpactStar = 29;
    public const int SpaceBarAnimation = 30;
    public const int FastForward = 31;
    public const int CurrentDragLength = 32;
    public const int CurrentFlickPower = 33;
    public const int FlickAngle = 34;
    public const int Flick = 35;
    public const int FlickLine = 36;
    public const int MaxDragLength = 37;
    public const int MaxFlickPower = 38;
    public const int StartFlick = 39;
    public const int Flipper = 40;
    public const int HingeJoint = 41;
    public const int LeftFlipper = 42;
    public const int Camera = 43;
    public const int CameraConfinerCollider = 44;
    public const int CameraConfiner = 45;
    public const int CameraFollow = 46;
    public const int VirtualCamera = 47;
    public const int MousePosition = 48;
    public const int ActiveSceneName = 49;
    public const int GameState = 50;
    public const int ControllerToRestartTransition = 51;
    public const int ControllerToTeardownTransition = 52;
    public const int EndLevelTransition = 53;
    public const int LevelIndexToLoadTransition = 54;
    public const int LevelTransitionOverlay = 55;
    public const int SceneToAdd = 56;
    public const int SceneToRemove = 57;
    public const int StartLevelTransition = 58;
    public const int TransitionCommands = 59;
    public const int Goal = 60;
    public const int Level = 61;
    public const int LevelIndex = 62;
    public const int PlayerSpawn = 63;
    public const int CurrentWaypointIndex = 64;
    public const int NextWaypointIndex = 65;
    public const int Obstacle = 66;
    public const int TimeWhenMovementStarted = 67;
    public const int Waypoints = 68;
    public const int Pause = 69;
    public const int PauseOverlay = 70;
    public const int PauseTimeEnded = 71;
    public const int PauseTimeStarted = 72;
    public const int Dead = 73;
    public const int GroundState = 74;
    public const int IsInGoal = 75;
    public const int Player = 76;
    public const int TrailRenderer = 77;
    public const int FinishLevelDialog = 78;
    public const int MainMenuBehaviour = 79;
    public const int MainMenu = 80;
    public const int OverlayLayer = 81;
    public const int StaticLayer = 82;

    public const int TotalComponents = 83;

    public static readonly string[] componentNames = {
        "AudioSource",
        "PlaySound",
        "BumperCollisionVelocity",
        "Bumper",
        "CheckpointEndMarker",
        "CheckpointTriggerObject",
        "CheckpointWall",
        "Collectable",
        "CollectableId",
        "CollectableSpawn",
        "Collected",
        "Animation",
        "Animator",
        "AsyncOperationHandle",
        "BoxCollider",
        "CircleCollider",
        "Garbage",
        "Id",
        "MovementSpeed",
        "Position",
        "Rigidbody",
        "SpriteRenderer",
        "Triggered",
        "Velocity",
        "View",
        "Controller",
        "RestartController",
        "TeardownController",
        "FlipperAnimation",
        "ImpactStar",
        "SpaceBarAnimation",
        "FastForward",
        "CurrentDragLength",
        "CurrentFlickPower",
        "FlickAngle",
        "Flick",
        "FlickLine",
        "MaxDragLength",
        "MaxFlickPower",
        "StartFlick",
        "Flipper",
        "HingeJoint",
        "LeftFlipper",
        "Camera",
        "CameraConfinerCollider",
        "CameraConfiner",
        "CameraFollow",
        "VirtualCamera",
        "MousePosition",
        "ActiveSceneName",
        "GameState",
        "ControllerToRestartTransition",
        "ControllerToTeardownTransition",
        "EndLevelTransition",
        "LevelIndexToLoadTransition",
        "LevelTransitionOverlay",
        "SceneToAdd",
        "SceneToRemove",
        "StartLevelTransition",
        "TransitionCommands",
        "Goal",
        "Level",
        "LevelIndex",
        "PlayerSpawn",
        "CurrentWaypointIndex",
        "NextWaypointIndex",
        "Obstacle",
        "TimeWhenMovementStarted",
        "Waypoints",
        "Pause",
        "PauseOverlay",
        "PauseTimeEnded",
        "PauseTimeStarted",
        "Dead",
        "GroundState",
        "IsInGoal",
        "Player",
        "TrailRenderer",
        "FinishLevelDialog",
        "MainMenuBehaviour",
        "MainMenu",
        "OverlayLayer",
        "StaticLayer"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(SemoGames.Audio.AudioSourceComponent),
        typeof(SemoGames.Audio.PlaySoundComponent),
        typeof(SemoGames.Bumpers.BumperCollisionVelocityComponent),
        typeof(SemoGames.Bumpers.BumperComponent),
        typeof(SemoGames.CheckpointWall.CheckpointEndMarkerComponent),
        typeof(SemoGames.CheckpointWall.CheckpointTriggerObjectComponent),
        typeof(SemoGames.CheckpointWall.CheckpointWallComponent),
        typeof(SemoGames.Collectables.CollectableComponent),
        typeof(SemoGames.Collectables.CollectableIdComponent),
        typeof(SemoGames.Collectables.CollectableSpawnComponent),
        typeof(SemoGames.Collectables.CollectedComponent),
        typeof(SemoGames.Common.AnimationComponent),
        typeof(SemoGames.Common.AnimatorComponent),
        typeof(SemoGames.Common.AsyncOperationHandleComponent),
        typeof(SemoGames.Common.BoxColliderComponent),
        typeof(SemoGames.Common.CircleColliderComponent),
        typeof(SemoGames.Common.GarbageComponent),
        typeof(SemoGames.Common.IdComponent),
        typeof(SemoGames.Common.MovementSpeedComponent),
        typeof(SemoGames.Common.PositionComponent),
        typeof(SemoGames.Common.RigidbodyComponent),
        typeof(SemoGames.Common.SpriteRendererComponent),
        typeof(SemoGames.Common.TriggeredComponent),
        typeof(SemoGames.Common.VelocityComponent),
        typeof(SemoGames.Common.ViewComponent),
        typeof(SemoGames.Controller.ControllerComponent),
        typeof(SemoGames.Controller.RestartControllerComponent),
        typeof(SemoGames.Controller.TeardownControllerComponent),
        typeof(SemoGames.Effects.FlipperAnimationComponent),
        typeof(SemoGames.Effects.ImpactStar),
        typeof(SemoGames.Effects.SpaceBarAnimationComponent),
        typeof(SemoGames.FastForward.FastForwardComponent),
        typeof(SemoGames.Flick.CurrentDragLengthComponent),
        typeof(SemoGames.Flick.CurrentFlickPowerComponent),
        typeof(SemoGames.Flick.FlickAngleComponent),
        typeof(SemoGames.Flick.FlickComponent),
        typeof(SemoGames.Flick.FlickLineComponent),
        typeof(SemoGames.Flick.MaxDragLengthComponent),
        typeof(SemoGames.Flick.MaxFlickPowerComponent),
        typeof(SemoGames.Flick.StartFlickComponent),
        typeof(SemoGames.Flipper.FlipperComponent),
        typeof(SemoGames.Flipper.HingeJointComponent),
        typeof(SemoGames.Flipper.LeftFlipperComponent),
        typeof(SemoGames.GameCamera.CameraComponent),
        typeof(SemoGames.GameCamera.CameraConfinerColliderComponent),
        typeof(SemoGames.GameCamera.CameraConfinerComponent),
        typeof(SemoGames.GameCamera.CameraFollowComponent),
        typeof(SemoGames.GameCamera.VirtualCameraComponent),
        typeof(SemoGames.GameInput.MousePositionComponent),
        typeof(SemoGames.GameScene.ActiveSceneNameComponent),
        typeof(SemoGames.GameState.GameStateComponent),
        typeof(SemoGames.GameTransition.ControllerToRestartTransitionComponent),
        typeof(SemoGames.GameTransition.ControllerToTeardownTransitionComponent),
        typeof(SemoGames.GameTransition.EndLevelTransitionComponent),
        typeof(SemoGames.GameTransition.LevelIndexToLoadTransitionComponent),
        typeof(SemoGames.GameTransition.LevelTransitionOverlayComponent),
        typeof(SemoGames.GameTransition.SceneToAddComponent),
        typeof(SemoGames.GameTransition.SceneToRemoveComponent),
        typeof(SemoGames.GameTransition.StartLevelTransitionComponent),
        typeof(SemoGames.GameTransition.TransitionCommandsComponent),
        typeof(SemoGames.Goal.GoalComponent),
        typeof(SemoGames.Level.LevelComponent),
        typeof(SemoGames.Level.LevelIndexComponent),
        typeof(SemoGames.Level.PlayerSpawnComponent),
        typeof(SemoGames.Obstacles.CurrentWaypointIndexComponent),
        typeof(SemoGames.Obstacles.NextWaypointIndexComponent),
        typeof(SemoGames.Obstacles.ObstacleComponent),
        typeof(SemoGames.Obstacles.TimeWhenMovementStartedComponent),
        typeof(SemoGames.Obstacles.WaypointsComponent),
        typeof(SemoGames.Pause.PauseComponent),
        typeof(SemoGames.Pause.PauseOverlayComponent),
        typeof(SemoGames.Pause.PauseTimeEndedComponent),
        typeof(SemoGames.Pause.PauseTimeStartedComponent),
        typeof(SemoGames.Player.DeadComponent),
        typeof(SemoGames.Player.GroundStateComponent),
        typeof(SemoGames.Player.IsInGoalComponent),
        typeof(SemoGames.Player.PlayerComponent),
        typeof(SemoGames.Player.TrailRendererComponent),
        typeof(SemoGames.UI.FinishLevelDialogComponent),
        typeof(SemoGames.UI.MainMenuBehaviourComponent),
        typeof(SemoGames.UI.MainMenuComponent),
        typeof(SemoGames.UI.OverlayLayerComponent),
        typeof(SemoGames.UI.StaticLayerComponent)
    };
}
