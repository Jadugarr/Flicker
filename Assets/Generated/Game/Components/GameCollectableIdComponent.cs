//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.Collectables.CollectableIdComponent collectableId { get { return (SemoGames.Collectables.CollectableIdComponent)GetComponent(GameComponentsLookup.CollectableId); } }
    public bool hasCollectableId { get { return HasComponent(GameComponentsLookup.CollectableId); } }

    public void AddCollectableId(int newValue) {
        var index = GameComponentsLookup.CollectableId;
        var component = (SemoGames.Collectables.CollectableIdComponent)CreateComponent(index, typeof(SemoGames.Collectables.CollectableIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCollectableId(int newValue) {
        var index = GameComponentsLookup.CollectableId;
        var component = (SemoGames.Collectables.CollectableIdComponent)CreateComponent(index, typeof(SemoGames.Collectables.CollectableIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCollectableId() {
        RemoveComponent(GameComponentsLookup.CollectableId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity : ICollectableIdEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCollectableId;

    public static Entitas.IMatcher<GameEntity> CollectableId {
        get {
            if (_matcherCollectableId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollectableId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollectableId = matcher;
            }

            return _matcherCollectableId;
        }
    }
}
