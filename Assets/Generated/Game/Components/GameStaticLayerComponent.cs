//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity staticLayerEntity { get { return GetGroup(GameMatcher.StaticLayer).GetSingleEntity(); } }
    public SemoGames.UI.StaticLayerComponent staticLayer { get { return staticLayerEntity.staticLayer; } }
    public bool hasStaticLayer { get { return staticLayerEntity != null; } }

    public GameEntity SetStaticLayer(UnityEngine.GameObject newValue) {
        if (hasStaticLayer) {
            throw new Entitas.EntitasException("Could not set StaticLayer!\n" + this + " already has an entity with SemoGames.UI.StaticLayerComponent!",
                "You should check if the context already has a staticLayerEntity before setting it or use context.ReplaceStaticLayer().");
        }
        var entity = CreateEntity();
        entity.AddStaticLayer(newValue);
        return entity;
    }

    public void ReplaceStaticLayer(UnityEngine.GameObject newValue) {
        var entity = staticLayerEntity;
        if (entity == null) {
            entity = SetStaticLayer(newValue);
        } else {
            entity.ReplaceStaticLayer(newValue);
        }
    }

    public void RemoveStaticLayer() {
        staticLayerEntity.Destroy();
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

    public SemoGames.UI.StaticLayerComponent staticLayer { get { return (SemoGames.UI.StaticLayerComponent)GetComponent(GameComponentsLookup.StaticLayer); } }
    public bool hasStaticLayer { get { return HasComponent(GameComponentsLookup.StaticLayer); } }

    public void AddStaticLayer(UnityEngine.GameObject newValue) {
        var index = GameComponentsLookup.StaticLayer;
        var component = (SemoGames.UI.StaticLayerComponent)CreateComponent(index, typeof(SemoGames.UI.StaticLayerComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceStaticLayer(UnityEngine.GameObject newValue) {
        var index = GameComponentsLookup.StaticLayer;
        var component = (SemoGames.UI.StaticLayerComponent)CreateComponent(index, typeof(SemoGames.UI.StaticLayerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveStaticLayer() {
        RemoveComponent(GameComponentsLookup.StaticLayer);
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

    static Entitas.IMatcher<GameEntity> _matcherStaticLayer;

    public static Entitas.IMatcher<GameEntity> StaticLayer {
        get {
            if (_matcherStaticLayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StaticLayer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStaticLayer = matcher;
            }

            return _matcherStaticLayer;
        }
    }
}