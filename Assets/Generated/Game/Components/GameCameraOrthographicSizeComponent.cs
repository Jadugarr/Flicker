//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity cameraOrthographicSizeEntity { get { return GetGroup(GameMatcher.CameraOrthographicSize).GetSingleEntity(); } }
    public SemoGames.GameCamera.CameraOrthographicSizeComponent cameraOrthographicSize { get { return cameraOrthographicSizeEntity.cameraOrthographicSize; } }
    public bool hasCameraOrthographicSize { get { return cameraOrthographicSizeEntity != null; } }

    public GameEntity SetCameraOrthographicSize(float newValue) {
        if (hasCameraOrthographicSize) {
            throw new Entitas.EntitasException("Could not set CameraOrthographicSize!\n" + this + " already has an entity with SemoGames.GameCamera.CameraOrthographicSizeComponent!",
                "You should check if the context already has a cameraOrthographicSizeEntity before setting it or use context.ReplaceCameraOrthographicSize().");
        }
        var entity = CreateEntity();
        entity.AddCameraOrthographicSize(newValue);
        return entity;
    }

    public void ReplaceCameraOrthographicSize(float newValue) {
        var entity = cameraOrthographicSizeEntity;
        if (entity == null) {
            entity = SetCameraOrthographicSize(newValue);
        } else {
            entity.ReplaceCameraOrthographicSize(newValue);
        }
    }

    public void RemoveCameraOrthographicSize() {
        cameraOrthographicSizeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.GameCamera.CameraOrthographicSizeComponent cameraOrthographicSize { get { return (SemoGames.GameCamera.CameraOrthographicSizeComponent)GetComponent(GameComponentsLookup.CameraOrthographicSize); } }
    public bool hasCameraOrthographicSize { get { return HasComponent(GameComponentsLookup.CameraOrthographicSize); } }

    public void AddCameraOrthographicSize(float newValue) {
        var index = GameComponentsLookup.CameraOrthographicSize;
        var component = (SemoGames.GameCamera.CameraOrthographicSizeComponent)CreateComponent(index, typeof(SemoGames.GameCamera.CameraOrthographicSizeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCameraOrthographicSize(float newValue) {
        var index = GameComponentsLookup.CameraOrthographicSize;
        var component = (SemoGames.GameCamera.CameraOrthographicSizeComponent)CreateComponent(index, typeof(SemoGames.GameCamera.CameraOrthographicSizeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCameraOrthographicSize() {
        RemoveComponent(GameComponentsLookup.CameraOrthographicSize);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCameraOrthographicSize;

    public static Entitas.IMatcher<GameEntity> CameraOrthographicSize {
        get {
            if (_matcherCameraOrthographicSize == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraOrthographicSize);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraOrthographicSize = matcher;
            }

            return _matcherCameraOrthographicSize;
        }
    }
}
