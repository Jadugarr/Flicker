//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.Common.BoxColliderComponent boxCollider { get { return (SemoGames.Common.BoxColliderComponent)GetComponent(GameComponentsLookup.BoxCollider); } }
    public bool hasBoxCollider { get { return HasComponent(GameComponentsLookup.BoxCollider); } }

    public void AddBoxCollider(UnityEngine.BoxCollider2D newValue) {
        var index = GameComponentsLookup.BoxCollider;
        var component = (SemoGames.Common.BoxColliderComponent)CreateComponent(index, typeof(SemoGames.Common.BoxColliderComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBoxCollider(UnityEngine.BoxCollider2D newValue) {
        var index = GameComponentsLookup.BoxCollider;
        var component = (SemoGames.Common.BoxColliderComponent)CreateComponent(index, typeof(SemoGames.Common.BoxColliderComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBoxCollider() {
        RemoveComponent(GameComponentsLookup.BoxCollider);
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

    static Entitas.IMatcher<GameEntity> _matcherBoxCollider;

    public static Entitas.IMatcher<GameEntity> BoxCollider {
        get {
            if (_matcherBoxCollider == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BoxCollider);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBoxCollider = matcher;
            }

            return _matcherBoxCollider;
        }
    }
}