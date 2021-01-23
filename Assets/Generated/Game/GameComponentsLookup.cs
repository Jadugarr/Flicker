//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int AsyncOperationHandle = 0;
    public const int Id = 1;
    public const int View = 2;
    public const int Controller = 3;
    public const int Camera = 4;
    public const int CameraConfinerCollider = 5;
    public const int CameraConfiner = 6;
    public const int ActiveSceneName = 7;
    public const int Level = 8;
    public const int LevelIndex = 9;
    public const int PlayerSpawn = 10;
    public const int Player = 11;
    public const int MainMenuBehaviour = 12;
    public const int MainMenu = 13;
    public const int StaticLayer = 14;

    public const int TotalComponents = 15;

    public static readonly string[] componentNames = {
        "AsyncOperationHandle",
        "Id",
        "View",
        "Controller",
        "Camera",
        "CameraConfinerCollider",
        "CameraConfiner",
        "ActiveSceneName",
        "Level",
        "LevelIndex",
        "PlayerSpawn",
        "Player",
        "MainMenuBehaviour",
        "MainMenu",
        "StaticLayer"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(SemoGames.Common.AsyncOperationHandleComponent),
        typeof(SemoGames.Common.IdComponent),
        typeof(SemoGames.Common.ViewComponent),
        typeof(SemoGames.Controller.ControllerComponent),
        typeof(SemoGames.GameCamera.CameraComponent),
        typeof(SemoGames.GameCamera.CameraConfinerColliderComponent),
        typeof(SemoGames.GameCamera.CameraConfinerComponent),
        typeof(SemoGames.GameScene.ActiveSceneNameComponent),
        typeof(SemoGames.Level.LevelComponent),
        typeof(SemoGames.Level.LevelIndexComponent),
        typeof(SemoGames.Level.PlayerSpawnComponent),
        typeof(SemoGames.Player.PlayerComponent),
        typeof(SemoGames.UI.MainMenuBehaviourComponent),
        typeof(SemoGames.UI.MainMenuComponent),
        typeof(SemoGames.UI.StaticLayerComponent)
    };
}
